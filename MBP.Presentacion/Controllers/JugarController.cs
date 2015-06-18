using MBP.CapaTransversal.ModelsMVC;
using MBP.Servicio;
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

        [HttpPost]
        public ActionResult Jugarw()
        {
            return View();
        }

        public string DataNave()
        {

            TableroModel2 tablero = new FachadaServicio().recuperarTableroPartida(361, 2);
            string concatenado = tablero.disparosRestantes.ToString() + ",";
            return "3";
        }

        public string DatosGenerales()
        {

            TableroModel2 tablero = new FachadaServicio().recuperarTableroPartida(361, 2);
            string concatenado = tablero.disparosRestantes.ToString() + ",";
            concatenado += tablero.enMiTurno ? "t," : "f,";
            concatenado += tablero.puntosLocal.ToString();
            return concatenado;
        }


    }
}
