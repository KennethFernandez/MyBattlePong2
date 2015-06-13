using MBP.Datos;
using MBP.EjeVertical;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBP.Logica
{
    public class ProcesarDisparo
    {
        Partida partida;
        public bool ProcesarDisaproLive(int numVaso, int idDispositivo)
        {
            // Verifica un disparo
            if ((numVaso >= 0) && (idDispositivo >= 0))
            {
                return true;
            }
            // Anuncia precencia
            else
            {
                return new GestionarDispositivos().actualizarDispositivo(idDispositivo);
            }
        }


        public int procesarDisparoOnline(DisparoModel disparo)
        {

            partida = new ObtenerModelos().buscarPartida(disparo.idPartida);

            if (partida != null)
            {
                if (partida.Jugador1_idCuenta == disparo.idJugador && partida.TurnoActual)
                {
                    if (partida.DisparosRestantes == 1)
                    {
                        partida.TurnoActual = !partida.TurnoActual;
                        partida.DisparosRestantes = partida.DisparosJugador2;
                    }
                    else
                    {
                        partida.DisparosRestantes--;
                    }
                    new ModificarModelos().actualizarPartida(partida);
                    return this.procesarDisparoTablero(disparo, Constantes.tableroJugador1);
                }
                else if (partida.Jugador2_idCuenta == disparo.idJugador && !partida.TurnoActual)
                {

                    if (partida.DisparosRestantes == 1)
                    {
                        partida.TurnoActual = !partida.TurnoActual;
                        partida.DisparosRestantes = partida.DisparosJugador1;
                    }
                    else
                    {
                        partida.DisparosRestantes--;
                    }
                    new ModificarModelos().actualizarPartida(partida);
                    return this.procesarDisparoTablero(disparo, Constantes.tableroJugador2);
                }
                else
                {
                    return Constantes.disparoNoEsSuTurno;
                }
            }
            else
            {
                return Constantes.disparoAPartidaNoExiste;
            }

        }



        private bool siNaveDestruida(Tablero_Virtual casilla, int tablero)
        {
            if (new ObtenerModelos().consultarSiNaveDestruida(casilla.NumeroNave, casilla.Partida_idPartida,tablero) > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }



        private int procesarDisparoTablero(DisparoModel disparo, int tablero)
        {
            Tablero_Virtual casilla = new ObtenerModelos().obtenerCasillaTablero(tablero, disparo.idPartida, disparo.x, disparo.y);
            if (casilla != null)
            {
                if (!casilla.Destruido)
                {
                    if (casilla.Poder > 0)
                    {
                        casilla.Poder--;
                        new ModificarModelos().actualizarCasilla(casilla, tablero);
                        return Constantes.disparoEscudo;
                    }
                    else
                    {
                        casilla.Destruido = true;
                        new ModificarModelos().actualizarCasilla(casilla, tablero);
                        this.siNaveDestruida(casilla, tablero);
                        return Constantes.disparoExitoso;
                    }
                }
                else
                {
                    return Constantes.disparoFallido;
                }
            }
            else
            {
                return Constantes.disparoFallido;
            }
        }
    }
}
