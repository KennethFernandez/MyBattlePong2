using MBP.Datos;
using MBP.CapaTransversal.ModelsMVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBP.Logica
{
    public class GestionarPoderes
    {
        public List<string> obtenerPoderes()
        {
            ObtenerModelos obtener = new ObtenerModelos();
            return new MapperPoderes().mapperPoderes(obtener.obtenerListaPoderes());
        }

        public PoderModel obtenerPoder(string nombre)
        {
            ObtenerModelos obtener = new ObtenerModelos();
            return new MapperPoderes().mapperPoder(obtener.obtenerPoder(nombre));
        }

        public bool modificarPoder(PoderModel poder)
        {
            ModificarModelos modificar = new ModificarModelos();
            return modificar.modificarPoder(new MapperPoderes().modelToPoder(poder));
        }
    }
}
