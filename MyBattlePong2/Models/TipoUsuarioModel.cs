using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBattlePong2.Models
{
    public class TipoUsuarioModel
    {
        public IEnumerable<SelectListItem> TypeList
        {

            get{ return new List<SelectListItem>{
                        new SelectListItem{ Text = "Administrador", Value= "1"},
                        new SelectListItem{ Text = "Jugador",       Value= "2"},
                        new SelectListItem{ Text = "Moderador",     Value= "3"},
            };}
        }

    }
}