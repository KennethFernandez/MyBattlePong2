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

        int idPartida = 565;
        int idJugador = 6;

        [HttpGet]
        public ActionResult Jugar()
        {
            Debug.Write("------------------------ "+idPartida+" ------------------------------------------");
            Session["tipoDisparo"] = 1;
            Session["dirDisparo"] = 1;
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

        public string Disparo(int x, int y)
        {
            int tipo;
            // Recupera los datos de la sesion para conocer el tipo
            bool result = Int32.TryParse(Session["tipoDisparo"].ToString(), out tipo);
            if (false == result)
            {
                tipo = 1;
            }
            int dir;
            result = Int32.TryParse(Session["dirDisparo"].ToString(), out dir);
            if (false == result)
            {
                dir = 1;
            }
            //Reinicia los valores de la sesion para el siguiente disparo
            Session["tipoDisparo"] = 1;
            Session["dirDisparo"] = 1;


            Debug.Write("x: " + x + " y: " + y + "tipo: " + tipo + "dir: " + dir);
            DisparoModel disparo = new DisparoModel();
            disparo.x = x;
            disparo.y = y;
            disparo.tipoDisparo = tipo;
            disparo.idPartida = idPartida;
            disparo.idJugador = idJugador;
            disparo.dir = dir;
            DisparoModel2 resultado = new FachadaServicio().disparo(disparo);
            string respuesta = "";
            if (resultado != null)
            {
                if (tipo == 1)
                {
                    respuesta += resultado.resultado + ",";
                    respuesta += resultado.turnosRestantes + ",";
                    respuesta += resultado.puntajeJugadorActual + ",";
                    respuesta += resultado.esSuTurno ? "t," : "f,";
                    respuesta += resultado.finalPartida;
                }
                else
                {
                    respuesta += resultado.resultado + ",";
                    respuesta += resultado.turnosRestantes + ",";
                    respuesta += resultado.puntajeJugadorActual + ",";
                    respuesta += resultado.esSuTurno ? "t," : "f,";
                    respuesta += resultado.finalPartida + ",";
                    foreach (int[] item in resultado.casillas)
                    {
                        respuesta += item[0]+ ",";
                        respuesta += item[1]+ ",";
                        respuesta += item[2]+ ",";
                    }
                }
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

        public string ActivarPoderDisparo(int idPoder)
        {
            switch (idPoder)
            {
                case 6:
                    Session["tipoDisparo"] = 2;
                    break;
                case 7:
                    Session["tipoDisparo"] = 3;
                    break;
                case 8:
                    Session["tipoDisparo"] = 4;
                    break;
                default:
                    Session["tipoDisparo"] = 1;
                    break;
            }
            return "True";
        }

        public string DireccionDisparo(int dir)
        {
            Session["dirDisparo"] = dir;
            return "True";
        }

        public string rendirse()
        {
            bool resultado = new FachadaServicio().rendirse(idJugador,idPartida);
            return resultado.ToString();
        }

    }
}
