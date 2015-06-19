using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MBP.CapaTransversal.ModelsMVC
{
    public class PoderModel
    {
        public string Nombre { get; set; }
        public int Experiencia { get; set; }
        public int Victorias { get; set; }
        public int Puntos { get; set; }
        public int Derrotas { get; set; }
        public int Ranking { get; set; }
    }
}