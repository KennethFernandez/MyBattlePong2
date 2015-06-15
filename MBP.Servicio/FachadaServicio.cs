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
            return new GestionarPartidaOnline().obtenerPartidaOnline(idPartida,idJugador);
        }


        public IList<PoderModel2> desbloquearPoderes(int idJugador)
        {
            return new GestionPoderesJugador().actualizarPoderesJugador(idJugador);
        }

        public IList<PoderModel2> poderesDeJugador(int idJugador)
        {
            return new GestionPoderesJugador().poderesJugador(idJugador);
        }
    }
}
