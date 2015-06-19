using MBP.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBP.Logica
{
    public class FinalizarPartida
    {
        /**
         * Finaliza una partida ya sea que no hay naves o si abandona la partida
         * 
         * jugadorGanador es del jugador que gano la partida sea el J1 o el J2
         * 
         **/
        public bool finalizarPartida(int idPartida, int jugadorGanador)
        {
            // Recupera los modelos de las estadisticas y la partida
            Estadistica J1;
            Estadistica J2;
            ObtenerModelos obtener = new ObtenerModelos();
            Partida partida = obtener.buscarPartida(idPartida);
            J1 = obtener.obtieneEstadisticasJugador(partida.Jugador1_idCuenta);
            J2 = obtener.obtieneEstadisticasJugador(partida.Jugador2_idCuenta);

            // Aumenta el numero de partidas ganadas al ganador
            if (jugadorGanador == 1)
            {
                J1.TotalGanadas++;
            }
            else
            {
                J2.TotalGanadas++;
            }

            // Aumenta las partidas de cada jugador
            J1.TotalPartidas++;
            J2.TotalPartidas++;

            // Aumenta las estadisticas
            J1.TotalDisparos += partida.DisparosTotalesJugador1;
            J1.TotalAcertados += partida.DisparosExitososJugador1;
            J1.TotalPuntos += partida.PuntajeJugador1;
            J2.TotalDisparos += partida.DisparosTotalesJugador2;
            J2.TotalAcertados += partida.DisparosExitososJugador2;
            J2.TotalPuntos += partida.PuntajeJugador2;

            // Actualiza las estadisticas de los jugadores en la DB
            ModificarModelos modificar = new ModificarModelos();
            modificar.actualizarEstadistica(J1);
            modificar.actualizarEstadistica(J2);


            // Verifica si el jugador desbloqueo algun poder
            // Codigo

            // Mueve la partida al historial de partidas
            PartidaHistorica partidaHistorica = new PartidaHistorica();
            partidaHistorica.Ganador = jugadorGanador;
            partidaHistorica.Jugador1_idCuenta = partida.Jugador1_idCuenta;
            partidaHistorica.Jugador2_idCuenta = partida.Jugador2_idCuenta;
            partidaHistorica.NavesDestruidas1 = 0;
            partidaHistorica.NavesDestruidas2 = 0;
            new AgregarModelos().agregaPartidaHistorica(partidaHistorica);

            // Elimina la partida de la lista de partidas
            EliminarModelos eliminarModelos = new EliminarModelos();
            eliminarModelos.eliminarPartida(idPartida);

            return true;
        }

        public bool cancelarPartida(int idPartida)
        {
            return new EliminarModelos().eliminarPartida(idPartida);
        }

        /**
         * Un jugador se rinde de la partida
         * 
         **/

        public bool rendirse(int idPartida, int idJugador)
        {
            ObtenerModelos obtener =  new ObtenerModelos();
            Partida partida = obtener.buscarPartida(idPartida);
            List<Partida_Nave> lista = new ObtenerModelos().obtenerNavesDePartida(idPartida);
            if(partida.Jugador1_idCuenta == idJugador){     // Se rendio el jugador 1
                partida.PuntajeJugador2 = 0;
                foreach (Partida_Nave item in lista)        // Se le da la totalida  de los puntajes de las naves
                {
                    Nave nave = obtener.obtieneNave(item.Nave_idNave);
                    partida.PuntajeJugador2 += (nave.Puntaje * item.Cantidad);
                }
                new ModificarModelos().actualizarPartida(partida);
                return finalizarPartida(idPartida,2);
            }else{                                            // Se rindio el jugador 2
                partida.PuntajeJugador1 = 0;
                foreach (Partida_Nave item in lista)         // Se le da la totalida  de los puntajes de las naves
                {
                    Nave nave = obtener.obtieneNave(item.Nave_idNave);
                    partida.PuntajeJugador1 += (nave.Puntaje * item.Cantidad);
                }
                new ModificarModelos().actualizarPartida(partida);
                return finalizarPartida(idPartida,1);
            }
        }
    }
}
