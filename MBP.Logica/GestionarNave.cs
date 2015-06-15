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
            Nave nuevaNave = new Nave();
            if (nave.imagen == null)
            {
                nuevaNave.Imagen = " ";
            }
            else {
                nuevaNave.Imagen = nave.imagen;
            }
            
            nuevaNave.Nombre = nave.nombre;
            nuevaNave.Puntaje = nave.puntaje;
            nuevaNave.TamanoX = nave.tamanoX;
            nuevaNave.TamanoY = nave.tamanoY;
            nuevaNave.Estado = nave.estado;

            return agregarModelos.agregarNave(nuevaNave);
        }

        public string modificarNave(NaveModel nave)
        {
            // verificar datos de la nave
            ModificarModelos modificaModelos = new ModificarModelos();
            Nave nuevaNave = new Nave();
            nuevaNave.Nombre = nave.nombre;
            nuevaNave.Puntaje = nave.puntaje;
            nuevaNave.TamanoX = nave.tamanoX;
            nuevaNave.Imagen = nave.imagen;
            nuevaNave.TamanoY = nave.tamanoY;
            nuevaNave.Estado = nave.estado;
            nuevaNave.idNave = nave.Id;

            return modificaModelos.modificaNave(nuevaNave);
        }

        public bool desactivarNave(int idNave)
        {
            return new ModificarModelos().desactivarNave(idNave);
        }
    }
}
