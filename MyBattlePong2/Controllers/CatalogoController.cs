﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBattlePong2.Controllers
{
    public class CatalogoController : Controller
    {
        [HttpGet]
        public ActionResult Catalogo()
        {
            return View();
        }
    }
}