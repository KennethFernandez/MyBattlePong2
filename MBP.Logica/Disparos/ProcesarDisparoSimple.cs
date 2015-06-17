using MBP.CapaTransversal.ModelsMVC;
using MBP.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBP.Logica
{
    public class ProcesarDisparoSimple : IEstrategiaDisparo
    {
        Partida partida;
        public bool ProcesarDisaproLive(int numVaso, int idDispositivo)
        {
            // Verifica un disparo
            if ((numVaso >= 0) && (idDispositivo >= 0))
            {
                return true;
            }
            // Anuncia precencia
            else
            {
                return new GestionarDispositivos().actualizarDispositivo(idDispositivo);
            }
        }



        /**
         * Procesa un disparo simple hacia el tablero
         * 
         * 
         **/

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
                resultado = this.procesarDisparoTablero(disparo, tablero); // Procesa el disparo en el tablero 2
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
                resultado = this.procesarDisparoTablero(disparo, tablero); // Procesa el disparo en el tablero 1
            }
            else
            {
                resultado = Constantes.disparoNoEsSuTurno; // Notofica que el jugador no esta en su turno
            }
            new ModificarModelos().actualizarPartida(partida); // Actualiza el modelo de la partida en la base de datos
            return resultado;
        }



        /**
         * Verifica si la casilla que se destruyo era la ultima de una nave
         * 
         **/

        private bool siNaveDestruida(Tablero_Virtual casilla, int tablero)
        {
            int cantidadCasillas = new ObtenerModelos().consultarSiNaveDestruida(casilla.NumeroNave, casilla.Partida_idPartida, tablero);
            if (cantidadCasillas == 0) // Verifica que la nave no tengo mas casillas en no destruido
            {
                Nave nave = new ObtenerModelos().obtieneNave(casilla.Nave_idNave);  // Obtiene el tipo de nave destruido
                if (tablero == Constantes.tableroJugador2)
                {
                    partida.PuntajeJugador1 += nave.Puntaje;                        // Aumenta los puntos al jugador 1
                }
                else
                {
                    partida.PuntajeJugador2 += nave.Puntaje;                        // Aumenta los puntos al jugador 2
                }
                return true;
            }
            else
            {
                return false;
            }
        }




        /**
         * Procesa el disparo en el tablero asignado
         * 
         **/

        private int procesarDisparoTablero(DisparoModel disparo, int tablero)
        {
            // Carga la casilla de las posiciones
            int resultado;
            Tablero_Virtual casilla = new ObtenerModelos().obtenerCasillaTablero(tablero, disparo.idPartida, disparo.x, disparo.y);
            if (casilla != null)                        // Verifica si la casilla existe
            {
                if (!casilla.Destruido)                 // Consulta si la casilla ya esta destruida
                {
                    if (casilla.Poder > 0)              // Verifica si la casilla contiene algun escudo
                    {
                        casilla.Poder--;                // Elimina el poder de la casilla
                        resultado = Constantes.disparoEscudo; // Notifica que el disparo fue en un escudo
                    }
                    else
                    {
                        casilla.Destruido = true;
                        resultado = Constantes.disparoExitoso;  // Notifica que el disparo fue exitoso
                    }
                }
                else
                {
                    resultado = Constantes.disparoFallido;  // Notifica que el disparo fue fallido
                }
            }
            else
            {
                resultado = Constantes.disparoFallido;  // Notifica que el disparo fue fallido
            }
            new ModificarModelos().actualizarCasilla(casilla, tablero);
            // Verifica si la nave fue destruida y aumenta los puntaje
            this.siNaveDestruida(casilla, tablero);
            // Aumenta la cantidad de tiros exitosos 
            this.actualizarPuntajesJugadores(tablero, resultado);
            return resultado;
        }



        /**
         * Aumenta las estadisticas de los tiros
         * 
         * 
         * */
        public void actualizarPuntajesJugadores(int tablero, int resultado)
        {
            if (tablero == 1)
            {
                if (resultado == Constantes.disparoExitoso)
                {
                    partida.DisparosExitososJugador2++;
                }
                partida.DisparosTotalesJugador2++;                       // Aumenta la cantidad de disparos del jugador 2
            }
            else
            {
                if (resultado == Constantes.disparoExitoso)
                {
                    partida.DisparosExitososJugador1++;
                }
                partida.DisparosTotalesJugador1++;                       // Aumenta la cantidad de disparos del jugador 2
            }
        }
    }
}
