using MBP.CapaTransversal.ModelsMVC;
using MBP.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBP.Logica
{
    public class AgregarUsuarioNull : IAgregarUsuario
    {
        public bool agregarUsuario(CompositeRegModel model)
        {
            return true;
        }
    }
}
