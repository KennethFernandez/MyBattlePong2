using MBP.CapaTransversal.ModelsMVC;
using MBP.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBP.Logica
{
    class MapperNull : MapperUsuario
    {
        public override UsuarioModel mapper(Cuenta cuenta, Usuario usuario)
        {
            data = new string[,]{{"-1","-1"}};
            usuarioModel.datos = data;
            return usuarioModel;
        }
    }
}
