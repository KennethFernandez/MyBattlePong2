using MBP.CapaTransversal.ModelsMVC;
using MBP.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBP.Logica
{
    public class AgregarModerador:IAgregarUsuario
    {
        public bool agregarUsuario(CompositeRegModel model)
        {
            AgregarCuenta agregarCuenta = new AgregarCuenta();
            Cuenta cuenta = agregarCuenta.agregarCuenta(model.ModeloBase);
            Usuario usuario = agregarCuenta.agregarUsuario(model.ModeloBase);
            AgregarModelos nuevo = new AgregarModelos();
            ObtenerModelos obtenerDatos = new ObtenerModelos();
            nuevo.agregarCuenta(cuenta);
            int idCuenta = obtenerDatos.obtenerIdCuenta(model.ModeloBase.Login);
            usuario.Cuenta_idCuenta = idCuenta;
            nuevo.agregarUsuario(usuario);
            Moderador moderador = new Moderador();
            moderador.Local = model.ModeloModerador.Local;
            moderador.Foto = model.ModeloExt.Foto;
            DateTime date = new DateTime();
            date = DateTime.ParseExact(model.ModeloExt.FechaNacimiento, "MM/dd/yyyy", null);
            moderador.FechaNacimiento = date;
            moderador.Genero = model.ModeloExt.Genero;
            moderador.Pais_idPais = new ObtenerModelos().obtenerIdPais(model.ModeloExt.Pais);
            moderador.Usuario_Cuenta_idCuenta = idCuenta;
            nuevo.agregarModerador(moderador);



            return true;
        }
    }
}
