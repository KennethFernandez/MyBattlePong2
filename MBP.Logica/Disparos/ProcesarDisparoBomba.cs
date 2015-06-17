using MBP.CapaTransversal.ModelsMVC;
using MBP.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBP.Logica
{
    public class ProcesarDisparoBomba : IEstrategiaDisparo
    {
        Partida partida;
        public int procesarDisparoOnline(DisparoModel disparo)
        {
            partida = new ObtenerModelos().buscarPartida(disparo.idPartida);
            int resultado = 0; // Resultado de la partida
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
                resultado = this.procesarDisparoBomba(disparo, tablero); // Procesa el disparo en el tablero 2
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
                resultado = this.procesarDisparoBomba(disparo, tablero); // Procesa el disparo en el tablero 1
            }
            else
            {
                resultado = Constantes.disparoNoEsSuTurno; // Notofica que el jugador no esta en su turno
            }
            new ModificarModelos().actualizarPartida(partida); // Actualiza el modelo de la partida en la base de datos
            return resultado;
        }

        private int procesarDisparoBomba(DisparoModel disparo, int tablero)
        {
            return 0;
        }
    }
}
