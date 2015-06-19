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
    public class JugarController : Controller
    {
        //
        // GET: /Jugar/

        int idPartida = 386;
        int idJugador = 6;

        [HttpGet]
        public ActionResult Jugar()
        {
            IList<PoderModel2> poderes = new FachadaServicio().poderesDeJugador(idJugador);
            return View(poderes);
        }

        [HttpPost]
        public ActionResult Termino()
        {

            return RedirectToAction("Buscar", "Buscar"); ;
        }

        public string DataNave()
        {

            TableroModel2 tablero = new FachadaServicio().recuperarTableroPartida(idPartida, idJugador);
            string respuesta = "";

            foreach (CasillaModel2 item in tablero.tableroJugador)
            {
                respuesta += item.X + ",";
                respuesta += item.Y + ",";
                respuesta += item.mas_X + ",";
                respuesta += item.mas_Y +",";
                respuesta += item.imagen +",";
            }
            return respuesta;
        }

        public string DatosGenerales()
        {

            TableroModel2 tablero = new FachadaServicio().recuperarTableroPartida(idPartida, idJugador);
            string concatenado = tablero.disparosRestantes.ToString() + ",";
            concatenado += tablero.enMiTurno ? "t," : "f,";
            concatenado += tablero.puntosLocal.ToString();
            return concatenado;
        }

        public bool PasarTurno()
        {

            bool valor = new FachadaServicio().pasarTurnoPartida(idPartida);
           return valor;
            
        }

        public string Disparo(int x, int y, int tipo)
        {

            Debug.Write("x: "+x+" y: "+y+"tipo: "+tipo);

            DisparoModel disparo = new DisparoModel();
            disparo.x = x;
            disparo.y = y;
            disparo.tipoDisparo = tipo;
            disparo.idPartida = idPartida;
            disparo.idJugador = idJugador;
            DisparoModel2 resultado = new FachadaServicio().disparo(disparo);
            string respuesta = "";
            if (resultado != null)
            {
                respuesta += resultado.resultado + ",";
                respuesta += resultado.turnosRestantes + ",";
                respuesta += resultado.puntajeJugadorActual + ",";
                respuesta += resultado.esSuTurno? "t," : "f,";
                respuesta += resultado.finalPartida;
            }
            return respuesta;

        }

        public string DesbloquearPoderes()
        {
            IList<PoderModel2> poderes = new FachadaServicio().desbloquearPoderes(idJugador);
            string resultado = "Has desbloqueado la habilidad: ";
            foreach (PoderModel2 item in poderes)
            {
                resultado += (item.nombre+" \n");
            }
            return resultado;
        }


        public string ActivarPoderSencillo(int idPoder)
        {
            RespuestaPoderModel resultado = new FachadaServicio().activarPoder(idJugador,idPartida,idPoder);
            string respuesta = resultado.resultado.ToString();
            if(idPoder == 4){
                respuesta += ","+resultado.Espia[0] + "," + resultado.Espia[1];
            }
            else
            {
                respuesta += "," + resultado.disparosRestantes;
            }
            return respuesta;
        }

        public string rendirse()
        {
            bool resultado = new FachadaServicio().rendirse(idJugador,idPartida);
            return resultado.ToString();
        }

    }
}
