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
            Partida partida = new ObtenerModelos().buscarPartida(disparo.idPartida);
            if (partida.Jugador1_idCuenta == disparo.idJugador)
            {
                return this.procesarDisparoTablero(disparo, Constantes.tableroJugador1);
            }
            else
            {
                return this.procesarDisparoTablero(disparo, Constantes.tableroJugador2);
            }

        }



        public bool siNaveDestruida(Tablero_Virtual casilla, int tablero)
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
                //Debug.Write("................." + casilla.Destruido + " , " +casilla.Poder+ " , " + casilla.Id);
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
                        if (siNaveDestruida(casilla,tablero))
                        {
                            return Constantes.disparoNaveDestruida;
                        }
                        else
                        {
                            return Constantes.disparoExitoso;
                        }
                    }
                }
                else
                {
                    return Constantes.disparoFallido;
                }
            }
            else
            {
                Debug.Write("++++++++++++++++++++++Disparo Fallido++++++++++++++++++++++++++");
                return Constantes.disparoFallido;
            }
        }
    }
}
