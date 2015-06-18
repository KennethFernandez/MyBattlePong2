using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using MBP.Logica;
using MBP.Servicio;
using MBP.CapaTransversal.ModelsMVC;

namespace MBP.Datos.Tests
{
    [TestClass]
    public class PruebaPoderes
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
            tablero.idJugador = J2;
            fachadaServicio.agregarTableroOnline(tablero);

            return idPartida;

        }

        [TestMethod]
        public void TestMethod1()
        {
            ObtenerModelos obtener = new ObtenerModelos();
            List<Poder> lista1 = obtener.obtenerPoderesJugador(2);
            List<Poder> lista2 = obtener.obtenerPoderesJugador(4);
            int resultado1 = lista1.Count;
            int resultado2 = lista2.Count;
            Assert.AreEqual(lista1[0].Nombre, obtener.obtenerPoder(1).Nombre);
            Assert.AreEqual(lista1[1].Nombre, obtener.obtenerPoder(4).Nombre);
            Assert.AreEqual(lista1[2].Nombre, obtener.obtenerPoder(9).Nombre);
            Assert.AreEqual(lista1[3].Nombre, obtener.obtenerPoder(10).Nombre);
            Assert.AreEqual(0,lista2.Count);
            Assert.AreEqual(10, new ObtenerModelos().obtenerListaPoderes().Count);
        }

        [TestMethod]
        public void TestMethod2()
        {
            int idPartida = armarTablero(2, 4, 10);
            //int idPartida = 282;
            FachadaServicio fachadaServicio = new FachadaServicio();
            // Tiros 1 = 10, tiros 2 = 10
            TableroModel2 tablero = fachadaServicio.recuperarTableroPartida(idPartida, 2);
            Assert.AreEqual(10,tablero.disparosRestantes);
            Assert.AreEqual(true,tablero.enMiTurno);

            fachadaServicio.pasarTurnoPartida(idPartida);
            tablero = fachadaServicio.recuperarTableroPartida(idPartida, 4);
            Assert.AreEqual(10,tablero.disparosRestantes);
            Assert.AreEqual(true,tablero.enMiTurno);

            fachadaServicio.pasarTurnoPartida(idPartida);
            fachadaServicio.activarPoder(2, idPartida, 1);
            tablero = fachadaServicio.recuperarTableroPartida(idPartida, 2);
            Assert.AreEqual(11,tablero.disparosRestantes);
            Assert.AreEqual(true,tablero.enMiTurno);

            fachadaServicio.pasarTurnoPartida(idPartida);
            fachadaServicio.activarPoder(4, idPartida, 3);                          // J4 + 1
            tablero = fachadaServicio.recuperarTableroPartida(idPartida, 4);
            Assert.AreEqual(11, tablero.disparosRestantes);
            Assert.AreEqual(true, tablero.enMiTurno);

            fachadaServicio.pasarTurnoPartida(idPartida);
            tablero = fachadaServicio.recuperarTableroPartida(idPartida, 2);
            Assert.AreEqual(10, tablero.disparosRestantes);
            Assert.AreEqual(true, tablero.enMiTurno);

            
            fachadaServicio.pasarTurnoPartida(idPartida);
            tablero = fachadaServicio.recuperarTableroPartida(idPartida, 4);
            Assert.AreEqual(11, tablero.disparosRestantes);
            Assert.AreEqual(true, tablero.enMiTurno);

            fachadaServicio.pasarTurnoPartida(idPartida);
            fachadaServicio.activarPoder(2, idPartida, 2);
            tablero = fachadaServicio.recuperarTableroPartida(idPartida, 2);
            Assert.AreEqual(13, tablero.disparosRestantes);
            Assert.AreEqual(true, tablero.enMiTurno);

            fachadaServicio.pasarTurnoPartida(idPartida);
            fachadaServicio.activarPoder(4, idPartida, 3);                      // J4 +1
            tablero = fachadaServicio.recuperarTableroPartida(idPartida, 4);
            Assert.AreEqual(12, tablero.disparosRestantes);
            Assert.AreEqual(true, tablero.enMiTurno);

            fachadaServicio.pasarTurnoPartida(idPartida);
            fachadaServicio.activarPoder(2, idPartida, 3);                      // J2 + 1
            tablero = fachadaServicio.recuperarTableroPartida(idPartida, 2);
            Assert.AreEqual(11, tablero.disparosRestantes);
            Assert.AreEqual(true, tablero.enMiTurno);

            fachadaServicio.pasarTurnoPartida(idPartida);
            tablero = fachadaServicio.recuperarTableroPartida(idPartida, 4);
            Assert.AreEqual(12, tablero.disparosRestantes);
            Assert.AreEqual(true, tablero.enMiTurno);

            fachadaServicio.pasarTurnoPartida(idPartida);
            tablero = fachadaServicio.recuperarTableroPartida(idPartida, 2);
            Assert.AreEqual(11, tablero.disparosRestantes);
            Assert.AreEqual(true, tablero.enMiTurno);

        }
    }
}
