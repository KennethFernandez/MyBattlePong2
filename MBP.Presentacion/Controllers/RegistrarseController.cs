using MBP.CapaTransversal.ModelsMVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBattlePong2.Controllers
{
    public class RegistrarseController : Controller
    {
        // GET: Registrarse
         [HttpGet]
        public ActionResult Registrarse()
        {
            TipoUsuarioModel tipo = new TipoUsuarioModel();
            ViewBag.CategoryID = tipo.TypeList;
            return View();
        }

         [HttpPost]
         public ActionResult Registrarse(CompositeRegModel model)
        {

            if (ModelState.IsValid )
            {
               
                return (model.ModeloBase.PasswordConf ==  model.ModeloBase.Password) ?
                        RedirectToAction("Inicio", "Inicio") : RedirectToAction("Registrarse", "Registrarse");
            }

            return View();
        }

         [HttpPost]
         public ActionResult Upload(HttpPostedFileBase file)
         {

             file.SaveAs("e:\\Perfil\\" + file.FileName);

             return Json(new
             {
                 Success = true,
                 FileName = file.FileName,
                 FileSize = file.ContentLength
             }, JsonRequestBehavior.AllowGet);
         }


    }
}