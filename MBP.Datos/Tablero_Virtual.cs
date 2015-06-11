using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBP.Datos
{
    public class Tablero_Virtual
    {
        public int Id { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public int NumeroNave { get; set; }
        public int Poder { get; set; }
        public bool Destruido { get; set; }
        public int Nave_idNave { get; set; }
        public int Partida_idPartida { get; set; }
    
    }
}
