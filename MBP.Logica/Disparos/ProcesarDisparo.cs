using MBP.CapaTransversal.ModelsMVC;
using MBP.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBP.Logica
{
    public class ProcesarDisparo
    {
        public DisparoModel2 procesarDisparo(DisparoModel disparo)
        {
            IEstrategiaDisparo procesadorDisparo;
            switch (disparo.tipoDisparo)
            {
                case 1:
                    procesadorDisparo = new ProcesarDisparoSimple();
                    break;
                case 2:
                    procesadorDisparo = new ProcesarDisparoBomba();
                    break;
                case 3:
                    procesadorDisparo = new ProcesarDisparo_1V();
                    break;
                case 4:
                    procesadorDisparo = new ProcesarDisparo_1H();
                    break;
                default:
                    procesadorDisparo = new ProcesarDisparoSimple();
                    break;
            }
            int resultado = procesadorDisparo.procesarDisparoOnline(disparo);
            ObtenerModelos obtener = new ObtenerModelos();
            Partida partida = new ObtenerModelos().buscarPartida(disparo.idPartida);

            // Verifica si algun tablero se quedo sin naves
            int navesTab1 = obtener.navesSinDestruir(disparo.idPartida, Constantes.tableroJugador1);
            int navesTab2 = obtener.navesSinDestruir(disparo.idPartida, Constantes.tableroJugador2);
            if (navesTab1 == 0)
            {
                resultado = Constantes.disparoFinal;
                new FinalizarPartida().finalizarPartida(partida.idPartida, 2);
            }
            else if (navesTab2 == 0)
            {
                resultado = Constantes.disparoFinal;
                new FinalizarPartida().finalizarPartida(partida.idPartida, 1);
            }
            DisparoModel2 respuesta = new MapperModelos().respuestaDisparoModel(partida, resultado);
            return respuesta;
        }
    }
}
