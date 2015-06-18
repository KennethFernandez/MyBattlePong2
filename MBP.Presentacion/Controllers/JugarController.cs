using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MBP.Presentacion.Controllers
{
    public class JugarController : Controller
    {
        //
        // GET: /Jugar/

        [HttpGet]
        public ActionResult Jugar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Jugarw()
        {
            return View();
        }

        [HttpGet]
        public ActionResult DataNave()
        {
            var person = new int[]{2,2,2};
            return Json(person, JsonRequestBehavior.AllowGet);
        }


    }
}
