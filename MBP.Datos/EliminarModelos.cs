using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBP.Datos
{
    public class EliminarModelos
    {
        public bool eliminarPartidasDeJugador(int idJugador)
        {
            using (var db = new MyBattlePongEntities())
            {
                    var list = db.Partida.Where(m => m.Jugador1_idCuenta == idJugador);
                    foreach (Partida bar in list)
                        db.Partida.Remove(bar);
                        db.SaveChanges();
             }  
                return true;
            }
        }
    }
