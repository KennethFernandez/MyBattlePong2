using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MBP.Servicio;
using System.Diagnostics;
using MBP.CapaTrasversal.ModelsMVC;
using MBP.EjeVertical.ModelsMVC;

namespace MBP.Presentacion.Controllers
{
    public class InicioController : Controller
    {
        //
        // GET: /Inicio/
        // ActionResult principal que se llama para correr la vista
        [HttpGet]
        public ActionResult Inicio()
        {
            /**
            Console.WriteLine("Prueba iniciada");
            PartidaModel partida = new PartidaModel();
            partida.disparos = 12;
            partida.idJugadorCreador = 1;
            partida.permisos = true;
            int[,] naves = new int[7, 2] { { 1, 3 }, { 2, 4 }, { 3, 1 }, { 4, 4 }, { 5, 3 }, { 6, 3 }, { 4, 5 } };
            partida.navesTipo = naves;
            partida.tamano = 10;
            new FachadaServicio().IngresarPartidaOnline(partida);
            Console.WriteLine("Prueba iniciada");

            **/
            return View();
        }


        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            Session["MyMenu"] = null;
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Inicio(InicioModel model)
        {

            // return RedirectToAction("Jugar", "Jugar");
            // Si el modelo cumple con las condiciones
            // de largo y demas pasa
            if (ModelState.IsValid)
            {

                // solo deja pasar si son iguales si no regresa a la página de inicio.
                // , new { modelo =  UsuarioModel}
                FachadaServicio comprueba = new FachadaServicio();
                UsuarioModel datos = comprueba.verificarLogin(model);
                if (datos.datos[0,0] != "-1")
                {
                    Debug.Write("OK");
                    return View();
                    // FormsAuthentication.SetAuthCookie(model.Usuario, true);
                    //Session["MyMenu"] = null;
                    //return RedirectToAction("Catalogo", "Catalogo");
                }
                else
                {
                    Debug.Write("NO");
                    return View();

                };// Mensaje de no valido, poner un label.

            }
            else
            {
                return View();
            }
        }
        //
        // GET: /Inicio/

        public ActionResult Index()
        {
            return View();
        }

    }
}
