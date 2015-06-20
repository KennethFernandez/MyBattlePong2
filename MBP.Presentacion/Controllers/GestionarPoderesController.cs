using MBP.CapaTransversal.ModelsMVC;
using MBP.Servicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBattlePong2.Controllers
{
    public class GestionarPoderesController : Controller
    {
        // GET: GestionarPoderes
        [HttpGet]
        public ActionResult GestionarPoderes()
        {
            FachadaServicio servicio = new FachadaServicio();
            List<string> lista = servicio.obtenerListaPoderes();
            ViewBag.ListaPoder = lista;
            PoderModel model = servicio.obtenerPoder(lista.First());
            return View(model);
        }

        public string RefrescarPoderes(string nombre)
        {
            FachadaServicio servicio = new FachadaServicio();
            PoderModel model = servicio.obtenerPoder(nombre);

            string ListaDatos = model.Experiencia + "," + model.Victorias + "," + model.Puntos + "," + model.Derrotas + "," + model.Ranking;


            return ListaDatos;
        }

        [HttpPost]
        public ActionResult GestionarPoderes(PoderModel model)
        {
            FachadaServicio fachada = new FachadaServicio();
            List<string> lista = fachada.obtenerListaPoderes();
            ViewBag.ListaPoder = lista;
            PoderModel modelo2 = fachada.obtenerPoder(lista.First());
            fachada.modificarPoder(model);
            return View(modelo2);
        }
    }
}