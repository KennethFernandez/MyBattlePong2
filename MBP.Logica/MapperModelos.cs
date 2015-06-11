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
        public Partida partidaViewModelAPartidaDataModel(PartidaModel partidaModel){
            Console.WriteLine("MBP.Logica-MapperModelos-partidaViewModelAPartidaDataModel: Se realizo el cambio de modelos");
            Partida partida = new Partida();
            partida.Disparos = partidaModel.disparos;
            partida.Fecha = DateTime.Now;
            partida.idPartida = 0;
            if (partidaModel.permisos)
            {
                partida.Publico = "T";
            }
            else
            {
               partida.Publico = "F";
            }
            partida.Tamano = partidaModel.tamano;
            partida.Jugador2_idCuenta = 2;
            partida.Jugador1_idCuenta = partidaModel.idJugadorCreador;
            partida.Estado = "D";

            return partida;
        }
    }
}
