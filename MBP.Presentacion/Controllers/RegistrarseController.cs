using MBP.CapaTransversal.ModelsMVC;
using MBP.Servicio;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MBP.Presentacion.Controllers
{
    public class RegistrarseController : Controller
    {
        // GET: Registrarse
         [HttpGet]
        public ActionResult Registrarse()
        {
            var model = new CompositeRegModel();

             
            model.ModeloBase = new RegistrarseModel();
            model.ModeloExt = new RegistrarseExtModel();
            model.ModeloJugador = new JugadorModel();
            model.ModeloModerador = new ModeradorModel();
            TipoUsuarioModel tipo = new TipoUsuarioModel();
            FachadaServicio servicio = new FachadaServicio();
            ViewBag.Lista = servicio.obtenerListaPaises();
            ViewBag.CategoryID = tipo.TypeList;
            return View(model);
        }

         [HttpPost]
         public ActionResult Registrarse(CompositeRegModel model)
        {


            //HttpPostedFileBase file = (HttpPostedFileBase)Session["imagen"];
            //file.SaveAs("d:\\Perfil\\" + file.FileName);
            Debug.WriteLine("tipoooooooooooooooooooooooooooooo: ");
            if (model.ModeloBase.PasswordConf == model.ModeloBase.Password)
            {
                Debug.WriteLine("igueleeees");
                FachadaServicio fachada = new FachadaServicio();
                if (fachada.agregarNuevoUser(model) == true)
                {
                    Debug.WriteLine("Bien");
                }
                else {
                    Debug.WriteLine("Error");
                }
                return RedirectToAction("Inicio", "Inicio");
            }
            else
            {
                Debug.WriteLine("direfenteeeees");
                return RedirectToAction("Registrarse", "Registrarse");
            }
            
        }

         [HttpPost]
         public ActionResult Upload(HttpPostedFileBase file)
         {

             
             Session["imagen"] = file;
             file.SaveAs("d:\\Perfil\\" + file.FileName);
             return Json(new
             {
                 Success = true,
                 FileName = file.FileName,
                 FileSize = file.ContentLength
             }, JsonRequestBehavior.AllowGet);
         }


    }
}