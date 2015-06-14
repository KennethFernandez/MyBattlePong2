using MBP.Datos;
using MBP.EjeVertical;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBP.Logica
{
    public class ProcesarDisparo
    {
        public RespuestaDisparoModel procesarDisparo(DisparoModel disparo)
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
            Partida partida = new ObtenerModelos().buscarPartida(disparo.idPartida);
            RespuestaDisparoModel respuesta = new MapperModelos().respuestaDisparoModel(partida, resultado);
            return respuesta;
        }
    }
}
