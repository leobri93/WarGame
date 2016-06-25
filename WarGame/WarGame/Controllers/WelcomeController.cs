using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using WarGame.Models;
<<<<<<< HEAD
using WarGame.Helper;
=======
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
		
        [HttpPost]
        public ActionResult DoSubmit(string name, string family)
        {
            Objective obj = new Objective();

            ObjectiveModel objModel = obj.RafflingObjectives();

            PlayerViewModel player = new PlayerViewModel(name, family, objModel);

            bool success;
            if(player != null)
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