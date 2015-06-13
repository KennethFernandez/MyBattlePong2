using MBP.Datos;
using MBP.EjeVertical;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public Partida partidaViewModelAPartidaDataModel(PartidaModel partidaModel){

            Partida partida = new Partida();
            // Asigna la mima cantidad de disparos para cada jugador por que aun no se activa ningun poder
            partida.DisparosJugador1 = partidaModel.disparos;
            partida.DisparosJugador2 = partidaModel.disparos;
            partida.DisparosRestantes = partidaModel.disparos;

            // Selecciona quien es el primer jugador (Aplicar metodo aleatorio)
            partida.TurnoActual = true;

            // Asigna los datos del otro modelo

            partida.Jugador2_idCuenta = Constantes.cuentaPorDefectoPartidaEspera;
            partida.Fecha = DateTime.Now;
            partida.Publico = partidaModel.permisos;
            partida.Tamano = partidaModel.tamano;
            partida.Jugador1_idCuenta = partidaModel.idJugadorCreador;

            // Coloca la partida como creada pero no lista
            partida.Estado = Constantes.partidaCreada;
            return partida;
        }


        /**
         * Tranforma un conjunto de partidas del modelo de datos al modelo del MVC
         * 
         **/
        public PartidaModel[] partidaDataModelApartidaViewModel(Partida[] partidas)
        {
            PartidaModel [] nuevasPartitas = new PartidaModel[partidas.Length-1];
            for (int i = 0; i < partidas.Length; i++)
            {
                PartidaModel partida = new PartidaModel();
                partida.disparos = partidas[i].DisparosJugador1;
                partida.fechaCreacion = partidas[i].Fecha;
                partida.idJugadorCreador = partidas[i].Jugador1_idCuenta;
                partida.permisos = partidas[i].Publico; 
                nuevasPartitas[i] = partida;
            }
            return nuevasPartitas;
        }
    }
}
