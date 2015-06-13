using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBP.Logica
{
    public class FabricaModificarUsuario
    {
        public IModificarUsuario fabricaUsuario(int valor)
        {
            switch (valor)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                default:
                    break;
            }
            return null;
        }
    }
}
