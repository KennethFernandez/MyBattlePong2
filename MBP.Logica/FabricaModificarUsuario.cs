using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBP.Logica
{
    public class FabricaModificarUsuario
    {
        public IModificarUsuario fabricaModifUsuario(string valor)
        {
            switch (valor)
            {
                case "1":
                    return new ModificarJugador();
                case "2":
                    return new ModificarModerador();
                case "3":
                    return new ModificarAdministrador();
                default:
                    return new ModificarUsuarioNull();
            }
        }
    }
}
