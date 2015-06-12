using MBP.CapaTransversal.ModelsMVC;
using MBP.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBP.Logica
{
    class MapperAdministrador : MapperUsuario
    {
        public override UsuarioModel mapper(Cuenta cuenta, Usuario usuario)
        {
            data = new string[,]{{"id",usuario.Cuenta_idCuenta.ToString()},{"tipo",usuario.Tipo},
            {"Nombre",usuario.Nombre},{"Apellido",usuario.Apellido},{"email",usuario.Email},
            {"fecha de inscripcion al sistema",usuario.FechaInscripcion.ToString()}};
            usuarioModel.datos = data;
            return usuarioModel;
        }
    }
}
