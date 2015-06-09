using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBP.Logica
{
    public interface IEncriptacion
    {
        public string encriptar(string contrasena);
        public string desencriptar(string contrasena);
    }
}
