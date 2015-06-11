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
            Debug.Write("Prueba iniciada");
            PartidaModel partida = new PartidaModel();
            partida.disparos = 12;
            partida.idJugadorCreador = 4;
            partida.permisos = true;
            int[,] naves = new int[7, 2] { { 1, 3 }, { 2, 4 }, { 3, 1 }, { 4, 4 }, { 5, 3 }, { 6, 3 }, { 4, 5 } };
            partida.navesTipo = naves;
            partida.tamano = 10;
            new FachadaServicio().IngresarPartidaOnline(partida);
            Debug.Write("Prueba iniciada");
            return "respuesta: " + new FachadaServicioMPL().ProcesarDisapro(numVaso, idDispositivo);
        }
    }
}