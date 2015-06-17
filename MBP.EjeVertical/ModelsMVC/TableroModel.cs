using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MBP.CapaTransversal.ModelsMVC
{
    public class TableroModel
    {
        public List<CasillaModel> tablero { get; set; }
        public int idJugador { get; set; }
        public int idPartida { get; set; }
        public int escudoX { get; set; }
        public int escudoY { get; set; }
    }
}