using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using WarGame.Models;
using WarGame.Models.Enum;
using WarGame.Helper;

namespace WarGame.Controllers
{
    public class MapController : Controller
    {

        private static readonly List<RegionViewModel> regions = Westeros.Map();

        public ActionResult Index(PlayerViewModel player)
        {
            ViewBag.Name = player.Name;
            ViewBag.Familiy = player.Family;
            return View();
        }

        [HttpGet]
        [Route("maps/regions")]
        public JsonResult Regions()
        {
            return Json(regions, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult DoSubmit(string name, string family)
        {
            Objective obj = new Objective();

            ObjectiveModel objModel = obj.RafflingObjectives();

            PlayerViewModel player = new PlayerViewModel(name, family, objModel);

            bool success;
            if (player != null)
            {
                success = true;
            }
            else
            {
                success = false;
            }

            return Content(JsonConvert.SerializeObject(new
            {
                Success = success,
                PlayerInfo = player

            }));
        }
    }
}