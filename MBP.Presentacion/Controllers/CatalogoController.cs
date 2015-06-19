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

            FachadaServicio servicio = new FachadaServicio();
            List<string> lista = servicio.obtenerListaNombreNaves();
            ViewBag.ListaNave = lista;
            NaveModel model = servicio.obtenerNave(lista.First());

            return View(model);
        }

        public string RefrescarNaves(string nombre)
        {
            FachadaServicio servicio = new FachadaServicio();
            NaveModel model = servicio.obtenerNave(nombre);

            string ListaDatos = model.nombre + "," + model.puntaje + "," + model.tamanoX + "," + model.tamanoY + "," + model.imagen + "," + model.estado;


            return ListaDatos;
        }

        [HttpPost]
        public ActionResult Catalogo(NaveModel model)
        {
            NaveModel modelo2 = new NaveModel();
            FachadaServicio fachada = new FachadaServicio();
            List<string> lista = fachada.obtenerListaNombreNaves();
            ViewBag.ListaNave = lista;
            modelo2 = fachada.obtenerNave(lista.First());
            if (Request.Form["Crear"] != null)
            {
                // Code for function 1
                fachada.agregarNave(model);

                
                return View(modelo2);
            }
            else if (Request.Form["Modificar"] != null)
            {
                // code for function 2
                fachada.modificarNave(model);
                return View(modelo2);
            }

            

            return View(modelo2);
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