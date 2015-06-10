using MBP.Datos;
using MBP.EjeVertical;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBP.Logica
{
    public class GestionarDispositivos
    {
        public bool actualizarDispositivo(int idDispositivo)
        {
            DispositivoModel dispositivo = new DispositivoModel();
            dispositivo.idDisposito = idDispositivo;        // Asigna el id del dispositivo
            dispositivo.ultimaConexion = DateTime.Now;      // Asigna el tiempo en el que se hace la conexion
            return new GestionarDispositivosDatos().agregarDispositivo(dispositivo); // Agrega o actualiza el dispositivo
        }

        public bool verificarPresenciaDispositivo(int idDispositivo)
        {
            DispositivoModel dispositivo = new GestionarDispositivosDatos().buscarDispositivo(idDispositivo);
            if (dispositivo.idDisposito >= 0)       // verifica si el dispositivo existe
            {
                if (dispositivo.ultimaConexion <= DateTime.Now) // Verifica que el dispositivo se encuentre concetado desde antes
                {
                    return true;
                }
                else
                {
                    return false;
                }
                
            }
            else
            {
                return false; // Dispositivo no existe
            }
        }
    }
}
