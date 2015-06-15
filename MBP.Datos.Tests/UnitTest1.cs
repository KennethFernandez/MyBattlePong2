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
            Assert.AreEqual(usuario.datos[1,1],"-1");
        }

        [TestMethod]
        public void LoginCorrecto()
        {
            InicioModel inicio = new InicioModel();
            inicio.Usuario = "rlopez";
            inicio.Contrasena = "rlopez";
            FachadaServicio fachada = new FachadaServicio();
            UsuarioModel usuario = fachada.verificarLogin(inicio);
            Assert.AreEqual(usuario.datos[1, 1], "1");
        }

        [TestMethod]
        public void agregarUser()
        {
            FachadaServicio fachada = new FachadaServicio();
            CompositeRegModel model = new CompositeRegModel();
            model.ModeloBase = new RegistrarseModel();
            model.ModeloExt = new RegistrarseExtModel();
            model.ModeloJugador = new JugadorModel();
            model.ModeloModerador = new ModeradorModel();
            model.ModeloBase.Apellido = "Lopez";
            model.ModeloBase.Email = "rlopez@gmail.com";
            model.ModeloBase.Login = "rlopez0380";
            model.ModeloBase.Nombre = "rodrigo";
            model.ModeloBase.Password = "rlopez0380";
            model.ModeloBase.PasswordConf = "rlopez0380";
            model.ModeloBase.Tipo = "1";
            model.ModeloExt.FechaNacimiento = "12/24/1991";
            model.ModeloExt.Foto = "pathfoto";
            model.ModeloExt.Genero = "M";
            model.ModeloExt.Pais = "Costa Rica";
            model.ModeloJugador.DescripcionPersonal = "Me gusta la pizza";
            Assert.IsTrue(fachada.agregarNuevoUser(model));
            
        }


    }
}
