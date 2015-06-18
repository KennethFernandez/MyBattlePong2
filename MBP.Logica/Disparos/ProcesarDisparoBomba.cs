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
        /**
         * Verifica si la casilla que se destruyo era la ultima de una nave
         * 
         **/

        private bool NaveDestruida(Tablero_Virtual casilla, int tablero, Partida partida)
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




        /**
         * Procesa el disparo en el tablero asignado
         * 
         **/

        public DisparoModel2 procesarDisparoTablero(DisparoModel disparo, int tablero, Partida partida)
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
            // Aumenta la cantidad de tiros exitosos 
            if (resultado == Constantes.disparoExitoso)
                this.actualizarPuntajesJugadores(tablero, resultado, partida);
            DisparoModel2 respuesta = new MapperModelos().respuestaDisparoModel(partida, resultado);
            return respuesta;
        }



        /**
         * Aumenta las estadisticas de los tiros
         * 
         * 
         * */
        private void actualizarPuntajesJugadores(int tablero, int resultado, Partida partida)
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
