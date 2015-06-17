using MBP.Datos;
using MBP.EjeVertical.ModelsMVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBP.Logica
{
    public class MapperNavesPartida
    {
        public List<NaveModel2> mapperNavesDatosANavesModel2(List<Partida_Nave> naves)
        {
            List<NaveModel2> resultado = new List<NaveModel2>();
            foreach (Partida_Nave item in naves)
            {
                NaveModel2 naveModel2 = new NaveModel2();
                naveModel2.cantidad = item.Cantidad;
                naveModel2.idNave = item.Nave_idNave;
                ///////
                Nave nave = new ObtenerModelos().obtieneNave(item.Nave_idNave);
                ///////
                naveModel2.imagen = nave.Imagen;
                naveModel2.nombre = nave.Nombre;
                naveModel2.tamanoX = nave.TamanoX;
                naveModel2.tamanoY = nave.TamanoY;
                resultado.Add(naveModel2);
            }
            return resultado;
        }
    }
}
