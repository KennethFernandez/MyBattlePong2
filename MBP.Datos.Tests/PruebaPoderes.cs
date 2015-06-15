using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics;
using MBP.Logica;
using MBP.Servicio;

namespace MBP.Datos.Tests
{
    [TestClass]
    public class PruebaPoderes
    {
        [TestMethod]
        public void TestMethod1()
        {
            ObtenerModelos obtener  = new ObtenerModelos();
            List<Poder> lista1 = obtener.obtenerPoderesJugador(2);
            List<Poder> lista2 = obtener.obtenerPoderesJugador(4);
            int resultado1 = lista1.Count;
            int resultado2 = lista2.Count;
            Assert.AreEqual(lista1[0].Nombre, obtener.obtenerPoder(1).Nombre);
            Assert.AreEqual(lista1[1].Nombre, obtener.obtenerPoder(2).Nombre);
            Assert.AreEqual(lista1[2].Nombre, obtener.obtenerPoder(6).Nombre);
            Assert.AreEqual(lista1[3].Nombre, obtener.obtenerPoder(9).Nombre);
            Assert.AreEqual(lista2[0].Nombre, obtener.obtenerPoder(3).Nombre);
            Assert.AreEqual(lista2[1].Nombre, obtener.obtenerPoder(8).Nombre);
            Assert.AreEqual(lista2[2].Nombre, obtener.obtenerPoder(10).Nombre);
            Assert.AreEqual(10, new ObtenerModelos().obtenerListaPoderes().Count);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Assert.AreEqual(0,new GestionPoderesJugador().actualizarPoderesJugador(2).Count);
        }

    }
}
