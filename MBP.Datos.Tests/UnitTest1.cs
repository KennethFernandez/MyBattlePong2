using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MBP.Datos;
namespace MBP.Datos.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {   
            ObtenerModelos datos = new ObtenerModelos();
            string nombre = "alonso";
            CuentaUser prueba = datos.ObtenerUser(nombre);
            Assert.AreEqual(prueba.Password, "hola");  
        }
    }
}
