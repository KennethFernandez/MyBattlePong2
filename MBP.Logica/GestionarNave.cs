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
            nuevaNave.Imagen = nave.imagen == null ? " " : nave.imagen;
            nuevaNave.TamanoY = nave.tamanoY;
            nuevaNave.Estado = nave.estado;
            nuevaNave.idNave = nave.Id;

            return modificaModelos.modificaNave(nuevaNave);
        }

        public bool desactivarNave(int idNave)
        {
            return new ModificarModelos().desactivarNave(idNave);
        }

        public NaveModel obtenerNave(string nombre)
        {
            ObtenerModelos obtener = new ObtenerModelos();
            Nave nave = obtener.obtenerNave(nombre);
            NaveModel nuevaNave = new NaveModel();
            nuevaNave.Id = nave.idNave;
            nuevaNave.imagen = nave.Imagen;
            nuevaNave.nombre = nave.Nombre;
            nuevaNave.puntaje = nave.Puntaje;
            nuevaNave.nombreCreadas = " ";
            nuevaNave.tamanoX = nave.TamanoX;
            nuevaNave.tamanoY = nave.TamanoY;
            nuevaNave.estado = nave.Estado;
            return nuevaNave;
        }

        public List<string> obtenerListaNombreNaves()
        {
            ObtenerModelos obtener = new ObtenerModelos();
            List<Nave> listaNaves = obtener.obtenerListaNaves();
            List<string> lista = new List<string>();
            foreach (var item in listaNaves)
            {
                lista.Add(item.Nombre);
            }
            return lista;
        }
    }
}
