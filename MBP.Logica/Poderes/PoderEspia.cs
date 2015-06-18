using MBP.CapaTransversal.ModelsMVC;
using MBP.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBP.Logica
{
    public class PoderEspia : IPoder
    {
        /**
         * Retorna la pisicion de una nave de su adversario
         * 
         **/
        public RespuestaPoderModel activarEfectoPoder(int idPartida, int idJugador)
        {
            // Carga la partida para ver quien es el que llama la partida
            Partida partida = new ObtenerModelos().buscarPartida(idPartida);
            List<Tablero_Virtual> tablero;
            // Carga el tablero del jugador contrario
            if (partida.Jugador1_idCuenta == idJugador)
            {
                tablero = new ObtenerModelos().obtenerCasillasDeTablero(Constantes.tableroJugador2, idPartida);
            }
            else
            {
                tablero = new ObtenerModelos().obtenerCasillasDeTablero(Constantes.tableroJugador1, idPartida);
            }
            // Declara el metodo Random
            Random ran = new Random();
            int posicion;
            // Busca una casilla al azar que no este destruida
            while (true)    
            {
                posicion = ran.Next(tablero.Count);
                if(tablero[posicion].Destruido==false){ // Devuelve la primera casilla que encuentre y no este destruida
                    break;
                }
            }
            // Arma la respuesta del poder
            RespuestaPoderModel respuesta = new RespuestaPoderModel();
            respuesta.resultado = true;
            int [] xy = new int[2];
            xy[0] = tablero[posicion].x;
            xy[1] = tablero[posicion].y;
            respuesta.Espia = xy;
            return respuesta;
        }
    }
}
