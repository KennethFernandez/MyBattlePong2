using System;
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

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file)
        {

            file.SaveAs("e:\\" + file.FileName);

            return Json(new
            {
                Success = true,
                FileName = file.FileName,
                FileSize = file.ContentLength
            }, JsonRequestBehavior.AllowGet);
        }
    }

    
}