using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MBP.CapaTransversal.ModelsMVC
{
    public class UsuarioContraModel
    {
        public string username { get; set; }
        public string contrasena { get; set; }
        public string contrasenaConf { get; set; }
        public string contrasenaVieja { get; set; }
    }
}