using MBP.CapaTransversal.ModelsMVC;
using MBP.EjeVertical;
using MBP.Servicio;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MBP.Presentacion.Controllers
{
    public class MBPLController : ApiController
    {
        public string Get(int numVaso, int idDispositivo)
        {
            return "-"+new FachadaServicioMPL().ProcesarDisapro(numVaso, idDispositivo)+"-";
        }
    }
}