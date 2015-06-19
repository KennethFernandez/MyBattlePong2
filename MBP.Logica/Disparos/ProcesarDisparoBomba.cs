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
            actualizarPuntajesJugadores(tablero, resultado, partida);
            // Aumenta la cantidad de tiros exitosos 
            DisparoModel2 respuesta;
            if (resultado == Constantes.disparoExitoso)
            {
                respuesta = eliminarNave(casilla, tablero, partida, disparo);
            }
            else
            {
                respuesta = new MapperModelos().respuestaDisparoModel(partida, resultado, disparo.idJugador);
            }
            return respuesta;
        }

        /**
         * Coloca los campos de la nave en destruido y arma el objeto de respuesta del disparo
         * 
         **/

        public DisparoModel2 eliminarNave(Tablero_Virtual casilla, int tablero, Partida partida, DisparoModel disparo)
        {
            List<Tablero_Virtual> casillas = new ObtenerModelos().casillasSinDestruirNave(partida.idPartida, tablero, casilla.NumeroNave);
            List<int[]> casillasDestruidas = new List<int[]>();
            NaveDestruida(casilla,tablero,partida);
            actualizarPuntajesJugadores(tablero, casillas.Count, partida);
            int[] xy = new int[3];
            xy[0] = casilla.x;
            xy[1] = casilla.y;
            xy[2] = Constantes.disparoExitoso;
            casillasDestruidas.Add(xy);
            foreach (Tablero_Virtual item in casillas)
            {
                int[] xyTemp = new int[3];
                xyTemp[0] = item.x;
                xyTemp[1] = item.y;
                xyTemp[2] = Constantes.disparoExitoso;
                casillasDestruidas.Add(xyTemp);
            }
            DisparoModel2 resultado = new MapperModelos().respuestaDisparoModel(partida, Constantes.disparoExitoso, disparo.idJugador);
            resultado.casillas = casillasDestruidas;
            return resultado;
        }



        /**
         * Aumenta las estadisticas de los tiros
         * 
         * 
         * */
        private void actualizarPuntajesJugadores(int tablero, int cantidad, Partida partida)
        {
            for (int i = 0; i < cantidad; i++)
            {
                if (tablero == 1)
                {
                    partida.DisparosExitososJugador2++;
                    partida.DisparosTotalesJugador2++;                       // Aumenta la cantidad de disparos del jugador 2
                }
                else
                {
                    partida.DisparosExitososJugador1++;
                    partida.DisparosTotalesJugador1++;                       // Aumenta la cantidad de disparos del jugador 2
                }
            }
        }
    }
}
