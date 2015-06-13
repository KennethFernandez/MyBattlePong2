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
        public int ingresarPartidaOnline(PartidaModel partida)
        {
            // Verifica si el jugador ya tiene creada una partida antes y la borra
            VerificarPartidaJugador verificar = new VerificarPartidaJugador();
            verificar.jugadorTienePartida(partida.idJugadorCreador);

            //Mapea el modelo de partida al modelo de la base de dtaos
            MapperModelos mapper = new MapperModelos();
            Partida partidaDatos = mapper.partidaViewModelAPartidaDataModel(partida);

            // Agrega la partida a la tabla de partidas en espera
            AgregarModelos agregar = new AgregarModelos();
            return agregar.agregaPartidaOnline(partidaDatos);
        }
    }
}
