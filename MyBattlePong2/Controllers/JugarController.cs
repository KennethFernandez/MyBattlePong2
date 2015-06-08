using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBattlePong2.Controllers
{
    public class JugarController : Controller
    {

        [HttpGet]
        public ActionResult Jugar()
        {
            return View();
        }

    }
}