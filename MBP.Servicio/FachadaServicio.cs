using MBP.CapaTrasversal.ModelsMVC;
using MBP.EjeVertical;
using MBP.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBP.Servicio
{
    public class FachadaServicio
    {
        public bool VerificarLogin(InicioModel Modelo)
        {
            IngresaUsuario comp = new IngresaUsuario();
            return comp.VerificarIngreso(Modelo.Usuario,Modelo.Contrasena);
        }
        public bool agregarNave(NaveModel nave)
        {
            GestionarNave gestionarNave = new GestionarNave();
            return gestionarNave.agregarNave(nave);
        }

        public bool desactivarNave(int idNave)
        {
            GestionarNave gestionarNave = new GestionarNave();
            return gestionarNave.desactivarNave(idNave);
        }
    }
}
