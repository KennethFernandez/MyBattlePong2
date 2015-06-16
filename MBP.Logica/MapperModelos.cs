using MBP.Datos;
using MBP.EjeVertical;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBP.Logica
{
    public class MapperModelos
    {
        /**
         * Cambia el modelo de la partida MVC a el modelo de datos del entity
         * Tambien asigna quien es el primer jugador en iniciar y los tiros disponibles para cada jugador
         **/
        public Partida partidaViewModelAPartidaDataModel(PartidaModel partidaModel)
        {

            Partida partida = new Partida();
            // Asigna la mima cantidad de disparos para cada jugador por que aun no se activa ningun poder
            partida.DisparosJugador1 = partidaModel.disparos;
            partida.DisparosJugador2 = partidaModel.disparos;
            partida.DisparosRestantes = partidaModel.disparos;

            // Selecciona quien es el primer jugador (Aplicar metodo aleatorio)
            partida.TurnoActual = true;

            // Asigna los datos del otro modelo
            partida.Fecha = DateTime.Now;
            partida.Publico = partidaModel.permisos;
            partida.Tamano = partidaModel.tamano;
            partida.Jugador1_idCuenta = partidaModel.idJugadorCreador;
            partida.Jugador2_idCuenta = partidaModel.idJugadorCreador;

            // Coloca la partida como creada pero no lista
            partida.Estado = Constantes.partidaCreada;
            return partida;
        }


        /**
         * Tranforma un conjunto de partidas del modelo de datos al modelo del MVC
         * 
         **/
        public List<PartidaModel> partidaDataModelApartidaViewModel(List<Partida> partidas)
        {
            List<PartidaModel> nuevasPartitas = new List<PartidaModel>();
            foreach (Partida item in partidas)
            {
                PartidaModel partida = new PartidaModel();
                partida.disparos = item.DisparosJugador1;
                partida.fechaCreacion = item.Fecha;
                partida.idJugadorCreador = item.Jugador1_idCuenta;
                partida.permisos = item.Publico;
                nuevasPartitas.Add(partida);
            }
            return nuevasPartitas;
        }




        /**
         * Mapeo la partida y el resultado del disparo al modelo de respuesta para el controlador
         * 
         **/

        public DisparoModel2 respuestaDisparoModel(Partida partida, int resultado)
        {
            DisparoModel2 respuesta = new DisparoModel2();
            if (partida.TurnoActual)
            {
                respuesta.idJugadorActual = partida.Jugador1_idCuenta;
            }
            else
            {
                respuesta.idJugadorActual = partida.Jugador2_idCuenta;
            }
            if (resultado == Constantes.disparoFinal)
            {
                respuesta.finalPartida = true;
            }
            else
            {
                respuesta.finalPartida = false;
            }
            respuesta.puntajeJugador1 = partida.PuntajeJugador1;
            respuesta.puntajeJugador2 = partida.PuntajeJugador2;
            respuesta.turnosRestantes = partida.DisparosRestantes;
            respuesta.resultado = resultado;
            return respuesta;
        }

        /**
         * Mapea la lista de casillas y la info de la partida al modelo de tablero para el controlador
         * 
         * 
         **/

        public TableroModel2 partidaATableroModel2(List<Tablero_Virtual> tablero, Partida partida, int numTablero)
        {
            TableroModel2 respuesta = new TableroModel2();
            if (numTablero == Constantes.tableroJugador1)
            {
                respuesta.puntosLocal = partida.PuntajeJugador1;
                respuesta.puntosRetador = partida.PuntajeJugador2;
                respuesta.disparosRestantes = partida.DisparosRestantes;
                if (partida.TurnoActual)
                {
                    respuesta.enMiTurno = true;
                }
                else
                {
                    respuesta.enMiTurno = false;
                }
            }
            else
            {
                respuesta.puntosLocal = partida.PuntajeJugador1;
                respuesta.puntosRetador = partida.PuntajeJugador2;
                respuesta.disparosRestantes = partida.DisparosRestantes;
                if (!partida.TurnoActual)
                {
                    respuesta.enMiTurno = true;
                }
                else
                {
                    respuesta.enMiTurno = false;
                }
            }
            int numNaveAnterior = 0;
            List<CasillaModel2> listaNaves = new List<CasillaModel2>();
            foreach (Tablero_Virtual item in tablero)
            {
                if (item.NumeroNave != numNaveAnterior)
                {
                    numNaveAnterior = item.NumeroNave;
                    CasillaModel2 casilla = new CasillaModel2();
                    casilla.idNave = item.NumeroNave;
                    casilla.X = item.x;
                    casilla.Y = item.y;
                    Nave nave = new ObtenerModelos().obtieneNave(item.Nave_idNave);
                    casilla.mas_X = nave.TamanoX;
                    casilla.mas_Y = nave.TamanoY;
                    casilla.imagen = nave.Imagen;
                    listaNaves.Add(casilla);
                }
            }
            respuesta.tableroJugador = listaNaves;
            return respuesta;
        }


        /**
         * Mapea la lista de poderes al modelo del controlador para ser mostrados
         * 
         **/

        public List<PoderModel2> poderApoderModel2(List<Poder> poderes)
        {
            List<PoderModel2> respuesta = new List<PoderModel2>();
            foreach (Poder item in poderes)
            {
                PoderModel2 poder = new PoderModel2();
                poder.idPoder = item.idPoder;
                poder.nombre = item.Nombre;
                respuesta.Add(poder);
            }
            return respuesta;
        }
    }
}
