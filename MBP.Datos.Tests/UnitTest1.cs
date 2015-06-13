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
        public void FalloLogin()
        {
            InicioModel inicio = new InicioModel();
            inicio.Usuario = "pollo";
            inicio.Contrasena = "pollo1";
            FachadaServicio fachada = new FachadaServicio();
            UsuarioModel usuario = fachada.verificarLogin(inicio);
            Assert.AreEqual(usuario.datos[0,1],"-1");
        }

        [TestMethod]
        public void LoginCorrecto()
        {
            InicioModel inicio = new InicioModel();
            inicio.Usuario = "pollo";
            inicio.Contrasena = "pollo";
            FachadaServicio fachada = new FachadaServicio();
            UsuarioModel usuario = fachada.verificarLogin(inicio);
            Assert.AreEqual(usuario.datos[0, 1], "1");
        }
    }
}
