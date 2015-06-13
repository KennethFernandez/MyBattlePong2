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
        [TestMethod]
        public void TestMethod1()
        {
            PartidaModel partida = new PartidaModel();
            partida.disparos = 10;
            partida.idJugadorCreador = 4;
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
            tablero.idJugador = 4;
            tablero.idPartida = idPartida;
            tablero.tablero = casillas;

            Assert.AreEqual(fachadaServicio.agregarTableroOnline(tablero),true);
            tablero.idJugador = 2;
            Assert.AreEqual(fachadaServicio.agregarTableroOnline(tablero),true);

            DisparoModel disparo = new DisparoModel();
            disparo.x = 0;
            disparo.y = 0;
            disparo.idPartida = idPartida;
            disparo.idJugador = 4;

            Assert.AreEqual(fachadaServicio.disparo(disparo),Constantes.disparoExitoso);
            Assert.AreEqual(fachadaServicio.disparo(disparo),Constantes.disparoFallido);
            disparo.x = 1;
            disparo.y = 0;
            Assert.AreEqual(fachadaServicio.disparo(disparo),Constantes.disparoExitoso);
            Assert.AreEqual(fachadaServicio.disparo(disparo),Constantes.disparoFallido);
            disparo.x = 0;
            disparo.y = 1;
            Assert.AreEqual(fachadaServicio.disparo(disparo),Constantes.disparoEscudo);
            Assert.AreEqual(fachadaServicio.disparo(disparo),Constantes.disparoExitoso);
            Assert.AreEqual(fachadaServicio.disparo(disparo), Constantes.disparoFallido);
            disparo.x = 1;
            disparo.y = 1;
            Assert.AreEqual(fachadaServicio.disparo(disparo),Constantes.disparoExitoso);
            Assert.AreEqual(fachadaServicio.disparo(disparo),Constantes.disparoFallido);


            Partida partidaDatos = new ObtenerModelos().buscarPartida(idPartida);
            Assert.AreEqual(partidaDatos.DisparosJugador1, new ObtenerModelos().obtieneNave(2).Puntaje);
        }

        [TestMethod]
        public void TestMethod2()
        {
            PartidaModel partida = new PartidaModel();
            partida.disparos = 4;
            partida.idJugadorCreador = 4;
            partida.permisos = true;
            partida.tamano = 10;
            FachadaServicio fachadaServicio = new FachadaServicio();
            int idPartida = fachadaServicio.ingresarPartidaOnline(partida);
            Assert.AreNotEqual(idPartida, 0);


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

            // Jugador 1 es con el id 4
            TableroModel tablero = new TableroModel();
            tablero.idJugador = 4;
            tablero.idPartida = idPartida;
            tablero.tablero = casillas;

            // Jugador 2 es con el id 2
            Assert.AreEqual(fachadaServicio.agregarTableroOnline(tablero), true);
            tablero.idJugador = 2;
            Assert.AreEqual(fachadaServicio.agregarTableroOnline(tablero), true);

            DisparoModel disparo = new DisparoModel();
            disparo.idPartida = idPartida;
            disparo.idJugador = 4;


            disparo.x = 0;
            disparo.y = 0;
            Assert.AreEqual(fachadaServicio.disparo(disparo), Constantes.disparoExitoso);
            Assert.AreEqual(fachadaServicio.disparo(disparo), Constantes.disparoFallido);
            disparo.x = 1;
            disparo.y = 0;
            Assert.AreEqual(fachadaServicio.disparo(disparo), Constantes.disparoExitoso);
            Assert.AreEqual(fachadaServicio.disparo(disparo), Constantes.disparoFallido);
            disparo.x = 0;
            disparo.y = 1;
            Assert.AreEqual(fachadaServicio.disparo(disparo), Constantes.disparoNoEsSuTurno);
            Assert.AreEqual(fachadaServicio.disparo(disparo), Constantes.disparoNoEsSuTurno);
            disparo.idJugador = 2;
            disparo.x = 1;
            disparo.y = 1;
            Assert.AreEqual(fachadaServicio.disparo(disparo), Constantes.disparoExitoso);
            Assert.AreEqual(fachadaServicio.disparo(disparo), Constantes.disparoFallido);
        }

        [TestMethod]
        public void TestMethod3()
        {
            PartidaModel partida = new PartidaModel();
            partida.disparos = 1;
            partida.idJugadorCreador = 4;
            partida.permisos = true;
            partida.tamano = 10;
            FachadaServicio fachadaServicio = new FachadaServicio();
            int idPartida = fachadaServicio.ingresarPartidaOnline(partida);
            Assert.AreNotEqual(idPartida, 0);


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

            // Jugador 1 es con el id 4
            TableroModel tablero = new TableroModel();
            tablero.idJugador = 4;
            tablero.idPartida = idPartida;
            tablero.tablero = casillas;

            // Jugador 2 es con el id 2
            Assert.AreEqual(fachadaServicio.agregarTableroOnline(tablero), true);
            tablero.idJugador = 2;
            Assert.AreEqual(fachadaServicio.agregarTableroOnline(tablero), true);

            DisparoModel disparo = new DisparoModel();
            disparo.idPartida = idPartida;
            disparo.idJugador = 4;


            disparo.x = 0;
            disparo.y = 0;
            Assert.AreEqual(fachadaServicio.disparo(disparo), Constantes.disparoExitoso);
            Assert.AreEqual(fachadaServicio.disparo(disparo), Constantes.disparoNoEsSuTurno);
            disparo.idJugador = 2;
            disparo.x = 1;
            disparo.y = 0;
            Assert.AreEqual(fachadaServicio.disparo(disparo), Constantes.disparoExitoso);
            Assert.AreEqual(fachadaServicio.disparo(disparo), Constantes.disparoNoEsSuTurno);
            disparo.x = 0;
            disparo.y = 1;
            disparo.idJugador = 4;
            Assert.AreEqual(fachadaServicio.disparo(disparo), Constantes.disparoEscudo);
            disparo.idJugador = 2;
            Assert.AreEqual(fachadaServicio.disparo(disparo), Constantes.disparoEscudo);
            disparo.x = 1;
            disparo.y = 1;
            disparo.idJugador = 4;
            Assert.AreEqual(fachadaServicio.disparo(disparo), Constantes.disparoExitoso);
            disparo.idJugador = 2;
            Assert.AreEqual(fachadaServicio.disparo(disparo), Constantes.disparoExitoso);
        }
    }
}
