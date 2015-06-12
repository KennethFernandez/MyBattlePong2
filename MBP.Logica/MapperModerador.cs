using MBP.CapaTransversal.ModelsMVC;
using MBP.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBP.Logica
{
    class MapperModerador : MapperDecorator
    {
        public MapperModerador(MapperUsuario mapperUsuario) : base(mapperUsuario) { }
        public override UsuarioModel mapper(Cuenta cuenta, Usuario usuario)
        {
            return mapperModerador(cuenta, usuario);
        }

        public UsuarioModel mapperModerador(Cuenta cuenta, Usuario usuario)
        {
            Moderador moderador = obtenerDatos.obtenerModerador(cuenta.idCuenta);
            Pais pais = obtenerDatos.obtenerPais(moderador.Pais_idPais);

            data = new string[,]{{"id",usuario.Cuenta_idCuenta.ToString()},{"tipo",usuario.Tipo},
            {"Nombre",usuario.Nombre},{"Apellido",usuario.Apellido},{"Pais",pais.Nombre},{"email",usuario.Email},
            {"fecha de nacimiento",moderador.FechaNacimiento.ToString()},{"genero",moderador.Genero},{"foto",moderador.Foto},
            {"fecha de inscripcion al sistema",usuario.FechaInscripcion.ToString()},{"local",moderador.Local}};
            usuarioModel.datos = data;
            return usuarioModel;
        }
    }
}
