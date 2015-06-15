using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MBP.EjeVertical
{
    public class TableroModel2
    {
        public List<CasillaModel2> tableroJugador{ get; set; }
        public int puntosLocal { get; set; }
        public int puntosRetador { get; set; }
        public int disparosRestantes { get; set; }
        public bool enMiTurno { get; set; }
    }
}