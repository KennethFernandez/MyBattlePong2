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
            Partida partida  = new ObtenerModelos().buscarPartida(tablero.idPartida);
            if (partida.Estado == Constantes.partidaCreada) // Es el tablero del jugador 1
            {
                partida.Jugador1_idCuenta = tablero.idJugador; // Asigna el jugador a la partida
                partida.Estado = Constantes.partidaEnEspera; //coloca la partida en el estado para que pueda ser publicada
                new ModificarModelos().actualizarPartida(partida); // Actualiza la partida
                return armarTableroJuego1(tablero); // Arma el tablero de juego para el jugador 1
            }
            else if(partida.Estado == Constantes.partidaEnEspera)
            {
                partida.Estado = Constantes.partidaEnJuego; // Actualiza la partida a estado en juego
                partida.Jugador2_idCuenta = tablero.idJugador; // Asigna el jugador 2 a la partida
                new ModificarModelos().actualizarPartida(partida); // Actualiza la partida
                return armarTableroJuego2(tablero); // Arma el tablero de juego 2, coloca la partida en activa y asigna el jugador 2 a la partigda
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
        public bool armarTableroJuego1(TableroModel tablero)
        {
            for (int i = 0; i < tablero.tablero.Count; i++)
			{
			    Tablero_Virtual_1 casilla = new Tablero_Virtual_1();
                casilla.Partida_idPartida = tablero.idPartida;
                casilla.x = tablero.tablero[i].X;
                casilla.y = tablero.tablero[i].Y;
                casilla.Destruido = false;
                casilla.Poder = tablero.tablero[i].poder;
                casilla.Nave_idNave = tablero.tablero[i].idNave;
                casilla.NumeroNave = tablero.tablero[i].idNaveTablero;
                new AgregarModelos().agregarCasillaTableroVirtual1(casilla);
			}
            return true;
        }

        public bool armarTableroJuego2(TableroModel tablero)
        {
            for (int i = 0; i < tablero.tablero.Count; i++)
            {
                Tablero_Virtual_2 casilla = new Tablero_Virtual_2();
                casilla.Partida_idPartida = tablero.idPartida;
                casilla.x = tablero.tablero[i].X;
                casilla.y = tablero.tablero[i].Y;
                casilla.Destruido = false;
                casilla.Poder = tablero.tablero[i].poder;
                casilla.Nave_idNave = tablero.tablero[i].idNave;
                casilla.NumeroNave = tablero.tablero[i].idNaveTablero;
                new AgregarModelos().agregarCasillaTableroVirtual2(casilla);
            }
            return true;
        }

    }
}
