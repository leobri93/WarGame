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
using WarGame.IA;

namespace WarGame.Controllers
{
    public class MapController : Controller
    {

        private static List<RegionViewModel> regions;
        private static List<PlayerViewModel> players;

        public ActionResult Index(PlayerViewModel player)
        {
            regions = Westeros.Map();
            var obj = new Objective();
            var myFamily = player.Family.Name;
            var myObj = obj.RafflingObjectives();

            players = new List<PlayerViewModel>();
            players.Add(new PlayerViewModel(player.Name, new FamilyViewModel(myFamily), myObj, true));

            var families = Enum.GetNames(typeof(Family)).Select(e => new SelectListItem { Text = e });

            var firstFamily = families.First(x => x.Text != myFamily).Text;
            players.Add(new PlayerViewModel("Computador", new FamilyViewModel(firstFamily), obj.RafflingObjectives(), false));

            var secondFamily = families.First(x => x.Text != myFamily & x.Text != firstFamily).Text;
            players.Add(new PlayerViewModel("Computador", new FamilyViewModel(secondFamily), obj.RafflingObjectives(), false));

            Distributions.regionsDistribution(players, regions);

            DisponibilizarBonus();
            ViewBag.Name = player.Name;
            ViewBag.Familiy = player.Family.Name;
            ViewBag.Objective = myObj.description;
            ViewBag.Src = players.First().Family.Src;
           
            ViewBag.Player1 = players[0].Family.Name;
            ViewBag.ColorPlayer1 = players[0].Family.Color;
            ViewBag.Player2 = players[1].Family.Name; 
            ViewBag.ColorPlayer2 = players[1].Family.Color;
            ViewBag.Player3 = players[2].Family.Name; 
            ViewBag.ColorPlayer3 = players[2].Family.Color;
            
            return View();
        }
        public void DisponibilizarBonus()
        {
            ViewBag.BonusDorne = Kingdom.Instance.Dorne.Bonus;
            ViewBag.BonusTheCrownlands = Kingdom.Instance.TheCrownlands.Bonus;
            ViewBag.BonusTheIronIslands = Kingdom.Instance.TheIronIslands.Bonus;
            ViewBag.BonusTheNorth = Kingdom.Instance.TheNorth.Bonus;
            ViewBag.BonusTheReach = Kingdom.Instance.TheReach.Bonus;
            ViewBag.BonusTheRiverlands = Kingdom.Instance.TheRiverlands.Bonus;
            ViewBag.BonusTheStormlands = Kingdom.Instance.TheStormlands.Bonus;
            ViewBag.BonusTheValeOfArryn = Kingdom.Instance.TheValeOfArryn.Bonus;
            ViewBag.BonusTheWesterlands = Kingdom.Instance.TheWesterlands.Bonus;

        }

        [HttpGet]
        [Route("maps/regions")]
        public JsonResult Regions()
        {
            return Json(regions, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Route("maps/{pid}/attack/{rid}")]
        public JsonResult Attack(string pid, string rid) 
        {
            var region = regions.FindRegion(rid);
            string message;

            if (region.Player.Id != pid)
            {
                message = $"A região de {region.Name} não foi conquistada ainda. Conquiste-a!";
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { name = region.Name, message = message }, JsonRequestBehavior.AllowGet);
            }

            var enemyBorders = region.EnemyFrontiers(pid);

            if (enemyBorders.Count() > 0 && region.Troops > 1)
            {
                var maxTroopsAttack = (region.Troops > 3) ? 3 : region.Troops - 1;
                Response.StatusCode = (int) HttpStatusCode.OK;
                return Json(new { name = region.Name, enemyBorders = enemyBorders, maxTroopsAttack = maxTroopsAttack }, 
                    JsonRequestBehavior.AllowGet);
            }

            message = (region.Troops == 1) ? $"Temos poucos soldados aqui em {region.Name}. Quando os reforços chegarem, atacaremos." : $"Olhe à sua volta. Regiões aliadas protengem {region.Name}";
            Response.StatusCode = (int) HttpStatusCode.BadRequest;
            return Json(new { name = region.Name, message = message }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Route("maps/battle")]
        public JsonResult Battle(string aid, string did, int atroops)
        {
            var attack = regions.FindRegion(aid);
            var defense = regions.FindRegion(did);

            var resultBattle = Conquest.Battle(attack, atroops, defense);

            string color = null;
            if (defense.Troops < 1)
            {
                defense.Player = attack.Player;
                defense.Troops++;
                attack.Troops--;
                color = attack.Player.Family.Color;
            }

            Response.StatusCode = (int)HttpStatusCode.OK;
            return Json(new { aplayer = resultBattle.aplayer, dplayer = resultBattle.dplayer, attackName = attack.Name, attackTroops = attack.Troops, defenseName = defense.Name, defenseTroops = defense.Troops, resultBattle = resultBattle.resultBattle, color = color});
        }
     
        [HttpGet]
        [Route("maps/{pid}/distribute-troops/{rid}")]
        public JsonResult DistributeTroops(string pid, string rid)
        {
            var region = regions.FindRegion(rid);
            var player = players.First(p => p.Id == pid);
            if (region.Player.Id.Equals(pid))
            {
                var troopsToDistribute = Distributions.troopsDistribution(player, regions);
                Response.StatusCode = (int)HttpStatusCode.OK;
                return Json(new { name = region.Name }, JsonRequestBehavior.AllowGet);
            }

            var message = $"O que você está fazendo? Não vamos fortalecer nossos inimigos.";
            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return Json(new { name = region.Name, message = message }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Route("maps/troops-to-distribute/{pid}")]
        public JsonResult TroopsToDistribute(string pid)
        {
            var player = players.FindPlayer(pid);
            var troopsToDistribute = Distributions.troopsDistribution(player, regions);
            Response.StatusCode = (int)HttpStatusCode.OK;
            return Json(new { troopsToDistribute = troopsToDistribute }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Route("maps/add-troops")]
        public JsonResult AddTroops(string rid, int troops) 
        {
            var region = regions.FindRegion(rid);
            region.Troops += troops;           
            Response.StatusCode = (int)HttpStatusCode.OK;
            return Json(new { name = region.Name, troops = region.Troops });
        }

        [HttpGet]
        [Route("maps/{pid}/move-troops/{rid}")]
        public JsonResult MoveTroops(string pid, string rid)
        {
            var region = regions.FindRegion(rid);
            string message;

            if (region.Player.Id != pid)
            {
                message = $"O que espera? Que o inimigo lhe envie reforços?";
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { name = region.Name, message = message }, JsonRequestBehavior.AllowGet);
            }

            var friendlyBorders = region.FriendlyFrontiers(region.Player.Id);

            if (friendlyBorders.Count() > 0 && region.Troops > 1)
            {
                var maxTroops = region.Troops - 1;
                Response.StatusCode = (int)HttpStatusCode.OK;
                return Json(new { name = region.Name, friendlyBorders = friendlyBorders,  troops = maxTroops }, 
                    JsonRequestBehavior.AllowGet);
            }
            message = (region.Troops == 1) ? $"Já temos poucos soldados aqui em {region.Name}, não podemos enviar reforços." : $"Estamos cercados! Precisamos dominar as regiões vizinhas ou elas nos dominarão.";
            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return Json(new { name = region.Name, message = message }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Route("maps/transfer-troops")]
        public JsonResult TransferTroops(string sid, string did, int troops)
        {
            var sourceRegion = regions.FindRegion(sid);
            var destinationRegion = regions.FindRegion(did);

            sourceRegion.Troops -= troops;
            destinationRegion.Troops += troops;

            Response.StatusCode = (int)HttpStatusCode.OK;
            return Json(new { nameSource = sourceRegion.Name, sourceTroops = sourceRegion.Troops, nameDestination = destinationRegion.Name, destinationTroops = destinationRegion.Troops });
        }

        [HttpGet]
        [Route("maps/player-turn/{i}")]
        public JsonResult PlayerTurn(int i)
        {           
            Response.StatusCode = (int)HttpStatusCode.OK;
            return Json(new { player = players[i] }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Route("maps/{pid}/victory")]
        public JsonResult Victory(string pid)
        {
            var player = players.FindPlayer(pid);
            if (player.regrasDeVitoria(regions, players))
            {                
                return Json(new { victory = true, family = player.Family.Name, objective = player.objective.description }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { victory = false, family = player.Family.Name, objective = player.objective.description }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Route("maps/player-execute")]
        public JsonResult ExecuteIA(string pid, int round)
        {
            var player = players.FindPlayer(pid);

            var distribution = DistributeTroops(player);

            object battle = null;
            if (round > 0)
            {
                battle = AttackIA(player);
            }

            return Json(new { distribution = distribution, battle = battle});
        }

        private object DistributeTroops(PlayerViewModel player)
        {
            var regionsWithAdditionalTroops = player.IADistributionTroops(regions);
            var regionsChanged = regionsWithAdditionalTroops.Keys;
            var troops = regionsWithAdditionalTroops.Values;
            var namePlayer = $"{player.Name} {player.Family.Name}";
            return new { namePlayer = namePlayer, regions = regionsChanged, troops = troops };
        }

        private List<object> AttackIA(PlayerViewModel player)
        {
            var objs = new List<object>();

            var response = player.Ataque(regions);

            while (response != null && response[0] != null && response[1] != null)
            {
                var attack = response[0];
                var defense = response[1];

                var atroops = (attack.Troops > 3) ? 3 : attack.Troops - 1;
                var resultBattle = Conquest.Battle(attack, atroops, defense);

                string color = null;
                if (defense.Troops < 1)
                {
                    defense.Player = attack.Player;
                    defense.Troops++;
                    attack.Troops--;
                    color = attack.Player.Family.Color;
                }

                var obj = new
                {
                    attackName = attack.Name,
                    attackTroops = attack.Troops,
                    defenseName = defense.Name,
                    defenseTroops = defense.Troops,
                    resultBattle = resultBattle.resultBattle,
                    color = color
                };

                objs.Add(obj);
                response = player.Ataque(regions);
            }
           

           return objs;
        }

    }
}