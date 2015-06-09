using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MBP.Servicio;
using System.Diagnostics;
using MBP.CapaTrasversal.ModelsMVC;

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
                if (comprueba.VerificarLogin(model))
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
