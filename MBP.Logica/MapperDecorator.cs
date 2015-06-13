using MBP.CapaTransversal.ModelsMVC;
using MBP.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBP.Logica
{
    abstract class MapperDecorator : IMapperUsuario
    {
        protected IMapperUsuario toBeMapped;
        public MapperDecorator(IMapperUsuario toBeMapped)
        {
            this.toBeMapped = toBeMapped;
        }

        public override UsuarioModel mapper(Cuenta cuenta, Usuario usuario)
        {
            return toBeMapped.mapper(cuenta, usuario);
        }
    }
}
