using MBP.CapaTransversal.ModelsMVC;
using MBP.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBP.Logica
{
    public abstract class IMapperUsuario
    {
        protected string[,] data;
        protected UsuarioModel usuarioModel;
        protected ObtenerModelos obtenerDatos = new ObtenerModelos();
        public IMapperUsuario()
        {
            this.usuarioModel = new UsuarioModel();
        }
        public abstract UsuarioModel mapper(Cuenta cuenta, Usuario usuario);
    }
}
