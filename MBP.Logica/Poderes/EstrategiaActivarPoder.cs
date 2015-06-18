using MBP.CapaTransversal.ModelsMVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBP.Logica
{
    public class EstrategiaActivarPoder
    {
        public RespuestaPoderModel activarEfectoPoder(int idPartida, int idJugador, int idPoder)
        {
            IPoder estrategiaPoder;
            switch (idPoder)
            {
                case 1:
                    estrategiaPoder = new PoderTiroExtra();
                    break;
                case 2:
                    estrategiaPoder = new PoderTresTirosExtra();
                    break;
                case 3:
                    estrategiaPoder = new PoderTiroExtraTurno();
                    break;
                case 4:
                    estrategiaPoder = new PoderEspia();
                    break;
                case 9:
                    estrategiaPoder = new PoderSalvavidas();
                    break;
                case 10:
                    estrategiaPoder = new PoderAntiescudo();
                    break;
                default:
                    estrategiaPoder = new PoderNull();
                    break;
            }
            return estrategiaPoder.activarEfectoPoder(idPartida, idJugador);
        }
    }
}
