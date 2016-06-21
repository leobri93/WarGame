using System.Collections.Generic;
using System.Web.Mvc;
using WarGame.Helper;
using WarGame.Models;

namespace WarGame.Controllers
{
    public class MapController : Controller
    {

        private static readonly List<RegionViewModel> regions = Westeros.Map();

        [HttpGet]
        [Route("maps")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("maps/regions")]
        public JsonResult Regions()
        {
            return Json(regions, JsonRequestBehavior.AllowGet);
        }
    }
}