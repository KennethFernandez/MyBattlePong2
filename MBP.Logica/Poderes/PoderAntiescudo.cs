using MBP.CapaTransversal.ModelsMVC;
using MBP.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBP.Logica
{
    public class PoderAntiescudo : IPoder
    {
        public RespuestaPoderModel activarEfectoPoder(int idPartida, int idJugador)
        {
            Partida partida = new ObtenerModelos().buscarPartida(idPartida);
            if (partida.Jugador1_idCuenta == idJugador)
            {
                partida.AntiEscudo1 = true;
            }
            else
            {
                partida.AntiEscudo2 = true;
            }
            RespuestaPoderModel respuesta = new RespuestaPoderModel();
            respuesta.resultado = new ModificarModelos().actualizarPartida(partida);
            respuesta.disparosRestantes = partida.DisparosRestantes;
            return respuesta;
        }
    }
}
