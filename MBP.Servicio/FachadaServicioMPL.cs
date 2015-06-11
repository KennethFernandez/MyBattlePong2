using MBP.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBP.Servicio
{
    public class FachadaServicioMPL
    {
        public bool ProcesarDisapro(int numVaso, int idDispositivo)
        {
            ProcesarDisparo procesarDisparo = new ProcesarDisparo();
            return procesarDisparo.ProcesarDisaproLive(numVaso, idDispositivo);
        }
    }
}
