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

            Partida partida = new ObtenerModelos().buscarPartida(disparo.idPartida);

            if (partida != null)
            {
                DisparoModel2 resultado = procesarDisparoOnline(disparo, partida, procesadorDisparo);

                ObtenerModelos obtener = new ObtenerModelos();
                // Verifica si algun tablero se quedo sin naves
                int navesTab1 = obtener.navesSinDestruir(disparo.idPartida, Constantes.tableroJugador1);
                int navesTab2 = obtener.navesSinDestruir(disparo.idPartida, Constantes.tableroJugador2);
                if (navesTab1 == 0)
                {
                    resultado.finalPartida = true;
                    new FinalizarPartida().finalizarPartida(partida.idPartida, 2);
                }
                else if (navesTab2 == 0)
                {
                    resultado.finalPartida = true;
                    new FinalizarPartida().finalizarPartida(partida.idPartida, 1);
                }
                return resultado;
            }
            else
            {
                DisparoModel2 resultado = new DisparoModel2();
                resultado.finalPartida = true;
                return resultado;
            }
        }

        private DisparoModel2 procesarDisparoOnline(DisparoModel disparo, Partida partida, IEstrategiaDisparo estrategia)
        {
            partida = new ObtenerModelos().buscarPartida(disparo.idPartida);
            DisparoModel2 resultado; // Resultado de la partida
            int tablero;
            // Verifica cual jugador es el que realiza el disparo
            if (partida.Jugador1_idCuenta == disparo.idJugador && partida.TurnoActual)  // Disparo lo realiza el jugador 1
            {
                tablero = Constantes.tableroJugador2;
                if (partida.DisparosRestantes == 1)     // Cambia de turno si es necesario
                {
                    partida.TurnoActual = !partida.TurnoActual;
                    partida.DisparosRestantes = partida.DisparosJugador2;
                }
                else
                {
                    partida.DisparosRestantes--;
                }
                resultado = estrategia.procesarDisparoTablero(disparo, tablero,partida); // Procesa el disparo en el tablero 2
            }
            else if (partida.Jugador2_idCuenta == disparo.idJugador && !partida.TurnoActual) // Disparo lo realiza el jugador 2
            {
                tablero = Constantes.tableroJugador1;
                if (partida.DisparosRestantes == 1) // Cambia de turno si es necesario
                {
                    partida.TurnoActual = !partida.TurnoActual;
                    partida.DisparosRestantes = partida.DisparosJugador1;
                }
                else
                {
                    partida.DisparosRestantes--; // Resta un turno a la partida
                }
                resultado = estrategia.procesarDisparoTablero(disparo, tablero, partida); // Procesa el disparo en el tablero 1
            }
            else
            {
                resultado = null; // Notifica que el jugador no esta en su turno
            }
            new ModificarModelos().actualizarPartida(partida); // Actualiza el modelo de la partida en la base de datos
            return resultado;
        }
    }
}
