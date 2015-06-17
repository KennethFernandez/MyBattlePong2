using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MBP.CapaTransversal.ModelsMVC
{
    public class PartidaModel2
    {
        public string nombreJugador { get; set; }
        public bool permisos { get; set; }
        public int disparos { get; set; }
        public DateTime fechaCreacion { get; set; }
        public int tamano { get; set; }
        public int idPartida { get; set; }
    }
}