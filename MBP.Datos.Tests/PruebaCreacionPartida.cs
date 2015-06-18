using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MBP.CapaTransversal.ModelsMVC;
using MBP.Servicio;
using System.Collections.Generic;

namespace MBP.Datos.Tests
{
    [TestClass]
    public class PruebaCreacionPartida
    {

        public int armarTablero(int J1, int J2, int disparos)
        {

            PartidaModel partida = new PartidaModel();
            partida.disparos = disparos;
            partida.idJugadorCreador = J1;
            partida.permisos = true;
            partida.tamano = 10;
            List<int[]> naves = new List<int[]>();
            int[] nave = new int[2];
            nave[0] = 1;
            nave[1] = 3;
            naves.Add(nave);
            partida.naves = naves;
            FachadaServicio fachadaServicio = new FachadaServicio();
            int idPartida = fachadaServicio.ingresarPartidaOnline(partida);
            Assert.AreNotEqual(idPartida, 0);


            List<CasillaModel> casillas = new List<CasillaModel>();
            // Primera nave
            CasillaModel casilla1 = new CasillaModel();
            casilla1.idNave = 1;
            casilla1.X = 0;
            casilla1.Y = 0;
            casillas.Add(casilla1);

            // Segunda nave
            CasillaModel casilla2 = new CasillaModel();
            casilla2.idNave = 2;
            casilla2.X = 5;
            casilla2.Y = 2;
            casillas.Add(casilla2);

            // Tercera nave
            CasillaModel casilla3 = new CasillaModel();
            casilla3.idNave = 3;
            casilla3.X = 5;
            casilla3.Y = 5;
            casillas.Add(casilla3);

            // Cuarta nave
            CasillaModel casilla4 = new CasillaModel();
            casilla4.idNave = 4;
            casilla4.X = 5;
            casilla4.Y = 9;
            casillas.Add(casilla4);


            TableroModel tablero = new TableroModel();
            tablero.idJugador = J1;
            tablero.idPartida = idPartida;
            tablero.tablero = casillas;

            fachadaServicio.agregarTableroOnline(tablero);
            return idPartida;

        }
        [TestMethod]
        public void TestMethod1()
        {
            int idPartida1 = armarTablero(2, 4, 10);
            int idPartida2 = armarTablero(4, 2, 10);
            FachadaServicio fachada = new FachadaServicio();
            //List<PartidaModel2> partidas = fachada.partidasDisponiblesOnline();
        }
    }
}
