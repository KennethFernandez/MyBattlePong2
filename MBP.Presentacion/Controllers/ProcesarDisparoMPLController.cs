using MBP.Servicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace MBP.Presentacion.Controllers
{
    public class ProcesarDisparoMPLController : ApiController
    {
        public string Get(int numVaso, int idDispositivo)
        {
            return "respuesta: " + new FachadaServicioMPL().ProcesarDisapro(numVaso, idDispositivo);
        }

    }
}
