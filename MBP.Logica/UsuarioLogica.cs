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
            Cuenta cuenta = obtenerDatos.obtenerCuenta(model.Usuario);
            UsuarioModel result = new UsuarioModel();
            MapperUsuario mapper = null;
            Usuario usuario = null;
            if (cuenta != null)
            {
                usuario = obtenerDatos.obtenerUsuario(cuenta.idCuenta);
                switch (usuario.Tipo)
	            {
                    case "1":   //jugador
                        mapper = new MapperJugador(mapper);
                        result = mapper.mapper(cuenta, usuario);
                        break;
                    case "2":   //moderador
                        mapper = new MapperModerador(mapper);
                        result = mapper.mapper(cuenta, usuario);
                        break;
                    case "3":   //administrador
                        mapper = new MapperAdministrador();
                        result = mapper.mapper(cuenta, usuario);
                        break;
		            default:    //cuenta nula
                        mapper = new MapperNull();
                        result = mapper.mapper(cuenta, usuario);
                        break;
	            }
            }
            else
            {
                mapper = new MapperNull();
                result = mapper.mapper(cuenta, usuario);
            }
            return result;
        }
    }
}
