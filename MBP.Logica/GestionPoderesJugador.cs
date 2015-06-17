using MBP.CapaTransversal.ModelsMVC;
using MBP.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBP.Logica
{
    public class GestionPoderesJugador
    {
        /**
         * Recupera los poderes de un jugador
         * 
         **/
        public List<PoderModel2> poderesJugador(int idJugador)
        {
            List<Poder> poderes = new ObtenerModelos().obtenerPoderesJugador(idJugador);
            return new MapperModelos().poderApoderModel2(poderes);
        }



        /**
         * 
         * 
         * 
         **/
        public List<PoderModel2> actualizarPoderesJugador(int idJugador)
        {
            List<Poder> poderesDesbloqueados = new List<Poder>();
            List<Poder> poderesDisponibles = new ObtenerModelos().obtenerListaPoderes();
            Estadistica estadisticas = new ObtenerModelos().obtieneEstadisticasJugador(idJugador);
            AgregarModelos agregar = new AgregarModelos();
            int partidasPerdias = CalculoEstadisticas.perdidas(estadisticas.TotalPartidas, estadisticas.TotalGanadas);
            int ranking = CalculoEstadisticas.ranking(estadisticas.TotalGanadas, partidasPerdias, estadisticas.TotalPuntos);
            foreach (Poder item in poderesDisponibles)
            {
                bool desbloqueado = false;
                if (item.Puntos < estadisticas.TotalPuntos && item.Puntos > 0)
                {
                    desbloqueado = true;
                }
                if (item.Ranking < ranking && item.Ranking > 0)
                {
                    desbloqueado = true;
                }
                if (item.Victorias < estadisticas.TotalGanadas && item.Victorias > 0)
                {
                    desbloqueado = true;
                }
                if (item.Derrotas < partidasPerdias && item.Derrotas > 0)
                {
                    desbloqueado = true;
                }
                if (item.Experiencia < estadisticas.TotalPartidas && item.Experiencia > 0)
                {

                }
                if (desbloqueado && !jugadorYaTienePoder(idJugador, item.idPoder))
                {
                    agregar.agregaPoderAjugador(idJugador, item.idPoder);
                    poderesDesbloqueados.Add(item);
                }
            }
            return new MapperModelos().poderApoderModel2(poderesDesbloqueados);
        }

        private bool jugadorYaTienePoder(int idJugador, int idPoder)
        {
            List<Poder> poderesAdquiridos = new ObtenerModelos().obtenerPoderesJugador(idJugador);
            foreach (Poder item in poderesAdquiridos)
            {
                if (item.idPoder == idPoder)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
