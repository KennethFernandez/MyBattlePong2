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

    }
}
