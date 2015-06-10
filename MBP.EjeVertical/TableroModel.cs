using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MBP.EjeVertical
{
    public class TableroModel
    {
        public CasillaModel[] tablero { get; set; }
        public int idJugador { get; set; }
        public int idPartida { get; set; }
    }
}