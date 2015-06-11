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
            MapperUsuario mapper = new MapperUsuario();
            Pais pais;
            if (cuenta != null)
            {
                Usuario usuario = obtenerDatos.obtenerUsuario(cuenta.idCuenta);
                switch (usuario.Tipo)
	            {
                    case "1":   //jugador
                        Jugador jugador = obtenerDatos.obtenerJugador(cuenta.idCuenta);
                        pais = obtenerDatos.obtenerPais(jugador.Pais_idPais);
                        Estadistica estadistica = obtenerDatos.obtenerEstadistica(cuenta.idCuenta);
                        result = mapper.mapper(usuario, jugador, pais, estadistica);
                        break;
                    case "2":   //moderador
                        Moderador moderador = obtenerDatos.obtenerModerador(cuenta.idCuenta);
                        pais = obtenerDatos.obtenerPais(moderador.Pais_idPais);
                        result = mapper.mapper(usuario, moderador, pais);
                        break;
                    case "3":   //administrador
                        result = mapper.mapper(usuario);
                        break;
		            default:    //cuenta nula
                        result = mapper.mapper();
                        break;
	            }
            }
            else
            {
                result = mapper.mapper();
            }
            return result;
        }
    }
}
