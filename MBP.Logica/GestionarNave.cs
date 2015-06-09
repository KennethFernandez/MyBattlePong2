using MBP.Datos;
using MBP.EjeVertical;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBP.Logica
{
    public class GestionarNave
    {
        public bool agregarNave(NaveModel nave)
        {
            // verificar datos de la nave
            AgregarModelos agregarModelos = new AgregarModelos();
            return agregarModelos.agregarNave();
        }

        public bool desactivarNave(int idNave)
        {
            return new ModificarModelos().desactivarNave(idNave);
        }
    }
}
