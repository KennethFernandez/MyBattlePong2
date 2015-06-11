using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MBP.Logica
{
    public class Constantes
    {
        // Estados de las partidas

        // La partida a sido creada pero no tiene ningun tablero asignado
        public static int partidaCreada = 1;
        // La partida tiene el tablero del retador asignado y esta a la espera de un contrincante
        public static int partidaEnEspera = 2;
        // La partida esta actualmente en juego y tiene los 2 tableros asignados
        public static int partidaEnJuego = 3;
        // La partida ya esta finalizada
        public static int partidaFinalizada = 4;



        // Resultados de los disparos
        // El disparo fallo
        public static int disparoFallido = 1;
        // El disparo impacto una nave
        public static int disparoExitoso = 2;
        // El disapro impacto en un escudo
        public static int disparoEscudo = 3;
        // El disparo elimino la ultima nave
        public static int disparoFinal = 4;
        // El disparo elimino la ultima nave
        public static int disparoNaveDestruida = 5;

        // Numero que representa el tablero de cada jugador
        // jugador 1
        public static int tableroJugador1 = 1;
        // Jugador 2
        public static int tableroJugador2 = 2;
    }
}