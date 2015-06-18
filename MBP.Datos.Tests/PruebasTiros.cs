using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MBP.Logica;
using MBP.Servicio;
using System.Collections.Generic;
using MBP.CapaTransversal.ModelsMVC;

namespace MBP.Datos.Tests
{
    [TestClass]
    public class PruebasTiros
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
            casilla2.idNave = 1;
            casilla2.X = 5;
            casilla2.Y = 2;
            casillas.Add(casilla2);

            // Tercera nave
            CasillaModel casilla3 = new CasillaModel();
            casilla3.idNave = 1;
            casilla3.X = 1;
            casilla3.Y = 4;
            casillas.Add(casilla3);


            TableroModel tablero = new TableroModel();
            tablero.idJugador = J1;
            tablero.idPartida = idPartida;
            tablero.tablero = casillas;

            // Genera el escudo es la posicion
            tablero.escudoX = 0;
            tablero.escudoY = 1;

            fachadaServicio.agregarTableroOnline(tablero);
            tablero.idJugador = J2;

            // Genera el escudo es la posicion
            tablero.escudoX = 0;
            tablero.escudoY = 1;
            fachadaServicio.agregarTableroOnline(tablero);

            return idPartida;
        }


        [TestMethod]
        public void TestMethod1()
        {
            int idPartida = armarTablero(2, 4, 10);
            FachadaServicio fachadaServicio = new FachadaServicio();

            DisparoModel disparo = new DisparoModel();
            disparo.x = 0;
            disparo.y = 0;
            disparo.idPartida = idPartida;
            disparo.idJugador = 2;
            disparo.tipoDisparo = 1;

            Assert.AreEqual(fachadaServicio.disparo(disparo).resultado, Constantes.disparoExitoso);
            Assert.AreEqual(fachadaServicio.disparo(disparo).resultado, Constantes.disparoFallido);

            disparo.x = 1;
            disparo.y = 0;
            Assert.AreEqual(fachadaServicio.disparo(disparo).resultado, Constantes.disparoExitoso);
            Assert.AreEqual(fachadaServicio.disparo(disparo).resultado, Constantes.disparoFallido);
            disparo.x = 0;
            disparo.y = 1;
            Assert.AreEqual(fachadaServicio.disparo(disparo).resultado, Constantes.disparoEscudo);
            Assert.AreEqual(fachadaServicio.disparo(disparo).resultado, Constantes.disparoExitoso);
            Assert.AreEqual(fachadaServicio.disparo(disparo).resultado, Constantes.disparoFallido);
            disparo.x = 1;
            disparo.y = 1;
            Assert.AreEqual(fachadaServicio.disparo(disparo).resultado, Constantes.disparoExitoso);
            Assert.AreEqual(fachadaServicio.disparo(disparo).resultado, Constantes.disparoFallido);


            Partida partidaDatos = new ObtenerModelos().buscarPartida(idPartida);
            Assert.AreEqual(partidaDatos.DisparosJugador1, new ObtenerModelos().obtieneNave(2).Puntaje);

        }

        [TestMethod]
        public void TestMethod2()
        {
            int idPartida = armarTablero(2, 4, 4);
            FachadaServicio fachadaServicio = new FachadaServicio();

            DisparoModel disparo = new DisparoModel();
            disparo.idPartida = idPartida;
            disparo.idJugador = 2;
            disparo.tipoDisparo = 1;

            disparo.x = 0;
            disparo.y = 0;
            Assert.AreEqual(fachadaServicio.disparo(disparo).resultado, Constantes.disparoExitoso);
            Assert.AreEqual(fachadaServicio.disparo(disparo).resultado, Constantes.disparoFallido);
            disparo.x = 1;
            disparo.y = 0;
            Assert.AreEqual(fachadaServicio.disparo(disparo).resultado, Constantes.disparoExitoso);
            Assert.AreEqual(fachadaServicio.disparo(disparo).resultado, Constantes.disparoFallido);
            disparo.x = 0;
            disparo.y = 1;
            Assert.AreEqual(fachadaServicio.disparo(disparo), null);
            Assert.AreEqual(fachadaServicio.disparo(disparo), null);
            disparo.idJugador = 4;
            disparo.x = 1;
            disparo.y = 1;
            Assert.AreEqual(fachadaServicio.disparo(disparo).resultado, Constantes.disparoExitoso);
            Assert.AreEqual(fachadaServicio.disparo(disparo).resultado, Constantes.disparoFallido);
        }

        [TestMethod]
        public void TestMethod3()
        {
            int idPartida = armarTablero(4, 2, 10);
            FachadaServicio fachadaServicio = new FachadaServicio();

            DisparoModel disparo = new DisparoModel();
            disparo.idPartida = idPartida;
            disparo.idJugador = 4;
            disparo.tipoDisparo = 1;

            disparo.x = 0;
            disparo.y = 0;
            Assert.AreEqual(fachadaServicio.disparo(disparo).resultado, Constantes.disparoExitoso);
            Assert.AreEqual(fachadaServicio.disparo(disparo).resultado, Constantes.disparoFallido);
            fachadaServicio.pasarTurnoPartida(idPartida);
            disparo.x = 1;
            disparo.y = 0;
            disparo.idJugador = 2;
            Assert.AreEqual(fachadaServicio.disparo(disparo).resultado, Constantes.disparoExitoso);
            Assert.AreEqual(fachadaServicio.disparo(disparo).resultado, Constantes.disparoFallido);
            disparo.x = 0;
            disparo.y = 1;
            fachadaServicio.pasarTurnoPartida(idPartida);
            Assert.AreEqual(fachadaServicio.disparo(disparo), null);
            disparo.idJugador = 4;
            Assert.AreEqual(fachadaServicio.disparo(disparo).resultado, Constantes.disparoEscudo);
            disparo.x = 1;
            disparo.y = 1;
            fachadaServicio.pasarTurnoPartida(idPartida);
            disparo.idJugador = 2;
            Assert.AreEqual(fachadaServicio.disparo(disparo).resultado, Constantes.disparoExitoso);
            Assert.AreEqual(fachadaServicio.disparo(disparo).resultado, Constantes.disparoFallido);
        }

        [TestMethod]
        public void TestMethod4()
        {
            int idPartida = armarTablero(2, 4, 5);
            FachadaServicio fachadaServicio = new FachadaServicio();

            DisparoModel disparo = new DisparoModel();
            disparo.idPartida = idPartida;
            disparo.idJugador = 2;
            disparo.tipoDisparo = 1;

            disparo.x = 0;
            disparo.y = 0;
            Assert.AreEqual(fachadaServicio.disparo(disparo).resultado, Constantes.disparoExitoso);
            disparo.x = 1;
            disparo.y = 0;
            Assert.AreEqual(fachadaServicio.disparo(disparo).resultado, Constantes.disparoExitoso);
            disparo.x = 0;
            disparo.y = 1;
            Assert.AreEqual(fachadaServicio.disparo(disparo).resultado, Constantes.disparoEscudo);
            Assert.AreEqual(fachadaServicio.disparo(disparo).resultado, Constantes.disparoExitoso);
            disparo.x = 1;
            disparo.y = 1;
            Assert.AreEqual(fachadaServicio.disparo(disparo).resultado, Constantes.disparoExitoso);

            disparo.idJugador = 4;
            disparo.x = 0;
            disparo.y = 0;
            Assert.AreEqual(fachadaServicio.disparo(disparo).resultado, Constantes.disparoExitoso);
            disparo.x = 1;
            disparo.y = 0;
            Assert.AreEqual(fachadaServicio.disparo(disparo).resultado, Constantes.disparoExitoso);
            disparo.x = 0;
            disparo.y = 1;
            Assert.AreEqual(fachadaServicio.disparo(disparo).resultado, Constantes.disparoEscudo);
            Assert.AreEqual(fachadaServicio.disparo(disparo).resultado, Constantes.disparoExitoso);
            disparo.x = 1;
            disparo.y = 1;
            Assert.AreEqual(fachadaServicio.disparo(disparo).resultado, Constantes.disparoExitoso);

            disparo.idJugador = 2;
            disparo.x = 6;
            disparo.y = 2;
            Assert.AreEqual(fachadaServicio.disparo(disparo).resultado, Constantes.disparoExitoso);
            disparo.x = 6;
            disparo.y = 3;
            Assert.AreEqual(fachadaServicio.disparo(disparo).resultado, Constantes.disparoExitoso);
            disparo.x = 5;
            disparo.y = 2;
            Assert.AreEqual(fachadaServicio.disparo(disparo).resultado, Constantes.disparoExitoso);
            disparo.x = 5;
            disparo.y = 3;
            Assert.AreEqual(fachadaServicio.disparo(disparo).resultado, Constantes.disparoExitoso);

            fachadaServicio.pasarTurnoPartida(idPartida);

            disparo.idJugador = 4;
            disparo.x = 6;
            disparo.y = 2;
            Assert.AreEqual(fachadaServicio.disparo(disparo).resultado, Constantes.disparoExitoso);
            disparo.x = 6;
            disparo.y = 3;
            Assert.AreEqual(fachadaServicio.disparo(disparo).resultado, Constantes.disparoExitoso);
            disparo.x = 5;
            disparo.y = 2;
            Assert.AreEqual(fachadaServicio.disparo(disparo).resultado, Constantes.disparoExitoso);
            disparo.x = 5;
            disparo.y = 3;
            Assert.AreEqual(fachadaServicio.disparo(disparo).resultado, Constantes.disparoExitoso);

            fachadaServicio.pasarTurnoPartida(idPartida);

            disparo.idJugador = 2;
            disparo.x = 1;
            disparo.y = 4;
            Assert.AreEqual(fachadaServicio.disparo(disparo).resultado, Constantes.disparoExitoso);
            disparo.x = 1;
            disparo.y = 5;
            Assert.AreEqual(fachadaServicio.disparo(disparo).resultado, Constantes.disparoExitoso);
            disparo.x = 2;
            disparo.y = 4;
            Assert.AreEqual(fachadaServicio.disparo(disparo).resultado, Constantes.disparoExitoso);
            disparo.x = 2;
            disparo.y = 5;
            Assert.AreEqual(fachadaServicio.disparo(disparo).finalPartida, true);

            int cantidadCasillas = new ObtenerModelos().navesSinDestruir(idPartida, 2);
            Assert.AreEqual(0, cantidadCasillas);
            cantidadCasillas = new ObtenerModelos().navesSinDestruir(idPartida, 1);
        }



        [TestMethod]
        public void TestMethod5()
        {
            int idPartida = armarTablero(2, 4, 5);
            FachadaServicio fachadaServicio = new FachadaServicio();
            int cantidadCasillas = new ObtenerModelos().navesSinDestruir(idPartida, 1);
            Assert.AreEqual(12, cantidadCasillas);
        }

        [TestMethod]
        public void TestMethod6()
        {
            int idPartida = armarTablero(2, 4, 10);
            FachadaServicio fachadaServicio = new FachadaServicio();

            DisparoModel disparo = new DisparoModel();
            disparo.idPartida = idPartida;
            disparo.idJugador = 2;
            disparo.tipoDisparo = 1;

            disparo.x = 1;
            disparo.y = 1;
            Assert.AreEqual(fachadaServicio.disparo(disparo).resultado, Constantes.disparoExitoso);
            disparo.tipoDisparo = Constantes.tipoDisparo_1H;
            disparo.dir = -1;
            DisparoModel2 res = fachadaServicio.disparo(disparo);
            Assert.AreEqual(2, res.casillas.Count);
            int[] casilla1 = res.casillas[0];
            int[] casilla2 = res.casillas[1];
            Assert.AreEqual(Constantes.disparoFallido, casilla1[2]);
            Assert.AreEqual(Constantes.disparoEscudo, casilla2[2]);

            disparo.x = 0;
            disparo.y = 1;
            Assert.AreEqual(fachadaServicio.disparo(disparo).resultado, Constantes.disparoExitoso);

            disparo.x = 0;
            disparo.y = 0;
            disparo.tipoDisparo = Constantes.tipoDisparo_1H;
            disparo.dir = 1;
            res = fachadaServicio.disparo(disparo);
            Assert.AreEqual(Constantes.disparoExitoso,res.resultado);
            Assert.AreEqual(1, res.casillas.Count);
            int [] casilla = res.casillas[0];
            Assert.AreEqual(Constantes.disparoExitoso, casilla[2]);

            disparo.x = 2;
            disparo.y = 0;
            disparo.tipoDisparo = Constantes.tipoDisparo_1H;
            disparo.dir = -1;
            res = fachadaServicio.disparo(disparo);
            Assert.AreEqual(2, res.casillas.Count);
            casilla1 = res.casillas[0];
            casilla2 = res.casillas[1];
            Assert.AreEqual(Constantes.disparoFallido, casilla1[2]);
            Assert.AreEqual(Constantes.disparoExitoso, casilla2[2]);


            disparo.x = 8;
            disparo.y = 7;
            disparo.tipoDisparo = Constantes.tipoDisparo_1H;
            disparo.dir = 1;
            res = fachadaServicio.disparo(disparo);
            Assert.AreEqual(2, res.casillas.Count);
            casilla1 = res.casillas[0];
            casilla2 = res.casillas[1];
            Assert.AreEqual(Constantes.disparoFallido, casilla1[2]);
            Assert.AreEqual(8, casilla1[0]);
            Assert.AreEqual(7, casilla1[1]);
            Assert.AreEqual(Constantes.disparoFallido, casilla2[2]);
            Assert.AreEqual(9, casilla2[0]);
            Assert.AreEqual(7, casilla2[1]);

            Partida partidaDatos = new ObtenerModelos().buscarPartida(idPartida);
            Assert.AreEqual(partidaDatos.DisparosJugador1, new ObtenerModelos().obtieneNave(2).Puntaje);

        }

        [TestMethod]
        public void TestMethod7()
        {
            int idPartida = armarTablero(2, 4, 10);
            FachadaServicio fachadaServicio = new FachadaServicio();

            DisparoModel disparo = new DisparoModel();
            disparo.idPartida = idPartida;
            disparo.idJugador = 2;
            disparo.tipoDisparo = 1;

            disparo.x = 1;
            disparo.y = 1;
            Assert.AreEqual(fachadaServicio.disparo(disparo).resultado, Constantes.disparoExitoso);

            disparo.x = 1;
            disparo.y = 0;
            Assert.AreEqual(fachadaServicio.disparo(disparo).resultado, Constantes.disparoExitoso);

            disparo.x = 0;
            disparo.y = 1;
            disparo.tipoDisparo = Constantes.tipoDisparo_1V;
            disparo.dir = -1;
            DisparoModel2 res = fachadaServicio.disparo(disparo);
            Assert.AreEqual(2, res.casillas.Count);
            int[] casilla1 = res.casillas[0];
            int[] casilla2 = res.casillas[1];
            Assert.AreEqual(Constantes.disparoEscudo, casilla1[2]);
            Assert.AreEqual(Constantes.disparoExitoso, casilla2[2]);

            disparo.x = 0;
            disparo.y = 1;
            Assert.AreEqual(fachadaServicio.disparo(disparo).resultado, Constantes.disparoExitoso);

            disparo.x = 8;
            disparo.y = 7;
            disparo.tipoDisparo = Constantes.tipoDisparo_1H;
            disparo.dir = 1;
            res = fachadaServicio.disparo(disparo);
            Assert.AreEqual(2, res.casillas.Count);
            casilla1 = res.casillas[0];
            casilla2 = res.casillas[1];
            Assert.AreEqual(Constantes.disparoFallido, casilla1[2]);
            Assert.AreEqual(8, casilla1[0]);
            Assert.AreEqual(7, casilla1[1]);
            Assert.AreEqual(Constantes.disparoFallido, casilla2[2]);
            Assert.AreEqual(9, casilla2[0]);
            Assert.AreEqual(7, casilla2[1]);

            Partida partidaDatos = new ObtenerModelos().buscarPartida(idPartida);
            Assert.AreEqual(partidaDatos.DisparosJugador1, new ObtenerModelos().obtieneNave(2).Puntaje);

        }

        [TestMethod]
        public void TestMethod8()
        {
            int idPartida = armarTablero(2, 4, 10);
            FachadaServicio fachadaServicio = new FachadaServicio();

            DisparoModel disparo = new DisparoModel();
            disparo.idPartida = idPartida;
            disparo.idJugador = 2;
            disparo.tipoDisparo = Constantes.tipoDisparoBomba;

            disparo.x = 1;
            disparo.y = 1;

            DisparoModel2 res = fachadaServicio.disparo(disparo);
            Assert.AreEqual(4, res.casillas.Count);
            int[] casilla1 = res.casillas[0];
            int[] casilla2 = res.casillas[1];
            int[] casilla3 = res.casillas[2];
            int[] casilla4 = res.casillas[3];
            Assert.AreEqual(2, casilla1[2]);
            Assert.AreEqual(2, casilla2[2]);
            Assert.AreEqual(2, casilla3[2]);
            Assert.AreEqual(2, casilla4[2]);

            Assert.AreEqual(1, casilla1[0]);
            Assert.AreEqual(0, casilla2[0]);
            Assert.AreEqual(0, casilla3[0]);
            Assert.AreEqual(1, casilla4[0]);

            Assert.AreEqual(1, casilla1[1]);
            Assert.AreEqual(0, casilla2[1]);
            Assert.AreEqual(1, casilla3[1]);
            Assert.AreEqual(0, casilla4[1]);


            //Partida partidaDatos = new ObtenerModelos().buscarPartida(idPartida);
            //Assert.AreEqual(partidaDatos.DisparosJugador1, new ObtenerModelos().obtieneNave(2).Puntaje);

        }
    }
}
