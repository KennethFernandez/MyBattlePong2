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
    public class CatalogoController : Controller
    {
        [HttpGet]
        public ActionResult Catalogo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Catalogo(NaveModel model)
        {

            Debug.WriteLine("estado: ," + model.estado);
            Debug.WriteLine("foto: ," + model.imagen);
            Debug.WriteLine("nombre: ," + model.nombre);
            Debug.WriteLine("puntaje: ," + model.puntaje);
            Debug.WriteLine("tamX: ," + model.tamanoX);
            Debug.WriteLine("tamY: ," + model.tamanoY);
            FachadaServicio fachada = new FachadaServicio();
            Debug.WriteLine(fachada.agregarNave(model));
            return View();

            
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file)
        {

            file.SaveAs("d:\\" + file.FileName);

            return Json(new
            {
                Success = true,
                FileName = file.FileName,
                FileSize = file.ContentLength
            }, JsonRequestBehavior.AllowGet);
        }
    }

    
}