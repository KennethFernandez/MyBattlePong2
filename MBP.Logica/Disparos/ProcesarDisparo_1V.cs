using MBP.CapaTransversal.ModelsMVC;
using MBP.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBP.Logica
{
    public class ProcesarDisparo_1V : IEstrategiaDisparo
    {
        public DisparoModel2 procesarDisparoTablero(DisparoModel disparo, int tablero, Partida partida)
        {
            int resDisparo = procesarDisparoTableroAux(disparo, tablero, partida);
            DisparoModel2 respuesta;
            if (resDisparo != Constantes.disparoExitoso)
            {
                int[] xy1 = new int[3];
                xy1[0] = disparo.x;
                xy1[1] = disparo.y;
                xy1[2] = resDisparo;
                disparo.y += disparo.dir;
                resDisparo = procesarDisparoTableroAux(disparo, tablero, partida);
                int[] xy2 = new int[3];
                xy2[0] = disparo.x;
                xy2[1] = disparo.y;
                xy2[2] = resDisparo;
                List<int[]> casillas = new List<int[]>();
                casillas.Add(xy1);
                casillas.Add(xy2);
                respuesta = new MapperModelos().respuestaDisparoModel(partida, resDisparo, disparo.idJugador);
                respuesta.casillas = casillas;
            }
            else
            {
                int[] xy1 = new int[3];
                xy1[0] = disparo.x;
                xy1[1] = disparo.y;
                xy1[2] = resDisparo;
                List<int[]> casillas = new List<int[]>();
                casillas.Add(xy1);
                respuesta = new MapperModelos().respuestaDisparoModel(partida, resDisparo, disparo.idJugador);
                respuesta.casillas = casillas;
            }
            return respuesta;
        }

        public int procesarDisparoTableroAux(DisparoModel disparo, int tablero, Partida partida)
        {
            // Carga la casilla de las posiciones
            int resultado = Constantes.disparoFallido;
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
            if (resultado == Constantes.disparoExitoso)
                siNaveDestruida(casilla, tablero, partida);
            // Aumenta la cantidad de tiros exitosos 
            this.actualizarPuntajesJugadores(tablero, resultado, partida);
            return resultado;
        }

        public void actualizarPuntajesJugadores(int tablero, int resultado, Partida partida)
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

        private bool siNaveDestruida(Tablero_Virtual casilla, int tablero, Partida partida)
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
    }
}
