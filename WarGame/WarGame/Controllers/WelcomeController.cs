using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using WarGame.Models;

namespace WarGame.Controllers
{
    public class WelcomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DoSubmit(string name, string family)
        {
            PlayerViewModel player = new PlayerViewModel(name, family);

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