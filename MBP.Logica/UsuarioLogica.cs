using MBP.CapaTransversal.ModelsMVC;
using MBP.Datos;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBP.Logica
{
    public class UsuarioLogica
    {

        public UsuarioModel verificarIngreso(InicioModel model)
        {
            ObtenerModelos obtenerDatos = new ObtenerModelos();
            Cuenta cuenta = obtenerDatos.obtenerCuenta(model.Usuario, model.Contrasena);
            Usuario usuario = obtenerDatos.obtenerUsuario(cuenta.idCuenta);
            IMapperUsuario mapper = new FabricaMapper().getMapper(usuario.Tipo);
            return mapper.mapper(cuenta, usuario);
        }
        public bool modificarUsuario(CompositeRegModel model)
        {
            FabricaModificarUsuario fabrica = new FabricaModificarUsuario();
            IModificarUsuario modificar = fabrica.fabricaUsuario(model.ModeloBase.tipo);
            return modificar.modificarUsuario(model);
        }

        public bool modificarContrasena()
        {
            return true;
        }
    }
}
