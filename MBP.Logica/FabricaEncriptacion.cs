using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBP.Logica
{
    public class FabricaEncriptacion
    {
        IEncriptacion encripta;
        public IEncriptacion fabricaEncripta(int valor)
        {
            switch (valor)
            {
                case 1:
                    encripta = new AES();
                    break;
                default:
                    encripta = new EncriptacionNull();
                    break;
            }
            return encripta;
        }
    }
}
