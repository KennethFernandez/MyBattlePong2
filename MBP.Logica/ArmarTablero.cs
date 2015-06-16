using MBP.Datos;
using MBP.EjeVertical;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBP.Logica
{
    public class ArmarTablero
    {

        public bool armarTableroJuego(TableroModel tablero)
        {
            // Verifica si el tablero que entra es del jugador creador o del retador de la partida
            Partida partida = new ObtenerModelos().buscarPartida(tablero.idPartida);
            if (partida.Estado == Constantes.partidaCreada) // Es el tablero del jugador 1
            {
                partida.Jugador1_idCuenta = tablero.idJugador; // Asigna el jugador a la partida
                partida.Estado = Constantes.partidaEnEspera; //coloca la partida en el estado para que pueda ser publicada
                new ModificarModelos().actualizarPartida(partida); // Actualiza la partida
                return armarTableroJuego(tablero, Constantes.tableroJugador1); // Arma el tablero de juego para el jugador 1
            }
            else if (partida.Estado == Constantes.partidaEnEspera)
            {
                partida.Estado = Constantes.partidaEnJuego; // Actualiza la partida a estado en juego
                partida.Jugador2_idCuenta = tablero.idJugador; // Asigna el jugador 2 a la partida
                new ModificarModelos().actualizarPartida(partida); // Actualiza la partida
                return armarTableroJuego(tablero, Constantes.tableroJugador2); // Arma el tablero de juego 2, coloca la partida en activa y asigna el jugador 2 a la partigda
            }
            else
            {
                return false;
            }
        }

        /**
         * Arma los tableros de juego dependiendo del jugador al que se este haciendo referencia
         * 
         * 
         **/
        public bool armarTableroJuego(TableroModel tablero, int numTablero)
        {
            int numNaveTablero = 1;
            foreach (CasillaModel item in tablero.tablero)
            {
                Tablero_Virtual casilla = new Tablero_Virtual();
                Nave nave = new ObtenerModelos().obtieneNave(item.idNave);
                casilla.Partida_idPartida = tablero.idPartida;
                casilla.NumeroNave = numNaveTablero;
                casilla.Nave_idNave = item.idNave;
                casilla.Destruido = false;
                for (int i = 0; i < nave.TamanoX; i++)
                {
                    for (int j = 0; j < nave.TamanoY; j++)
                    {
                        casilla.x = i + item.X;
                        casilla.y = j + item.Y;
                        new AgregarModelos().agregarCasillaTableroVirtual(casilla, numTablero);
                    }
                }
                numNaveTablero++;
            }
            if (tablero.escudoX != -1 && tablero.escudoY != -1)
            {
                Tablero_Virtual casilla = new ObtenerModelos().obtenerCasillaTablero(numTablero, tablero.idPartida, tablero.escudoX, tablero.escudoY);
                casilla.Poder++;
                new ModificarModelos().actualizarCasilla(casilla, numTablero);
            }
            return true;
        }
    }
}
