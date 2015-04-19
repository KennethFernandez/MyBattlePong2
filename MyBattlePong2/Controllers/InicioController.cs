using MyBattlePong2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MyBattlePong2.Controllers
{
    public class InicioController : Controller
    {
        //
        // GET: /Inicio/
        // ActionResult principal que se llama para correr la vista

        [HttpGet]
        public ActionResult Inicio()
        {
            Session["Usuario"] = "f";
            return View();
        }

        [HttpPost]
        public ActionResult Inicio(InicioModel model)
        {
            // Si el modelo cumple con las condiciones
            // de largo y demas pasa
            if (ModelState.IsValid)
            {
                // Imprime los usuarios y contraseñas para comprobar que sirve
                System.Diagnostics.Debug.WriteLine(model.Contrasena);
                System.Diagnostics.Debug.WriteLine(model.Usuario);
                bool valido = true;// Metodo_externo

                Session["Usuario"] = "3";

                if (model.Usuario == "loco")
                {

                    Session["Usuario"] = "1";

                }

                Session["ModelUsuario"] = model;


                if (Session["Usuario"].Equals("2"))
                {
                    Session["Layout"] = "~/Views/Master/MasterA.cshtml";
                }
                else if (Session["Usuario"].Equals("3") || Session["Usuario"].Equals("1"))
                {
                    Session["Layout"] = "~/Views/Master/MasterNF.cshtml";
                }



                // solo deja pasar si son iguales si no regresa a la página de inicio.
                // , new { modelo =  UsuarioModel}
                if (model.Contrasena == model.Usuario)
                { return RedirectToAction("Perfil", "Perfil"); }
                else { return View(); };// Mensaje de no valido, poner un label.
            }
            else
            {
                return View();
            }
        }



    }
}

