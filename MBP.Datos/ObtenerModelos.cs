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
        public  Cuenta obtenerCuenta(string username, string password)  {
                using (var db = new MyBattlePongEntities())
                {
                    var query = (from st in db.Cuenta
                                 where st.Login == username && st.Contrasena == password
                                 select st).FirstOrDefault();
                    return query == null ? new Cuenta() : query;
                }
            }

        public Pais obtenerPais(int id){
            using (var db = new MyBattlePongEntities())
            {
                 //pais
                var query = (from st in db.Pais
                               where st.idPais == id
                             select st).FirstOrDefault();
                return query == null ? new Pais() : query;
            }
        }
        public int obtenerIdPais(string nombre)
        {
            using (var db = new MyBattlePongEntities())
            {
                //pais
                var query = (from st in db.Pais
                             where st.Nombre == nombre
                             select st).FirstOrDefault();
                return query == null ? -1 : query.idPais;
            }
        }

        public int obtenerIdCuenta(string username)
        {
            using (var db = new MyBattlePongEntities())
            {
                //pais
                var query = (from st in db.Cuenta
                             where st.Login == username
                             select st).FirstOrDefault();
                return query == null ? -1 : query.idCuenta;
            }
        }

        public Usuario obtenerUsuario(int id)
        {
            using (var db = new MyBattlePongEntities())
            {
                //pais
                var query = (from st in db.Usuario
                             where st.Cuenta_idCuenta == id
                             select st).FirstOrDefault();
                return query == null ? new Usuario() : query;
            }
        }

        public Jugador obtenerJugador(int id)
        {
            using (var db = new MyBattlePongEntities())
            {
                //pais
                var query = (from st in db.Jugador
                             where st.Usuario_Cuenta_idCuenta == id
                             select st).FirstOrDefault();
                return query == null ? new Jugador() : query;
            }
        }

        public Moderador obtenerModerador(int id)
        {
            using (var db = new MyBattlePongEntities())
            {
                //pais
                var query = (from st in db.Moderador
                             where st.Usuario_Cuenta_idCuenta == id
                             select st).FirstOrDefault();
                return query == null ? new Moderador() : query;
            }
        }

        public Estadistica obtenerEstadistica(int id)
        {
            using (var db = new MyBattlePongEntities())
            {
                //pais
                var query = (from st in db.Estadistica
                             where st.Jugador_Usuario_Cuenta_idCuenta == id
                             select st).FirstOrDefault();
                return query == null ? new Estadistica() : query;
            }
        }

        public Dispositivo buscarDispositivo(int idDispositivo)
        {
            using (var db = new MyBattlePongEntities())
            {
                var query = (from st in db.Dispositivo
                                where st.Id == idDispositivo
                             select st).FirstOrDefault();
                return query == null ? new Dispositivo() : query;
            }
        }

        public List<Partida> obtenerListaPartidaOn() {
            using (var db = new MyBattlePongEntities())
            {
                var query = (from st in db.Partida where st.Estado == 2
                             select st);
                List<Partida> lista = new List<Partida>();
                foreach(var item in query){
                    lista.Add(item);
                }
                return lista;
            }
        }
        public List<string> obtenerListaPaises()
        {
            using (var db = new MyBattlePongEntities())
            {
                var query = (from st in db.Pais
                             select st);
                List<string> lista = new List<string>();
                foreach (var item in query)
                {
                    lista.Add(item.Nombre);
                    
                }
                return lista;
            }
        }

        public List<Nave> obtenerListaNavesActivas()
        {
            using (var db = new MyBattlePongEntities())
            {
                var query = (from st in db.Nave
                             select st);
                List<Nave> lista = new List<Nave>();
                foreach (var item in query)
                {
                    if(item.Estado==true)
                    lista.Add(item);

                }
                return lista;
            }
        }

        public List<Nave> obtenerListaNaves()
        {
            using (var db = new MyBattlePongEntities())
            {
                var query = (from st in db.Nave
                             select st);
                List<Nave> lista = new List<Nave>();
                foreach (var item in query)
                {
                    lista.Add(item);

                }
                return lista;
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
                        casilla.x = us.x;
                        casilla.y = us.y;
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
                        casilla.x = us.x;
                        casilla.y = us.y;
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
                    return query == null ? 5 : query.Count();
                }
                else
                {
                    var query = (from st in db.Tablero_Virtual_2
                                 where st.Partida_idPartida == idPartida && st.Destruido == false && st.NumeroNave == idNaveTablero
                                 select st);
                    return query == null ? 5 : query.Count();
                }
            }

        }


        public int navesSinDestruir(int idPartida, int tablero)
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


        public void obtienePais(int id)
        {
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

        public Estadistica obtieneEstadisticasJugador(int idJugador)
        {
            using (var db = new MyBattlePongEntities())
            {
                //pais
                var query = (from st in db.Estadistica
                             where st.Jugador_Usuario_Cuenta_idCuenta == idJugador
                             select st);
                return query.FirstOrDefault();
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
                if (query.Count() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public Poder obtenerPoder(int idPoder)
        {
            using (var db = new MyBattlePongEntities())
            {
                var query = (from st in db.Poder
                             where st.idPoder == idPoder
                             select st);
                return query.FirstOrDefault();
            }
        }


        public List<Poder> obtenerPoderesJugador(int idJugador)
        {
            using (var db = new MyBattlePongEntities())
            {
                Jugador jugador = db.Jugador.Find(idJugador);
                List<Poder> listaPoder = new List<Poder>();
                foreach (Poder item in jugador.Poder)
                {
                    listaPoder.Add(item);
                }
                return listaPoder;
            }
        }

        public List<Poder> obtenerListaPoderes()
        {
            using (var db = new MyBattlePongEntities())
            {
                var poderes = db.Poder;
                List<Poder> listaPoder = new List<Poder>();
                foreach (Poder item in poderes)
                {
                    listaPoder.Add(item);
                }
                return listaPoder;
            }
        }

        public List<Partida_Nave> obtenerNavesDePartida(int idPartida)
        {
            using (var db = new MyBattlePongEntities())
            {
                var naves = db.Partida_Nave.Where(m => m.Partida_idPartida == idPartida);
                List<Partida_Nave> listaNaves = new List<Partida_Nave>();
                foreach (Partida_Nave item in naves)
                {
                    listaNaves.Add(item);
                }
                return listaNaves;
            }
        }

        public List<Tablero_Virtual> casillasSinDestruirNave(int idPartida, int tablero, int numNave)
        {
            using (var db = new MyBattlePongEntities())
            {
                List<Tablero_Virtual> resultado = new List<Tablero_Virtual>();
                if (tablero == 1)
                {
                    var query = (from st in db.Tablero_Virtual_1
                                 where st.Partida_idPartida == idPartida && st.Destruido == false && st.NumeroNave == numNave
                                 select st);

                    foreach (Tablero_Virtual_1 item in query)
                    {
                        Tablero_Virtual casilla = new Tablero_Virtual();
                        casilla.Destruido = item.Destruido;
                        casilla.Id = item.Id;
                        casilla.Nave_idNave = item.Nave_idNave;
                        item.Destruido = true;
                        casilla.NumeroNave = item.NumeroNave;
                        casilla.Partida_idPartida = item.Partida_idPartida;
                        casilla.Poder = item.Poder;
                        casilla.x = item.x;
                        casilla.y = item.y;
                        resultado.Add(casilla);
                    }
                    db.SaveChanges();
                    return resultado;
                }
                else
                {
                    var query = (from st in db.Tablero_Virtual_2
                                 where st.Partida_idPartida == idPartida && st.Destruido == false && st.NumeroNave == numNave
                                 select st);
                    foreach (Tablero_Virtual_2 item in query)
                    {
                        Tablero_Virtual casilla = new Tablero_Virtual();
                        casilla.Destruido = item.Destruido;
                        casilla.Id = item.Id;
                        casilla.Nave_idNave = item.Nave_idNave;
                        casilla.NumeroNave = item.NumeroNave;
                        casilla.Partida_idPartida = item.Partida_idPartida;
                        casilla.Poder = item.Poder;
                        item.Destruido = true;
                        casilla.x = item.x;
                        casilla.y = item.y;
                        resultado.Add(casilla);
                    }
                    db.SaveChanges();
                    return resultado;
                }
            }

        }
        


    }
}
