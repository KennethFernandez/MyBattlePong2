using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MBP.CapaTransversal.ModelsMVC
{
    public class CompositeRegModel
    {

        public RegistrarseModel ModeloBase { get; set; }
        public RegistrarseExtModel ModeloExt { get; set; }
        public JugadorModel ModeloJugador { get; set; }
        public ModeradorModel ModeloModerador { get; set; }


    }
}