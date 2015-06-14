using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBP.Datos
{
    public class ObtenerModelos 
    {


        public Cuenta ObtenerCuenta(string username)
        {
            using (var db = new MyBattlePongEntities())
            {
                var query = (from st in db.Cuenta
                             where st.Login == username
                             select st);
                Cuenta us = new Cuenta();
                us = query.FirstOrDefault();
                return us;
            }
        }


        public List<Tablero_Virtual> obtenerCasillasDeTablero(int tablero, int idPartida)
        {
            List<Tablero_Virtual> lista = new List<Tablero_Virtual>();

            using (var db = new MyBattlePongEntities())
            {
                if (tablero == 1)
                {
                    var query = (from st in db.Tablero_Virtual_1
                                 where st.Partida_idPartida == idPartida
                                 select st);
                    foreach (var item in query)
                    {
                            Tablero_Virtual casilla = new Tablero_Virtual();
                            casilla.Destruido = item.Destruido;
                            casilla.Id = item.Id;
                            casilla.Nave_idNave = item.Nave_idNave;
                            casilla.NumeroNave = item.NumeroNave;
                            casilla.Partida_idPartida = item.Partida_idPartida;
                            casilla.Poder = item.Poder;
                            casilla.x = item.x;
                            casilla.y = item.y;
                            lista.Add(casilla);
                    }
                }
                else
                {
                    var query = (from st in db.Tablero_Virtual_2
                                 where st.Partida_idPartida == idPartida
                                 select st);
                    foreach (var item in query)
                    {
                        Tablero_Virtual casilla = new Tablero_Virtual();
                        casilla.Destruido = item.Destruido;
                        casilla.Id = item.Id;
                        casilla.Nave_idNave = item.Nave_idNave;
                        casilla.NumeroNave = item.NumeroNave;
                        casilla.Partida_idPartida = item.Partida_idPartida;
                        casilla.Poder = item.Poder;
                        casilla.x = item.x;
                        casilla.y = item.y;
                        lista.Add(casilla);
                    }
                }
            }
            return lista;
        }


        public Tablero_Virtual obtenerCasillaTablero(int tabla, int idPartida, int X, int Y)
        {
                using (var db = new MyBattlePongEntities())
                {
                    if (tabla == 1)
                    {
                        var query = (from st in db.Tablero_Virtual_1
                                     where st.Partida_idPartida == idPartida && st.x == X && st.y == Y
                                     select st);
                        Tablero_Virtual_1 us = query.FirstOrDefault();

                        if (us != null)
                        {
                            Tablero_Virtual casilla = new Tablero_Virtual();
                            casilla.Destruido = us.Destruido;
                            casilla.Id = us.Id;
                            casilla.Nave_idNave = us.Nave_idNave;
                            casilla.NumeroNave = us.NumeroNave;
                            casilla.Partida_idPartida = us.Partida_idPartida;
                            casilla.Poder = us.Poder;
                            return casilla;
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else
                    {
                        var query = (from st in db.Tablero_Virtual_2
                                     where st.Partida_idPartida == idPartida && st.x == X && st.y == Y
                                     select st);
                        Tablero_Virtual_2 us = query.FirstOrDefault();
                        if (us != null)
                        {
                            Tablero_Virtual casilla = new Tablero_Virtual();
                            casilla.Destruido = us.Destruido;
                            casilla.Id = us.Id;
                            casilla.Nave_idNave = us.Nave_idNave;
                            casilla.NumeroNave = us.NumeroNave;
                            casilla.Poder = us.Poder;
                            casilla.Partida_idPartida = us.Partida_idPartida;
                            return casilla;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
        }

public int consultarSiNaveDestruida(int idNaveTablero, int idPartida, int tablero)
{
    using (var db = new MyBattlePongEntities())
    {
        if (tablero == 1)
        {
            var query = (from st in db.Tablero_Virtual_1
                         where st.Partida_idPartida == idPartida && st.Destruido == false && st.NumeroNave == idNaveTablero
                         select st);
            return query.Count();
        }
        else
        {
            var query = (from st in db.Tablero_Virtual_2
                         where st.Partida_idPartida == idPartida && st.Destruido == false && st.NumeroNave == idNaveTablero
                         select st);
            return query.Count();
        }
    }

}


public int consultarNavesSinDestruirTablero(int idPartida, int tablero)
{
    using (var db = new MyBattlePongEntities())
    {
        if (tablero == 1)
        {
            var query = (from st in db.Tablero_Virtual_1
                         where st.Partida_idPartida == idPartida && st.Destruido == false
                         select st);
            return query.Count();
        }
        else
        {
            var query = (from st in db.Tablero_Virtual_2
                         where st.Partida_idPartida == idPartida && st.Destruido == false
                         select st);
            return query.Count();
        }
    }

}

        public void obtienePais(int id){
            using (var db = new MyBattlePongEntities())
            {
                 //pais
                var query = (from st in db.Pais
                               where st.idPais == id
                               select st).FirstOrDefault();
            }
        }

        public void obtieneUsuario(int id)
        {
            using (var db = new MyBattlePongEntities())
            {
                //pais
                var query = (from st in db.Usuario
                             where st.Cuenta_idCuenta == id
                             select st).FirstOrDefault();
            }
        }

        public List<Partida> obtenerListaPartidaOn()
        {
            using (var db = new MyBattlePongEntities())
            {
                var query = (from st in db.Partida
                             select st);
                List<Partida> lista = new List<Partida>();
                foreach (var item in query)
                {
                    if (item.Estado == 2)
                    {
                        lista.Add(item);
                    }
                }
                return lista;
            }
        }


        public Dispositivo buscarDispositivo(int idDispositivo)
        {
            try
            {
                using (var db = new MyBattlePongEntities())
                {
                    var query = (from st in db.Dispositivo
                                 where st.Id == idDispositivo
                                 select st);
                    Dispositivo dispositivo = query.FirstOrDefault();
                    return dispositivo;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }


        public Partida buscarPartida(int idPartida)
        {
            try
            {
                using (var db = new MyBattlePongEntities())
                {
                    var query = (from st in db.Partida
                                 where st.idPartida == idPartida
                                 select st);
                    Partida partida = query.FirstOrDefault();
                    return partida;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public void obtieneJugador(int id)
        {
            using (var db = new MyBattlePongEntities())
            {
                //pais
                var query = (from st in db.Jugador
                             where st.Usuario_Cuenta_idCuenta == id
                             select st).FirstOrDefault();
            }
        }

        public Nave obtieneNave(int idNave)
        {
            using (var db = new MyBattlePongEntities())
            {
                //nave
                var query = (from st in db.Nave
                             where st.idNave == idNave
                             select st);
                return query.FirstOrDefault();
            }
        }

        public void obtieneModerador(int id)
        {
            using (var db = new MyBattlePongEntities())
            {
                //pais
                var query = (from st in db.Moderador
                             where st.Usuario_Cuenta_idCuenta == id
                             select st).FirstOrDefault();
            }
        }

        public bool existePartidaJugador(int idJugador)
        {
            using (var db = new MyBattlePongEntities())
            {
                //pais
                var query = (from st in db.Partida
                             where st.Jugador1_idCuenta == idJugador
                             select st);
                if(query.Count()>0){
                    return true;
                }else{
                    return false;
                }
            }
        }
        

    }
}
