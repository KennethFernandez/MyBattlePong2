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
         * Recupera los poderes que tiene desbloqueados 
         * un jugador
         **/
        public List<PoderModel2> poderesJugador(int idJugador)
        {
            List<Poder> poderes = new ObtenerModelos().obtenerPoderesJugador(idJugador);
            return new MapperModelos().poderApoderModel2(poderes); // Cambia los poderes del modelo de datos al MVC
        }



        /**
         *  Buscar si el jugador a desbloqueado un nuevo poder
         **/
        public List<PoderModel2> actualizarPoderesJugador(int idJugador)
        {
            // Carga las listas de los poderes
            List<Poder> poderesDesbloqueados = new List<Poder>();
            List<Poder> poderesDisponibles = new ObtenerModelos().obtenerListaPoderes();
            // Cargas las estadisticas del jugador para revisar los valores
            Estadistica estadisticas = new ObtenerModelos().obtieneEstadisticasJugador(idJugador);
            AgregarModelos agregar = new AgregarModelos();
            // Calcula las estadisticas de derrotas y ranking
            int partidasPerdias = CalculoEstadisticas.perdidas(estadisticas.TotalPartidas, estadisticas.TotalGanadas);
            int ranking = CalculoEstadisticas.ranking(estadisticas.TotalGanadas, partidasPerdias, estadisticas.TotalPuntos);
            // Verifica los poderes disponibles y los valores que tiene actualmente
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
                // Verifica si el poder se puede desbloquear
                if (desbloqueado && !jugadorYaTienePoder(idJugador, item.idPoder)) // Verifica si el jugador ya tiene el poder
                {
                    agregar.agregaPoderAjugador(idJugador, item.idPoder);
                    poderesDesbloqueados.Add(item); // Agrega el poder a la lista de desbloqueaos
                }
            }
            return new MapperModelos().poderApoderModel2(poderesDesbloqueados); // Transforma los modelos de poderes a los modelos del MVC
        }


        /**
         * Verifica si el jugador ya tiene el poder que se va a desbloquear para conocer 
         * si se debe notificar
         * 
         **/
        private bool jugadorYaTienePoder(int idJugador, int idPoder)
        {
            List<Poder> poderesAdquiridos = new ObtenerModelos().obtenerPoderesJugador(idJugador);  // Lista de poderes del jugador
            foreach (Poder item in poderesAdquiridos)
            {
                if (item.idPoder == idPoder)  // Verifica si el poder ya lo tiene el jugador
                {
                    return true;
                }
            }
            return false;
        }
    }
}
