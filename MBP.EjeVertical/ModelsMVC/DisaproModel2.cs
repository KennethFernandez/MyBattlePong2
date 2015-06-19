using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MBP.CapaTransversal.ModelsMVC
{
    public class DisparoModel2
    {
        public int resultado { get; set; }
        public int puntajeJugadorActual { get; set; }
        public int turnosRestantes { get; set; }
        public bool esSuTurno { get; set; }
        public bool finalPartida { get; set; }
        public List<int[]> casillas { get; set; }
    }
}