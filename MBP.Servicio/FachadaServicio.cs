using MBP.CapaTransversal.ModelsMVC;
using MBP.Logica;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBP.Servicio
{
    public class FachadaServicio
    {
        public UsuarioModel verificarLogin(InicioModel Modelo)
        {
            UsuarioLogica comp = new UsuarioLogica();
            return comp.verificarIngreso(Modelo);
        }

        public bool modificarUsuario(CompositeRegModel model) {
            UsuarioLogica comp = new UsuarioLogica();
            return comp.modificarUsuario(model);
        }
        public bool modificarContrasena(UsuarioContraModel model)
        {
            if (model.contrasena == model.contrasenaConf)
            {
                UsuarioLogica comp = new UsuarioLogica();
                return comp.modificarContrasena(model);
            }
            else return false;
        }
        public string agregarNave(NaveModel nave)
        {
            GestionarNave gestionarNave = new GestionarNave();
            return gestionarNave.agregarNave(nave);
        }

        public string modificarNave(NaveModel nave)
        {
            GestionarNave gestionarNave = new GestionarNave();
            return gestionarNave.modificarNave(nave);
        }

        public bool desactivarNave(int idNave)
        {
            GestionarNave gestionar = new GestionarNave();
            return gestionar.desactivarNave(idNave);
        }

        public bool desactivarCuenta(int idCuenta)
        {
            UsuarioLogica gestionarUser = new UsuarioLogica();
            return gestionarUser.desactivarCuenta(idCuenta);
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
        public bool agregarNuevoUser(CompositeRegModel modelo) {
            UsuarioLogica nuevoUser = new UsuarioLogica();
            return nuevoUser.agregarUsuario(modelo);
        }

        public List<string> obtenerListaPaises() {
            UsuarioLogica obtener = new UsuarioLogica();
            return obtener.obtenerListaPaises();
        }
        public List<string> obtenerListaNombreNaves()
        {
            GestionarNave obtener = new GestionarNave();
            return obtener.obtenerListaNombreNaves();
        }

        public List<string> obtenerListaPoderes()
        {
            GestionarPoderes gestionar = new GestionarPoderes();
            return gestionar.obtenerPoderes();
        }

        public PoderModel obtenerPoder(string nombre)
        {
            GestionarPoderes gestionar = new GestionarPoderes();
            return gestionar.obtenerPoder(nombre);
        }

        public bool modificarPoder(PoderModel poder)
        {
            GestionarPoderes gestionar = new GestionarPoderes();
            return gestionar.modificarPoder(poder);
        }

        public NaveModel obtenerNave(string nombre) {
            GestionarNave obtener = new GestionarNave();
            return obtener.obtenerNave(nombre);
        }
    }
}
