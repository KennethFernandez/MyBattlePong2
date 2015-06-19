using MBP.CapaTransversal.ModelsMVC;
using MBP.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBP.Logica
{
    public class PoderTiroExtra : IPoder
    {
        /**
         * Aumenta in tiro extra en el turno en que se encuentra
         * 
         **/

        public RespuestaPoderModel activarEfectoPoder(int idPartida, int idJugador)
        {
            Partida partida = new ObtenerModelos().buscarPartida(idPartida);
            partida.DisparosRestantes++;                //Aumenta en 1 los disparos restantes del jugador en el turno
            RespuestaPoderModel respuesta = new RespuestaPoderModel();
            respuesta.resultado= new ModificarModelos().actualizarPartida(partida);
            respuesta.disparosRestantes = partida.DisparosRestantes;
            return respuesta;
        }
    }
}
