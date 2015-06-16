using MBP.CapaTransversal.ModelsMVC;
using MBP.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBP.Logica
{
    public class ModificarAdministrador : IModificarUsuario
    {
        public bool modificarUsuario(CompositeRegModel usuario)
        {
            ObtenerModelos obtencion = new ObtenerModelos();
            Usuario user = obtencion.obtenerUsuario(usuario.ModeloBase.IdCuenta);
            Moderador mod = obtencion.obtenerModerador(usuario.ModeloBase.IdCuenta);
            user.Email = usuario.ModeloBase.Email;
            user.Apellido = usuario.ModeloBase.Apellido;
            user.Nombre = usuario.ModeloBase.Nombre;
            ModificarModelos modificar = new ModificarModelos();
            modificar.modificarUsuario(user);
            return true;
        }
    }
}
