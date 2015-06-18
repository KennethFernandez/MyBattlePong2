using MBP.CapaTransversal.ModelsMVC;
using MBP.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBP.Logica
{
    public class PoderSalvavidas : IPoder
    {
        /**
         * Crea un nave de 1x1 en una casilla en la cual no exista ni disparo ni nave creada previamnete
         **/
        public RespuestaPoderModel activarEfectoPoder(int idPartida, int idJugador)
        {
            // Falta de implementar

            Partida partida = new ObtenerModelos().buscarPartida(idPartida);
            RespuestaPoderModel respuesta = new RespuestaPoderModel();
            respuesta.resultado = true;
            return respuesta;
        }
    }
}
