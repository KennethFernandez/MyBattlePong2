using MBP.CapaTransversal.ModelsMVC;
using MBP.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBP.Logica
{
    public class AgregarCuenta
    {
        public Cuenta agregarCuenta(RegistrarseModel model) {
            Cuenta cuenta = new Cuenta();
            IEncriptacion encrip = new FabricaEncriptacion().fabricaEncripta(1);
            cuenta.Contrasena = encrip.encriptar(model.Password);
            cuenta.Login = model.Login;
            cuenta.Estado = "1";
            return cuenta;
        }
        public Usuario agregarUsuario(RegistrarseModel model) {
            Usuario user = new Usuario();
            user.Email = model.Email;
            user.Nombre = model.Nombre;
            user.Apellido = model.Apellido;
            user.Tipo = model.Tipo;
            user.FechaInscripcion = DateTime.Now;
            return user;

        }
    }
}
