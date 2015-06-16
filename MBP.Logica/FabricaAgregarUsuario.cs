using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBP.Logica
{
    public class FabricaAgregarUsuario
    {
        public IAgregarUsuario fabricaAgregUsuario(string valor)
        {
            switch (valor)
            {
                case "1":
                    return new AgregarJugador();
                case "2":
                    return new AgregarModerador();
                case "3":
                    return new AgregarAdministrador();
                default:
                    return new AgregarUsuarioNull();
            }
        }
    }
}
