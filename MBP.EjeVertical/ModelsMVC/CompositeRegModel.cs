using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MBP.CapaTransversal.ModelsMVC
{
    public class CompositeRegModel
    {

        public RegistrarseModel    ModeloBase       { set; get; }
        public RegistrarseExtModel ModeloExt       { set; get; }
        public JugadorModel        ModeloJugador   { set; get; }
        public ModeradorModel      ModeloModerador { set; get; }

    }
}