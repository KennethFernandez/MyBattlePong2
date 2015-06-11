using MBP.Datos;
using MBP.EjeVertical.ModelsMVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBP.Logica
{
    public class MapperUsuario
    {
        protected string[,] data;
        protected UsuarioModel usuarioModel;
        public MapperUsuario()
        {
            this.usuarioModel = new UsuarioModel();
        }
        
        public UsuarioModel mapper(Usuario usuario, Jugador jugador, Pais pais, Estadistica estadistica)
        {

            data = new string[,]{{"id",usuario.Cuenta_idCuenta.ToString()},{"tipo",usuario.Tipo},
            {"Nombre",usuario.Nombre},{"Apellido",usuario.Apellido},{"Pais",pais.Nombre},{"email",usuario.Email},
            {"fecha de nacimiento",jugador.FechaNacimiento.ToString()},{"genero",jugador.Genero},{"foto",jugador.Foto},
            {"fecha de inscripcion al sistema",usuario.FechaInscripcion.ToString()},{"descripcion personal",jugador.DescripcionPersonal},
            {"total de partidas jugadas",estadistica.TotalPartidas.ToString()},
            {"total de partidas ganadas/perdidas",estadistica.TotalGanadas+"/"+(estadistica.TotalPartidas-estadistica.TotalGanadas)},
            {"porcentaje de efectividad de partidas",(estadistica.TotalGanadas/estadistica.TotalPartidas)*100 + "%"},
            {"total de disparos",estadistica.TotalDisparos.ToString()},{"disparos acertados/fallados",estadistica.TotalAcertados+"/"+(estadistica.TotalDisparos-estadistica.TotalAcertados)},
            {"porcentaje de efectividad en disparos",(estadistica.TotalAcertados/estadistica.TotalDisparos)*100 + "%"},
            {"puntos ganados",estadistica.PuntosGanados.ToString()},{"porcentaje de puntos ganados",estadistica.PuntosGanados/estadistica.TotalPuntos*100 + "%"}};
            usuarioModel.datos = data;
            return usuarioModel;
        }
        public UsuarioModel mapper(Usuario usuario)
        {
            data = new string[,]{{"id",usuario.Cuenta_idCuenta.ToString()},{"tipo",usuario.Tipo},
            {"Nombre",usuario.Nombre},{"Apellido",usuario.Apellido},{"email",usuario.Email},
            {"fecha de inscripcion al sistema",usuario.FechaInscripcion.ToString()}};
            usuarioModel.datos = data;
            return usuarioModel;
        }
        public UsuarioModel mapper(Usuario usuario, Moderador moderador, Pais pais)
        {
            data = new string[,]{{"id",usuario.Cuenta_idCuenta.ToString()},{"tipo",usuario.Tipo},
            {"Nombre",usuario.Nombre},{"Apellido",usuario.Apellido},{"Pais",pais.Nombre},{"email",usuario.Email},
            {"fecha de nacimiento",moderador.FechaNacimiento.ToString()},{"genero",moderador.Genero},{"foto",moderador.Foto},
            {"fecha de inscripcion al sistema",usuario.FechaInscripcion.ToString()},{"local",moderador.Local}};
            usuarioModel.datos = data;
            return usuarioModel;
        }
        public UsuarioModel mapper()
        {
            data = new string[,] { { "-1", "-1" } };
            usuarioModel.datos = data;
            return usuarioModel;
        }
    }
}
