using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace WarGame.Controllers
{
    public class WelcomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DoSubmit()
        {

            return Content(JsonConvert.SerializeObject(new
            {
                Success = "Feriado não foi cadastrado"
            }));
        }
    }
}