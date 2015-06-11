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
        public Partida partidaViewModelAPartidaDataModel(PartidaModel partidaModel){
            Console.WriteLine("MBP.Logica-MapperModelos-partidaViewModelAPartidaDataModel: Se realizo el cambio de modelos");
            Partida partida = new Partida();
            partida.Disparos = partidaModel.disparos;
            partida.Fecha = DateTime.Now;
            partida.idPartida = 0;
            partida.Publico = partidaModel.permisos;
            partida.Tamano = partidaModel.tamano;
            partida.Jugador2_idCuenta = 2;
            partida.Jugador1_idCuenta = partidaModel.idJugadorCreador;
            partida.Estado = Constantes.partidaCreada;
            return partida;
        }

        public PartidaModel[] partidaDataModelApartidaViewModel(Partida[] partidas)
        {
            Debug.Write("MBP.Logica-MapperModelos-PartidaDataModelApartidaViewModel: Se realizo el cambio de modelos");
            PartidaModel [] nuevasPartitas = new PartidaModel[partidas.Length-1];
            for (int i = 0; i < partidas.Length; i++)
            {
                PartidaModel partida = new PartidaModel();
                partida.disparos = partidas[i].Disparos;
                partida.fechaCreacion = partidas[i].Fecha;
                partida.idJugadorCreador = partidas[i].Jugador1_idCuenta;
                partida.permisos = partidas[i].Publico; 
                nuevasPartitas[i] = partida;
            }
            return nuevasPartitas;
        }
    }
}
