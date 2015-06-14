using MBP.Datos;
using MBP.EjeVertical;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBP.Logica
{
    public class GestionarPartidaOnline
    {
        public List<PartidaModel> ObtenerPartidasOnline()
        {
            return null;
        }

        public TableroModel2 obtenerPartidaOnline(int idPartida)
        {
            ObtenerModelos obtenerModelos = new ObtenerModelos();
            Partida partida = obtenerModelos.buscarPartida(idPartida);
            List<Tablero_Virtual> tablero1 = obtenerModelos.obtenerCasillasDeTablero(Constantes.tableroJugador1,idPartida);
            List<Tablero_Virtual> tablero2 = obtenerModelos.obtenerCasillasDeTablero(Constantes.tableroJugador2, idPartida);
            return new MapperModelos().partidaATableroModel2(tablero1,tablero2,partida);
        }

        public int ingresarPartidaOnline(PartidaModel partida)
        {
            // Verifica si el jugador ya tiene creada una partida antes y la borra
            VerificarPartidaJugador verificar = new VerificarPartidaJugador();
            verificar.jugadorTienePartida(partida.idJugadorCreador);

            //Mapea el modelo de partida al modelo de la base de dtaos
            MapperModelos mapper = new MapperModelos();
            Partida partidaDatos = mapper.partidaViewModelAPartidaDataModel(partida);

            // Agrega la partida a la tabla de partidas
            AgregarModelos agregar = new AgregarModelos();
            return agregar.agregaPartidaOnline(partidaDatos);
        }

        public bool cambiarTurnoJuego(int idPartida)
        {
            Partida partida = new ObtenerModelos().buscarPartida(idPartida);
            if (partida != null)
            {
                if (partida.TurnoActual)
                {
                    partida.DisparosRestantes = partida.DisparosJugador2;
                }
                else
                {
                    partida.DisparosRestantes = partida.DisparosJugador1;
                }
                partida.TurnoActual = !partida.TurnoActual;
                new ModificarModelos().actualizarPartida(partida);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
