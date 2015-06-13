using MBP.CapaTransversal.ModelsMVC;
using MBP.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBP.Logica
{
    class MapperJugador : MapperDecorator
    {
        public MapperJugador(IMapperUsuario mapperUsuario) : base(mapperUsuario) { }
        public override UsuarioModel mapper(Cuenta cuenta, Usuario usuario)
        {
            return mapperJugador(cuenta, usuario);
        }

        public UsuarioModel mapperJugador(Cuenta cuenta, Usuario usuario)
        {
            Jugador jugador = obtenerDatos.obtenerJugador(cuenta.idCuenta);
            Pais pais = obtenerDatos.obtenerPais(jugador.Pais_idPais);
            Estadistica estadistica = obtenerDatos.obtenerEstadistica(cuenta.idCuenta);

            data = new string[,]{{"id",usuario.Cuenta_idCuenta.ToString()},{"tipo",usuario.Tipo},
            {"Nombre",usuario.Nombre},{"Apellido",usuario.Apellido},{"Pais",pais.Nombre},{"email",usuario.Email},
            {"fecha de nacimiento",jugador.FechaNacimiento.ToString()},{"genero",jugador.Genero},{"foto",jugador.Foto},
            {"fecha de inscripcion al sistema",usuario.FechaInscripcion.ToString()},{"descripcion personal",jugador.DescripcionPersonal},
            {"total de partidas jugadas",estadistica.TotalPartidas.ToString()},
            {"total de partidas ganadas/perdidas",estadistica.TotalGanadas+"/"+(estadistica.TotalPartidas-estadistica.TotalGanadas)},
            {"porcentaje de efectividad de partidas",((estadistica.TotalPartidas) == 0 ? 0 : estadistica.TotalGanadas/estadistica.TotalPartidas)*100 + "%"},
            {"total de disparos",estadistica.TotalDisparos.ToString()},{"disparos acertados/fallados",estadistica.TotalAcertados+"/"+(estadistica.TotalDisparos-estadistica.TotalAcertados)},
            {"porcentaje de efectividad en disparos",((estadistica.TotalDisparos) == 0 ? 0 : estadistica.TotalAcertados/estadistica.TotalDisparos)*100 + "%"},
            {"puntos ganados",estadistica.PuntosGanados.ToString()},{"porcentaje de puntos ganados", ((estadistica.TotalPuntos) == 0 ? 0 : estadistica.PuntosGanados/estadistica.TotalPuntos*100) + "%"}};
            usuarioModel.datos = data;
            return usuarioModel;
        }
    }
}
