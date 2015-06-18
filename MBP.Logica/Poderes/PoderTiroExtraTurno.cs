using MBP.CapaTransversal.ModelsMVC;
using MBP.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBP.Logica
{
    public class PoderTiroExtraTurno : IPoder
    {
        /**
         * Aumenta un disapro extra por turno turno al jugador y uno en el turno actual.
         * 
         **/
        public RespuestaPoderModel activarEfectoPoder(int idPartida, int idJugador)
        {
            Partida partida = new ObtenerModelos().buscarPartida(idPartida);
            if (partida.Jugador1_idCuenta == idJugador)
            {
                partida.DisparosJugador1++;
            }
            else
            {
                partida.DisparosJugador2++;
            }
            partida.DisparosRestantes++;
            RespuestaPoderModel respuesta = new RespuestaPoderModel();
            respuesta.resultado = new ModificarModelos().actualizarPartida(partida);
            return respuesta;
        }
    }
}
