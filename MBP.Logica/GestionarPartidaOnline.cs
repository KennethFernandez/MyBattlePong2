using MBP.CapaTransversal.ModelsMVC;
using MBP.Datos;
using MBP.EjeVertical.ModelsMVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBP.Logica
{
    public class GestionarPartidaOnline
    {

        /**
         * 
         * 
         **/
        public List<PartidaModel2> obtenerPartidasDisponibles()
        {
            List<Partida> partidas = new ObtenerModelos().obtenerListaPartidaOn();
            return new MapperModelos().partidaDataModelApartidaViewModel(partidas);
        }

        /**
         * 
         * 
         **/
        public TableroModel2 obtenerPartidaOnline(int idPartida, int idJugador)
        {
            ObtenerModelos obtenerModelos = new ObtenerModelos();
            Partida partida = obtenerModelos.buscarPartida(idPartida);
            List<Tablero_Virtual> tablero;
            TableroModel2 respuesta;
            if (partida.Jugador1_idCuenta == idJugador)
            {
                tablero = obtenerModelos.obtenerCasillasDeTablero(Constantes.tableroJugador1, idPartida);
                respuesta = new MapperModelos().partidaATableroModel2(tablero, partida, Constantes.tableroJugador1);
            }
            else
            {
                tablero = obtenerModelos.obtenerCasillasDeTablero(Constantes.tableroJugador2, idPartida);
                respuesta = new MapperModelos().partidaATableroModel2(tablero, partida, Constantes.tableroJugador2);
            }
            return respuesta;
        }

        /**
         * 
         * 
         **/
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

            // Agrega la partida a la base de datos
            int idPartida =  agregar.agregaPartidaOnline(partidaDatos);

            // Agrega las naves a la partida
            foreach (int[] item in partida.naves)
            {
                Partida_Nave relacion = new Partida_Nave();
                relacion.Nave_idNave = item[0];
                relacion.Partida_idPartida = idPartida;
                relacion.Cantidad = item[1];
                agregar.agregarNavePartida(relacion);
            }
            return idPartida;
        }

        /**
         * 
         * 
         **/
        public bool cambiarTurnoJuego(int idPartida)
        {
            Partida partida = new ObtenerModelos().buscarPartida(idPartida);
            if (partida != null)
            {
                if (partida.TurnoActual)
                {
                    partida.DisparosRestantes = partida.DisparosJugador2;
                    partida.TurnoActual = false;
                }
                else
                {
                    partida.DisparosRestantes = partida.DisparosJugador1;
                    partida.TurnoActual = true;
                }
                new ModificarModelos().actualizarPartida(partida);
                return true;
            }
            else
            {
                return false;
            }
        }

        /**
         * 
         * 
         **/
        public List<NaveModel2> navesDePartida(int idPartida)
        {
            List<Partida_Nave> lista =  new ObtenerModelos().obtenerNavesDePartida(idPartida);
            return new MapperNavesPartida().mapperNavesDatosANavesModel2(lista);
        }
    }
}
