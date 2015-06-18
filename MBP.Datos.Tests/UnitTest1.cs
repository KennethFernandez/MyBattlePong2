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
            inicio.Usuario = "kfer";
            inicio.Contrasena = "1234";
            FachadaServicio fachada = new FachadaServicio();
            UsuarioModel usuario = fachada.verificarLogin(inicio);
            Assert.AreEqual(usuario.datos[1, 1], "2");
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

        [TestMethod]
        public void modificarUser()
        {
            FachadaServicio fachada = new FachadaServicio();
            CompositeRegModel model = new CompositeRegModel();
            model.ModeloBase = new RegistrarseModel();
            model.ModeloExt = new RegistrarseExtModel();
            model.ModeloJugador = new JugadorModel();
            model.ModeloModerador = new ModeradorModel();
            model.ModeloBase.Apellido = "Lopez2";
            model.ModeloBase.Email = "rlopez@gmail.com";
            model.ModeloBase.Login = "rlopez0380";
            model.ModeloBase.Nombre = "rodrigo2";
            model.ModeloBase.Password = "rlopez0380";
            model.ModeloBase.PasswordConf = "rlopez0380";
            model.ModeloBase.Tipo = "1";
            model.ModeloBase.IdCuenta = 4;
            model.ModeloExt.FechaNacimiento = "12/24/1991";
            model.ModeloExt.Foto = "pathfoto";
            model.ModeloExt.Genero = "F";
            model.ModeloExt.Pais = "Costa Rica";
            model.ModeloJugador.DescripcionPersonal = "ya no me gusta la pizza";
            Assert.IsTrue(fachada.modificarUsuario(model));
        }

        [TestMethod]
        public void modificarContrasena()
        {
            FachadaServicio fachada = new FachadaServicio();
            UsuarioContraModel model = new UsuarioContraModel();
            model.username = "kfer";
            model.contrasena = "1234";
            model.contrasenaConf = "1234";
            model.contrasenaVieja = "1234";
            Assert.IsTrue(fachada.modificarContrasena(model));
        }
        [TestMethod]
        public void modificarNave()
        {
            FachadaServicio fachada = new FachadaServicio();
            NaveModel model = new NaveModel();
            model.Id=1;
            model.nombre="ac120-2";
            model.puntaje=10000;
            model.tamanoX=1;
            model.tamanoY=1;
            model.estado=true;
            Assert.AreEqual(fachada.modificarNave(model),"Nave modificada");

        }
        [TestMethod]
        public void desactivarNave()
        {
            FachadaServicio fachada = new FachadaServicio();
            Assert.IsTrue(fachada.desactivarNave(1));
        }
        [TestMethod]
        public void desactivarCuenta()
        {
            FachadaServicio fachada = new FachadaServicio();
            Assert.IsTrue(fachada.desactivarCuenta(3));
        }


    }
}
