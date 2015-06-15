using MBP.CapaTransversal.ModelsMVC;
using MBP.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBP.Logica
{
    public class ModificarJugador : IModificarUsuario
    {
        public bool modificarUsuario(CompositeRegModel usuario)
        {
            ObtenerModelos obtencion = new ObtenerModelos();
            Usuario user =obtencion.obtenerUsuario(usuario.ModeloBase.IdCuenta);
            Jugador jug = obtencion.obtenerJugador(usuario.ModeloBase.IdCuenta);
            user.Email = usuario.ModeloBase.Email;
            user.Apellido = usuario.ModeloBase.Apellido;
            user.Nombre = usuario.ModeloBase.Nombre;
            ModificarModelos modificar = new ModificarModelos();
            modificar.modificarUsuario(user);
            jug.DescripcionPersonal = usuario.ModeloJugador.DescripcionPersonal;
            jug.Pais_idPais = obtencion.obtenerIdPais(usuario.ModeloExt.Pais);
            jug.Genero = usuario.ModeloExt.Genero;
            jug.Foto = usuario.ModeloExt.Foto;
            modificar.modificarJugador(jug);
            return true;
        }
    }
}
