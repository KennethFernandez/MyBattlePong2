using MBP.CapaTransversal.ModelsMVC;
using MBP.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBP.Logica
{
    public class AgregarJugador:IAgregarUsuario
    {
        public bool agregarUsuario(CompositeRegModel model) {
            AgregarCuenta agregarCuenta = new AgregarCuenta();
            Cuenta cuenta = agregarCuenta.agregarCuenta(model.ModeloBase);
            AgregarModelos nuevo = new AgregarModelos();
            ObtenerModelos obtenerDatos = new ObtenerModelos();
            nuevo.agregarCuenta(cuenta);
            Usuario usuario = agregarCuenta.agregarUsuario(model.ModeloBase);
            int idCuenta=obtenerDatos.obtenerIdCuenta(model.ModeloBase.Login);
            usuario.Cuenta_idCuenta = idCuenta;
            nuevo.agregarUsuario(usuario);
            Jugador jugador = new Jugador();
            jugador.DescripcionPersonal = model.ModeloJugador.DescripcionPersonal;
            jugador.Foto = model.ModeloExt.Foto;
            DateTime date = new DateTime();
            date = DateTime.ParseExact(model.ModeloExt.FechaNacimiento, "MM/dd/yyyy", null);
            jugador.FechaNacimiento = date;
            jugador.Genero = model.ModeloExt.Genero;
            jugador.Pais_idPais = new ObtenerModelos().obtenerIdPais(model.ModeloExt.Pais);
            jugador.Usuario_Cuenta_idCuenta = idCuenta;
            Estadistica estadistica = new Estadistica();
            estadistica.Jugador_Usuario_Cuenta_idCuenta = idCuenta;
            nuevo.agregarJugador(jugador);
            nuevo.agregarEstadistica(estadistica);
            

            
            

            return true;
        }
    }
}
