using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MBP.Servicio;
using System.Diagnostics;
using MBP.CapaTransversal.ModelsMVC;

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
            Session["rol"] = "";
            ViewData["msg"] = "";
            return View();
        }


        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            Session["MyMenu"] = null;
            Session["rol"] = null;
            Session["usuario"] = null;
            return RedirectToAction("Inicio", "Inicio");
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


                FachadaServicio fachada = new FachadaServicio();
                UsuarioModel usuario = fachada.verificarLogin(model);
                if (usuario.datos[1, 1] == "1")
                {

                    Session["usuario"] = usuario;
                    Session["rol"] = "Jugador";
                    // Session["Tipo"] = "Jugador";
                    // Debug.WriteLine(ViewBag.CategoryID);
                    return RedirectToAction("Perfil", "Perfil");
                    // FormsAuthentication.SetAuthCookie(model.Usuario, true);
                    //Session["MyMenu"] = null;
                    //return RedirectToAction("Catalogo", "Catalogo");
                }
                else if (usuario.datos[1, 1] == "2")
                {

                    Session["usuario"] = usuario;
                    Session["rol"] = "Moderador";
                    return RedirectToAction("Perfil", "Perfil");
                }
                else if (usuario.datos[1, 1] == "3")
                {

                    Session["usuario"] = usuario;
                    Session["rol"] = "Administrador";
                    return RedirectToAction("Catalogo", "Catalogo");
                }
                else
                {
                    ViewData["msg"] = "Usuario o password incorrecto";
                    return View();
                }

            }
            else
            {
                ViewData["msg"] = "Favor ingrese usuario y password";

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
