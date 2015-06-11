using MBP.CapaTransversal.ModelsMVC;
using MBP.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBP.Logica
{
    public class GestionarNave
    {
        public string agregarNave(NaveModel nave)
        {
            // verificar datos de la nave
            AgregarModelos agregarModelos = new AgregarModelos();
            return agregarModelos.agregarNave(nave.nombre, nave.puntaje, nave.tamano,nave.imagen);
        }

        public string modificarNave(NaveModel nave)
        {
            // verificar datos de la nave
            ModificarModelos modificaModelos = new ModificarModelos();
            return modificaModelos.modificaNave(nave.Id,nave.nombre, nave.puntaje, nave.tamano, nave.imagen);
        }

        public bool desactivarNave(int idNave)
        {
            return new ModificarModelos().desactivarNave(idNave);
        }
    }
}
