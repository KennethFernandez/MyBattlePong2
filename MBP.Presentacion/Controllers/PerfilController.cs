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
    public class PerfilController : Controller
    {
        // GET: Perfil
        [HttpGet]
        public ActionResult Perfil(){

            UsuarioModel model = Session["usuario"] as UsuarioModel;
            ViewBag.tipo = model.datos[1, 1];
            Debug.WriteLine("tipo " + ViewData["tipo"]);
            ViewData["usuario"] = model.datos[2, 1];
            ViewData["nombre"] = model.datos[3, 1];
            ViewData["apellido"] = model.datos[4, 1];
            ViewData["email"] = model.datos[5, 1];
            ViewData["Fecha Inscripcion"] = model.datos[6, 1];
            if (model.datos[1, 1] != "3")
            {
                ViewData["pais"] = model.datos[10, 1];
                ViewData["fecha nacimiento"] = model.datos[7, 1];
                ViewData["compartido"] = model.datos[11, 1];
                if (model.datos[8, 1] == "M")
                {
                    ViewData["genero"] = "Masculino";
                }
                else
                {
                    ViewData["genero"] = "Femenino";
                }
                if (model.datos[1, 1] == "1")
                {
                    ViewData["PartidasGanadas"] = model.datos[12, 1];
                    ViewData["GanadasPerdidas"] = model.datos[13, 1];
                    ViewData["PorcentajePartidas"] = model.datos[14, 1];
                    ViewData["TotalDisparos"] = model.datos[15, 1];
                    ViewData["AcertadosFallados"] = model.datos[16, 1];
                    ViewData["PorcentajeDisparos"] = model.datos[17, 1];
                    ViewData["PuntoGanados"] = model.datos[18, 1];
                    ViewData["PorcentajePuntoGanados"] = model.datos[19, 1];
                }
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Perfil(UsuarioModel model)
        {

            return View();

        }



    }
}