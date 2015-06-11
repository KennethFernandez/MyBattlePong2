using MBP.Datos;
using MBP.EjeVertical;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBP.Logica
{
    public class ArmarTablero
    {
        public bool armarTableroJuego(TableroModel tablero)
        {
            for (int i = 0; i < tablero.tablero.Count; i++)
			{
			    Tablero_Virtual casilla = new Tablero_Virtual();
                casilla.Partida_idPartida = tablero.idPartida;
                casilla.x = tablero.tablero[i].X;
                casilla.y = tablero.tablero[i].Y;
                casilla.Destruido = "F";
                casilla.Poder = tablero.tablero[i].poder;
                casilla.Nave_idNave = tablero.tablero[i].idNave;
                casilla.NumeroNave = tablero.tablero[i].idNaveTablero;
                new AgregarModelos().agregarCasillaTableroVirtual(casilla);
			}
            return true;
        }
    }
}
