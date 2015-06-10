using MBP.EjeVertical;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBP.Datos
{
    public class GestionarDispositivosDatos
    {
        public bool agregarDispositivo(DispositivoModel dispositivo){
            if (dispositivo.idDisposito == 1) // verifica si el dispositivo no existe
            {
                return true; // Si el dispositivo no esta en la tabla lo agrega
            }
            else
            {
                return false; // Si el dispositivo ya existe actualiza el tiempo de este
            }
        }

        /**
         * Retorna el ultimo tiempo en el que se actualizo el dispositivo
         **/
        public DispositivoModel buscarDispositivo(int idDispositivo)
        {
            DispositivoModel dispositivo = new DispositivoModel();
            if(idDispositivo == 1) // existe
            {
                dispositivo.idDisposito = idDispositivo;
                dispositivo.ultimaConexion = DateTime.Now;
            }
            else
            {
                dispositivo.idDisposito = -1;
            }
            return dispositivo; 
        }


    }
}
