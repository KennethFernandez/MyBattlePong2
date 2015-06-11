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
        public string agregarNave(NaveModel nave)
        {
            GestionarNave gestionarNave = new GestionarNave();
            return gestionarNave.agregarNave(nave);
        }

        public string modificarNave(NaveModel nave)
        {
            GestionarNave gestionarNave = new GestionarNave();
            return gestionarNave.agregarNave(nave);
        }

        public bool desactivarNave(int idNave)
        {
            GestionarNave gestionarNave = new GestionarNave();
            return gestionarNave.desactivarNave(idNave);
        }
        public bool IngresarPartidaVivo()
        {
            GestionarPartidaVivo partidaVIvo = new GestionarPartidaVivo();
            return true;
        }

        public bool IngresarPartidaOnline(PartidaModel partida)
        {
               return new GestionarPartidaOnline().ingresarPartidaOnline(partida);
        }
        public bool AgregarTableroOnline(TableroModel tablero)
        {
            return new ArmarTablero().armarTableroJuego(tablero);
        }

        public PartidaModel[] partidasDisponiblesOnline()
        {
            return null;
        }
    }
}
