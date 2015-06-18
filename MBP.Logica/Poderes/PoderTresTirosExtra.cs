using MBP.CapaTransversal.ModelsMVC;
using MBP.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBP.Logica
{
    public class PoderTresTirosExtra : IPoder
    {
        /**
         * Aumenta en 3 los disparos restantes del turno actual del jugador
         * 
         **/

        public RespuestaPoderModel activarEfectoPoder(int idPartida, int idJugador)
        {
            Partida partida = new ObtenerModelos().buscarPartida(idPartida);
            partida.DisparosRestantes+=3;
            RespuestaPoderModel respuesta = new RespuestaPoderModel();
            respuesta.resultado = new ModificarModelos().actualizarPartida(partida);
            return respuesta;
        }
    }
}
