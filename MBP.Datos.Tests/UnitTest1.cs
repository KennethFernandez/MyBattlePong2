using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MBP.Datos;
using MBP.CapaTransversal.ModelsMVC;
using MBP.Servicio;
namespace MBP.Datos.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            InicioModel inicio = new InicioModel();
            inicio.Usuario = "alonso";
            inicio.Contrasena = "hola";
            FachadaServicio fachada = new FachadaServicio();
            UsuarioModel usuario = fachada.verificarLogin(inicio);
            Assert.AreEqual(usuario.datos[0,1],"1");
        }
    }
}
