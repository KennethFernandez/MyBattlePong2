using MBP.CapaTransversal.ModelsMVC;
using MBP.EjeVertical;
using MBP.EjeVertical.ModelsMVC;
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

        public int IngresarPartidaOnline(PartidaModel partida)
        {
               return new GestionarPartidaOnline().ingresarPartidaOnline(partida);
        }
        public bool AgregarTableroOnline(TableroModel tablero)
        {
            return new ArmarTablero().armarTableroJuego(tablero);
        }

        public List<PartidaModel2> partidasDisponiblesOnline()
        {
            return new GestionarPartidaOnline().obtenerPartidasDisponibles();
        }
        public bool agregarNuevoUser(CompositeRegModel modelo) {
            UsuarioLogica nuevoUser = new UsuarioLogica();
            return nuevoUser.agregarUsuario(modelo);
        }

        public List<string> obtenerListaPaises() {
            UsuarioLogica obtener = new UsuarioLogica();
            return obtener.obtenerListaPaises();
        }

        public int ingresarPartidaOnline(PartidaModel partida)
        {
            return new GestionarPartidaOnline().ingresarPartidaOnline(partida);
        }
        public bool agregarTableroOnline(TableroModel tablero)
        {
            return new ArmarTablero().armarTableroJuego(tablero);
        }

        public DisparoModel2 disparo(DisparoModel disparo)
        {
            return new ProcesarDisparo().procesarDisparo(disparo);
        }

        public bool eliminarPartida(int idJugador)
        {
            return true;
        }


        public bool pasarTurnoPartida(int idPartida)
        {
            return new GestionarPartidaOnline().cambiarTurnoJuego(idPartida);
        }

        public TableroModel2 recuperarTableroPartida(int idPartida, int idJugador)
        {
            return new GestionarPartidaOnline().obtenerPartidaOnline(idPartida, idJugador);
        }


        public IList<PoderModel2> desbloquearPoderes(int idJugador)
        {
            return new GestionPoderesJugador().actualizarPoderesJugador(idJugador);
        }

        public IList<PoderModel2> poderesDeJugador(int idJugador)
        {
            return new GestionPoderesJugador().poderesJugador(idJugador);
        }

        public IList<NaveModel2> navesDePartida(int idPartida)
        {
            return new GestionarPartidaOnline().navesDePartida(idPartida);
        }

        public RespuestaPoderModel activarPoder(int idJugador, int idPartida, int idPoder)
        {
            return new EstrategiaActivarPoder().activarEfectoPoder(idPartida, idJugador, idPoder);
        }

        public List<string> obtenerListaNombreNaves()
        {
            GestionarNave obtener = new GestionarNave();
            return obtener.obtenerListaNombreNaves();
        }
        public NaveModel obtenerNave(string nombre)
        {
            GestionarNave obtener = new GestionarNave();
            return obtener.obtenerNave(nombre);
        }
    }
}
