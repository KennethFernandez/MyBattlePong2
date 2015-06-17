using MBP.CapaTransversal.ModelsMVC;
using MBP.Servicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MBP.Presentacion.Controllers
{
    public class BuscarController : Controller
    {
        // GET: Buscar
        [HttpGet]
        public ActionResult Buscar()
        {
            List<PartidaModel2> partidas = new FachadaServicio().partidasDisponiblesOnline(); 
            return View(partidas);
        }

        [HttpPost]
        public ActionResult Buscar2()
        {
            ///List<PartidaModel> partidas = new FachadaServicio().partidasDisponiblesOnline();
            return View();
        }

    }
}
