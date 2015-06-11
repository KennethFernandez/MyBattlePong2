using MBP.CapaTrasversal.ModelsMVC;
using MBP.Datos;
using MBP.EjeVertical;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBP.Logica
{
    public class IngresaUsuario
    {

        public bool VerificarIngreso(InicioModel cuenta)
        {
            ObtenerModelos obtenerDatos = new ObtenerModelos();
            Cuenta usuario = obtenerDatos.ObtenerCuenta(cuenta.Usuario, cuenta.Contrasena);
            if (usuario == null) return false;
            else return true;
        }

        public bool modificarUsuario(string id) //Modelo Usuario con datos del usuario, primer dato tipo usuario, segundo dato cuenta activa, etc.
        {
            return true;
        }
    }
}
