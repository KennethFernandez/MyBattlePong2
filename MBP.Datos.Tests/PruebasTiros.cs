using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MBP.EjeVertical;
using MBP.Logica;
using MBP.Servicio;
using System.Collections.Generic;

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
            Assert.AreEqual(fachadaServicio.disparo(disparo).resultado, Constantes.disparoNoEsSuTurno);
            Assert.AreEqual(fachadaServicio.disparo(disparo).resultado, Constantes.disparoNoEsSuTurno);
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
            Assert.AreEqual(fachadaServicio.disparo(disparo).resultado, Constantes.disparoNoEsSuTurno);
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
            Assert.AreEqual(fachadaServicio.disparo(disparo).resultado, Constantes.disparoFinal);

            int cantidadCasillas = new ObtenerModelos().navesSinDestruir(idPartida, 2);
            Assert.AreEqual(0, cantidadCasillas);
            cantidadCasillas = new ObtenerModelos().navesSinDestruir(idPartida, 1);
            //            Assert.AreEqual(4, cantidadCasillas);
            /**
            Partida partidaDatos = new ObtenerModelos().buscarPartida(idPartida);
            Assert.AreEqual(90,partidaDatos.PuntajeJugador1);
            Assert.AreEqual(60,partidaDatos.PuntajeJugador2);
            Assert.AreEqual(13, partidaDatos.DisparosTotalesJugador1);
            Assert.AreEqual(9, partidaDatos.DisparosTotalesJugador2);
            Assert.AreEqual(12, partidaDatos.DisparosExitososJugador1);
            Assert.AreEqual(8, partidaDatos.DisparosExitososJugador2);
            **/
        }



        [TestMethod]
        public void TestMethod5()
        {
            int idPartida = armarTablero(2, 4, 5);
            FachadaServicio fachadaServicio = new FachadaServicio();
            int cantidadCasillas = new ObtenerModelos().navesSinDestruir(idPartida, 1);
            Assert.AreEqual(12, cantidadCasillas);
        }
    }
}
