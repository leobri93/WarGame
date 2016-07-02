using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using WarGame.Models;
using WarGame.Models.Enum;
using WarGame.Helper;
using System.Net;

namespace WarGame.Controllers
{
    public class MapController : Controller
    {

        private static readonly List<RegionViewModel> regions = Westeros.Map();
        private static List<PlayerViewModel> players;

        public ActionResult Index(PlayerViewModel player)
        {

            var obj = new Objective();
            var myFamily = player.Family.Name;
            var myObj = obj.RafflingObjectives();

            players = new List<PlayerViewModel>();
            players.Add(new PlayerViewModel(player.Name, new FamilyViewModel(myFamily), myObj));

            var families = Enum.GetNames(typeof(Family)).Select(e => new SelectListItem { Text = e });

            var firstFamily = families.First(x => x.Text != myFamily).Text;
            players.Add(new PlayerViewModel("Computador", new FamilyViewModel(firstFamily), obj.RafflingObjectives()));

            var secondFamily = families.First(x => x.Text != myFamily & x.Text != firstFamily).Text;
            players.Add(new PlayerViewModel("Computador", new FamilyViewModel(secondFamily), obj.RafflingObjectives()));

            Distributions.regionsDistribution(players, regions);

            ViewBag.Name = player.Name;
            ViewBag.Familiy = player.Family.Name;
            ViewBag.Objective = myObj.description;
            ViewBag.Src = players.First().Family.Src;

            return View();
        }

        [HttpGet]
        [Route("maps/regions")]
        public JsonResult Regions()
        {
            return Json(regions, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Route("maps/attack/{rid}")]
        public JsonResult Attack(string rid) 
        {
            var region = regions.Region(rid);
            var enemyBorders = region.EnemyFrontiers();

            if (enemyBorders.Count() > 0 && region.Troops > 1)
            {
                var maxTroopsAttack = (region.Troops > 3) ? 3 : region.Troops - 1;
                Response.StatusCode = (int) HttpStatusCode.OK;
                return Json(new { name = region.Name, enemyBorders = enemyBorders, maxTroopsAttack = maxTroopsAttack }, 
                    JsonRequestBehavior.AllowGet);
            }

            Response.StatusCode = (int) HttpStatusCode.BadRequest;
            return Json(new { message = "Jogador não pode atacar."}, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Route("maps/battle")]
        public JsonResult Battle(string aid, string did, int atroops)
        {
            var attack = regions.Region(aid);
            var defense = regions.Region(did);

            var dtroops = (defense.Troops > 3) ? 3 : defense.Troops;
            var random = new Random();

            var aplayer = new int[atroops];
            var dplayer = new int[dtroops];

            aplayer = rollTheDice(aplayer, random);
            dplayer = rollTheDice(dplayer, random);

            var resultBattle = attack.Attack(defense, aplayer, dplayer);
            var victory = "";

            if (resultBattle[0] <= resultBattle[1])
            {
                victory = attack.Name;
            } else
            {
                victory = defense.Name;
            }

            var occupiedTerritory = false;
            if (defense.Troops < 1)
                occupiedTerritory = true;

            Response.StatusCode = (int)HttpStatusCode.OK;
            return Json(new { aplayer = aplayer, dplayer = dplayer, result = resultBattle, victory = victory, occupiedTerritory = occupiedTerritory });
        }

        private int[] rollTheDice(int[] player, Random random)
        {
            for (var i = 0; i < player.Length; i++)
            {
                player[i] = random.Next(1, 7);
            }

            return player.OrderByDescending(d => d).ToArray();
        }

        [HttpGet]
        [Route("maps/{rid}/distribute-troops/{pid}")]
        public JsonResult DistributeTroops(string rid, string pid)
        {
            var region = regions.Region(rid);
            var player = players.First(p => p.Id == pid);
            if (region.Player.Id.Equals(pid))
            {
                var troopsToDistribute = Distributions.troopsDistribution(player, regions);
                Response.StatusCode = (int)HttpStatusCode.OK;
                return Json(new { name = region.Name, troopsToDistribute = troopsToDistribute }, JsonRequestBehavior.AllowGet);
            }

            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return Json(new { message = "Essa região não é sua." }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Route("maps/add-troops")]
        public JsonResult AddTroops(string rid, int troops) 
        {
            var region = regions.Region(rid);
            region.Troops += troops;           
            Response.StatusCode = (int)HttpStatusCode.OK;
            return Json(new { name = region.Name, troops = region.Troops });
        }

        [HttpGet]
        [Route("maps/move-troops/{rid}")]
        public JsonResult MoveTroops(string rid)
        {
            var region = regions.Region(rid);
            var friendlyBorders = region.FriendlyFrontiers();

            if (friendlyBorders.Count() > 0 && region.Troops > 1)
            {
                var maxTroops = region.Troops - 1;
                Response.StatusCode = (int)HttpStatusCode.OK;
                return Json(new { name = region.Name, friendlyBorders = friendlyBorders,  troops = maxTroops }, 
                    JsonRequestBehavior.AllowGet);
            }

            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return Json(new { message = "Não pode mover tropas." }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Route("maps/transfer-troops")]
        public JsonResult TransferTroops(string sid, string did, int troops)
        {
            var sourceRegion = regions.Region(sid);
            var destinationRegion = regions.Region(did);

            sourceRegion.Troops -= troops;
            destinationRegion.Troops += troops;

            Response.StatusCode = (int)HttpStatusCode.OK;
            return Json(new { sourceTroops = sourceRegion.Troops, destinationTroops = troops });
        }

    }
}