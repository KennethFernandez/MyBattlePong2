
using MBP.CapaTransversal.ModelsMVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBP.Logica
{
    public class PoderNull : IPoder
    {
        public RespuestaPoderModel activarEfectoPoder(int idPartida, int idJugador)
        {
            RespuestaPoderModel respuesta = new RespuestaPoderModel();
            respuesta.disparosRestantes = 0;
            return respuesta;;
        }
    }
}
