using MBP.CapaTransversal.ModelsMVC;
using MBP.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBP.Logica
{
    public class AgregarAdministrador:IAgregarUsuario
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

            return true;
        }
    }
}
