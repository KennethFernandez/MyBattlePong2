using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBP.Logica
{
    public static class CalculoEstadisticas
    {
        public static int perdidas(int total, int victorias) {
            return total - victorias;
        }
        public static int porcentajeEfectividad(int total, int victorias)
        {
            return total == 0 ? 0 : victorias / total * 100;
        }

    }
}
