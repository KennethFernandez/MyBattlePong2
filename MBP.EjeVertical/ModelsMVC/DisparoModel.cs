using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MBP.CapaTransversal.ModelsMVC
{
    public class DisparoModel
    {
        public int x { get; set; }
        public int y { get; set; }
        public int idPartida { get; set; }
        public int idJugador { get; set; }
        public int tipoDisparo { get; set; }
        public int dir { get; set; }
    }
}