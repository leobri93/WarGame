using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using WarGame.Models;
using WarGame.Helper;
using WarGame.Models.Enum;

namespace WarGame.Controllers
{
    public class WelcomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Families = Enum.GetNames(typeof(Family)).Select(e => new SelectListItem { Text = e });
            return View();
        }
    }
}