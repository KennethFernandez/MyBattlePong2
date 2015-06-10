using MBP.Datos;
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

        public bool VerificarIngreso(string nombre, string contra)
        {
            ObtenerModelos obtenerDatos = new ObtenerModelos();
            Cuenta usuario = obtenerDatos.ObtenerCuenta(nombre);
            if (usuario==null)
            {
                Debug.Write("usuario no existe");
                return false;
            }
            else
            {
                if (usuario.Contrasena == contra)
                {
                    return true;
                }
                else
                {
                    Debug.Write("Error en password");
                    return false;
                }
            }
        }
    }
}
