using MyBattlePong2.Models;
using System.Web.Mvc;
using System.Web.Security;


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
                if (model.Contrasena == model.Usuario)
                {
                    FormsAuthentication.SetAuthCookie(model.Usuario, true);
                    Session["MyMenu"]  = null;
                    Session["Usuario"] = model.Usuario;
                    return RedirectToAction("Jugar", "Jugar"); 
                }
                else {
                    
                    return View(); 
                
                };// Mensaje de no valido, poner un label.

            }
            else
            {
                return View();
            }
        }



    }
}

