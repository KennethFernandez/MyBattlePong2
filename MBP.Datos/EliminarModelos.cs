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
                {
                    eliminarTablerosPartida(bar.idPartida);
                    eliminarNavesPartida(bar.idPartida);
                    db.Partida.Remove(bar);
                }
                db.SaveChanges();
            }
            return true;
        }




        public bool eliminarPartida(int idPartida)
        {
            using (var db = new MyBattlePongEntities())
            {
                var list = db.Partida.Find(idPartida);
                eliminarNavesPartida(idPartida);
                eliminarTablerosPartida(idPartida);
                db.Partida.Remove(list);
                db.SaveChanges();
            }
            return true;
        }






        private void eliminarTablerosPartida(int idPartida)
        {
            using (var db = new MyBattlePongEntities())
            {
                var list = db.Tablero_Virtual_1.Where(m => m.Partida_idPartida == idPartida);
                foreach (Tablero_Virtual_1 bar in list)
                {
                    db.Tablero_Virtual_1.Remove(bar);
                }
                db.SaveChanges();

                var list2 = db.Tablero_Virtual_2.Where(m => m.Partida_idPartida == idPartida);
                foreach (Tablero_Virtual_2 bar in list2)
                {
                    db.Tablero_Virtual_2.Remove(bar);
                }
                db.SaveChanges();
            }
        }

        public void eliminarNavesPartida(int idPartida)
        {
            using (var db = new MyBattlePongEntities())
            {
                var list = db.Partida_Nave.Where(m => m.Partida_idPartida == idPartida);
                foreach (Partida_Nave bar in list)
                {
                    db.Partida_Nave.Remove(bar);
                }
                db.SaveChanges();
            }
        }
    }
}
