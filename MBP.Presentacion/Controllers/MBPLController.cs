using MBP.CapaTransversal.ModelsMVC;
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
            //PartidaModel partida = new PartidaModel();
            //partida.disparos = 12;
            //partida.idJugadorCreador = 4;
            //partida.permisos = true;
            //int[,] naves = new int[7, 2] { { 1, 3 }, { 2, 4 }, { 3, 1 }, { 4, 4 }, { 5, 3 }, { 6, 3 }, { 4, 5 } };
            //partida.navesTipo = naves;
            //partida.tamano = 10;
            //new FachadaServicio().IngresarPartidaOnline(partida);

            // Primera nave
            CasillaModel casilla1 = new CasillaModel();
            CasillaModel casilla2 = new CasillaModel();
            CasillaModel casilla3 = new CasillaModel();
            CasillaModel casilla4 = new CasillaModel();
            casilla1.idNave = 1;
            casilla2.idNave = 1;
            casilla3.idNave = 1;
            casilla4.idNave = 1;
            casilla1.idNaveTablero = 1;
            casilla2.idNaveTablero = 1;
            casilla3.idNaveTablero = 1;
            casilla4.idNaveTablero = 1;
            casilla1.X = 0;
            casilla1.Y = 0;
            casilla2.X = 1;
            casilla2.Y = 0;
            casilla3.X = 0;
            casilla3.Y = 1;
            casilla4.X = 1;
            casilla4.Y = 1;
            casilla1.poder = 0;
            casilla2.poder = 0;
            casilla3.poder = 1;
            casilla4.poder = 0;

            // Segunda nave
            CasillaModel casilla5 = new CasillaModel();
            CasillaModel casilla6 = new CasillaModel();
            CasillaModel casilla7 = new CasillaModel();
            CasillaModel casilla8 = new CasillaModel();
            casilla5.idNave = 1;
            casilla6.idNave = 1;
            casilla7.idNave = 1;
            casilla8.idNave = 1;
            casilla5.idNaveTablero = 2;
            casilla6.idNaveTablero = 2;
            casilla7.idNaveTablero = 2;
            casilla8.idNaveTablero = 2;
            casilla5.X = 5;
            casilla5.Y = 2;
            casilla6.X = 5;
            casilla6.Y = 3;
            casilla7.X = 6;
            casilla7.Y = 2;
            casilla8.X = 6;
            casilla8.Y = 3;
            casilla5.poder = 0;
            casilla6.poder = 0;
            casilla7.poder = 1;
            casilla8.poder = 0;

            // Tercera nave
            CasillaModel casilla9 = new CasillaModel();
            CasillaModel casilla10 = new CasillaModel();
            CasillaModel casilla11 = new CasillaModel();
            CasillaModel casilla12 = new CasillaModel();
            casilla9.idNave = 2;
            casilla10.idNave = 2;
            casilla11.idNave = 2;
            casilla12.idNave = 2;
            casilla9.idNaveTablero = 3;
            casilla10.idNaveTablero = 3;
            casilla11.idNaveTablero = 3;
            casilla12.idNaveTablero = 3;
            casilla9.X = 1;
            casilla9.Y = 4;
            casilla10.X = 1;
            casilla10.Y = 5;
            casilla11.X = 2;
            casilla11.Y = 4;
            casilla12.X = 2;
            casilla12.Y = 5;
            casilla9.poder = 0;
            casilla10.poder = 0;
            casilla11.poder = 1;
            casilla12.poder = 1;
            List<CasillaModel> casillas = new List<CasillaModel>();
            casillas.Add(casilla1);
            casillas.Add(casilla2);
            casillas.Add(casilla3);
            casillas.Add(casilla4);
            casillas.Add(casilla5);
            casillas.Add(casilla6);
            casillas.Add(casilla7);
            casillas.Add(casilla8);
            casillas.Add(casilla9);
            casillas.Add(casilla10);
            casillas.Add(casilla11);
            casillas.Add(casilla12);
            TableroModel tablero = new TableroModel();
            tablero.idJugador = 2;
            tablero.idPartida = 4;
            tablero.tablero = casillas;
            new FachadaServicio().AgregarTableroOnline(tablero);
            Debug.Write("Prueba iniciada");
            return "respuesta: " + new FachadaServicioMPL().ProcesarDisapro(numVaso, idDispositivo);
        }
    }
}