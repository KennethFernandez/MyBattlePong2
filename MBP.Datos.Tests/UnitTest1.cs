using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MBP.Datos;
using MBP.Servicio;
using System.Diagnostics;
using MBP.EjeVertical;
using System.Collections.Generic;
using MBP.Logica;
namespace MBP.Datos.Tests
{
    [TestClass]
    public class UnitTest1
    {
        public int armarTablero(int J1,int J2, int disparos)
        {
            PartidaModel partida = new PartidaModel();
            partida.disparos = disparos;
            partida.idJugadorCreador = J1;
            partida.permisos = true;
            partida.tamano = 10;
            FachadaServicio fachadaServicio = new FachadaServicio();
            int idPartida = fachadaServicio.ingresarPartidaOnline(partida);
            Assert.AreNotEqual(idPartida,0);


            List<CasillaModel> casillas = new List<CasillaModel>();
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
            casillas.Add(casilla1);
            casillas.Add(casilla2);
            casillas.Add(casilla3);
            casillas.Add(casilla4);

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
            casillas.Add(casilla5);
            casillas.Add(casilla6);
            casillas.Add(casilla7);
            casillas.Add(casilla8);

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
            casillas.Add(casilla9);
            casillas.Add(casilla10);
            casillas.Add(casilla11);
            casillas.Add(casilla12);


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
            int idPartida = armarTablero(2, 4 , 10);
            FachadaServicio fachadaServicio = new FachadaServicio();

            DisparoModel disparo = new DisparoModel();
            disparo.x = 0;
            disparo.y = 0;
            disparo.idPartida = idPartida;
            disparo.idJugador = 2;
            disparo.tipoDisparo = 1;

            Assert.AreEqual(fachadaServicio.disparo(disparo).resultado,Constantes.disparoExitoso);
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
            int idPartida = armarTablero(2, 4 , 4);
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
            Assert.AreEqual(fachadaServicio.disparo(disparo).resultado, Constantes.disparoEscudo);
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

            disparo.idJugador = 4;
            disparo.x = 6;
            disparo.y = 2;
            Assert.AreEqual(fachadaServicio.disparo(disparo).resultado, Constantes.disparoEscudo);
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

            disparo.idJugador = 2;
            disparo.x = 1;
            disparo.y = 4;
            Assert.AreEqual(fachadaServicio.disparo(disparo).resultado, Constantes.disparoExitoso);
            disparo.x = 1;
            disparo.y = 5;
            Assert.AreEqual(fachadaServicio.disparo(disparo).resultado, Constantes.disparoExitoso);
            disparo.x = 2;
            disparo.y = 4;
            Assert.AreEqual(fachadaServicio.disparo(disparo).resultado, Constantes.disparoEscudo);
            Assert.AreEqual(fachadaServicio.disparo(disparo).resultado, Constantes.disparoExitoso);
            disparo.x = 2;
            disparo.y = 5;
            Assert.AreEqual(fachadaServicio.disparo(disparo).resultado, Constantes.disparoEscudo);
            fachadaServicio.pasarTurnoPartida(idPartida);
            Assert.AreEqual(fachadaServicio.disparo(disparo).resultado, Constantes.disparoExitoso);

            Partida partidaDatos = new ObtenerModelos().buscarPartida(idPartida);
            Assert.AreEqual(70,partidaDatos.PuntajeJugador1);
            Assert.AreEqual(60,partidaDatos.PuntajeJugador2);
            Assert.AreEqual(16, partidaDatos.DisparosTotalesJugador1);
            Assert.AreEqual(10, partidaDatos.DisparosTotalesJugador2);
            Assert.AreEqual(12, partidaDatos.DisparosExitososJugador1);
            Assert.AreEqual(8, partidaDatos.DisparosExitososJugador2);
        }



        [TestMethod]
        public void TestMethod5()
        {
            int idPartida = armarTablero(2, 4, 5);
            FachadaServicio fachadaServicio = new FachadaServicio();
            int cantidadCasillas = new ObtenerModelos().consultarSiNaveDestruida(1, idPartida, 1);
            Assert.AreEqual(4, cantidadCasillas);
        }
    }
}
