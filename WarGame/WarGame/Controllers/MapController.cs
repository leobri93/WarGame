using System.Web.Mvc;
using WarGame.Helper;
using WarGame.Models;

namespace WarGame.Controllers
{
    public class MapController : Controller
    {

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
            var regions = Westeros.Map();
            return Json(regions, JsonRequestBehavior.AllowGet);
        }
    }
}