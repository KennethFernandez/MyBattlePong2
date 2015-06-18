using MBP.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBP.Logica
{
    public class GestionarPartidaVivo
    {
        public void ingresaPartidaVivo(){
            
        }

        public void obtenerPartidasVivo()
        {

        }

        public bool disparoDispositivo(int numVaso, int idDispositivo)
        {
            if (numVaso != -1)
            {
                return false;
            }
            else
            {

                return new GestionarDispositivos().actualizarDispositivo(idDispositivo);
            }
        }
 
    }
}
