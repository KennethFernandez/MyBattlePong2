using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBP.Logica
{
    public class ProcesarDisparo
    {
        public bool ProcesarDisapro(int numVaso, int idDispositivo)
        {
            if ((numVaso >= 0) && (idDispositivo >= 0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
