using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MBP.EjeVertical
{
    public class PartidaModel
    {
        public int idJugadorCreador { get; set; }
        public bool permisos { get; set; }
        public int disparos { get; set; }
        public DateTime fechaCreacion { get; set; }
        public int[,] navesTipo { get; set; }
        public int tamano { get; set; }
    }
}