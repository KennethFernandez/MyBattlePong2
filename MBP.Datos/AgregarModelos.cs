using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBP.Datos
{
    public class AgregarModelos
    {
        public string agregarNave(Nave nave)
        {
            try{
                using (var db = new MyBattlePongEntities())
                {
                    var query = (from st in db.Nave
                                 where st.Nombre == nave.Nombre
                                 select st).FirstOrDefault();
                    if (query == null)
                    {
                        nave.idNave = 0;
                        db.Nave.Add(nave);
                        db.SaveChanges();
                        return "Nave agregada";

                    }
                    else
                    {
                        //nombre de nave ya existe
                        return "El nombre de la nave ya fue usado";
                    }
                }
            }
                catch{
                    //error en base de datos
                    return "Error en la base de datos";
                }
                

            }

        /**
         * Agrega una nueva cuenta a la DB 
         * 
         **/

        public bool agregarCuenta(Cuenta cuenta) {
            try
            {
                using (var db = new MyBattlePongEntities())
                {
                    db.Cuenta.Add(cuenta);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception){
                return false;
            }
        }

        /**
 * Agrega un nuevo Usuario o admin a la DB 
 * 
 **/

        public bool agregarUsuario(Usuario user)
        {
            try
            {
                using (var db = new MyBattlePongEntities())
                {
                    db.Usuario.Add(user);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /**
* Agrega un nuevo Jugador a la DB 
* 
**/

        public bool agregarJugador(Jugador jugador)
        {
            try
            {
                using (var db = new MyBattlePongEntities())
                {
                    db.Jugador.Add(jugador);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /**
* Agrega un nuevo moderador a la DB 
* 
**/

        public bool agregarModerador(Moderador moderador)
        {
            try
            {
                using (var db = new MyBattlePongEntities())
                {
                    db.Moderador.Add(moderador);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /**
* Agrega estaddísticas de un jugador a la DB 
* 
**/

        public bool agregarEstadistica(Estadistica estadistica)
        {
            try
            {
                using (var db = new MyBattlePongEntities())
                {
                    db.Estadistica.Add(estadistica);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /**
 * Agrega una nueva partida en vivo a la DB 
 * 
 **/
        public void agregaPais()
        {
            try
            {
                var context = new MyBattlePongEntities();

                var t = new Pais //Make sure you have a table called test in DB
                {
                    idPais = 10,
                    Nombre = "pppppppp",
                };

                context.Pais.Add(t);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                //error en base de datos
                Console.WriteLine(e);
            }
        }

        /**
        * Agrega una nueva partida online a la DB 
        * 
        **/
        public bool agregaPoderAjugador(int idJugador, int idPoder)
        {
            try
            {
                using (var db = new MyBattlePongEntities())
                {
                    Jugador jugador = db.Jugador.Find(idJugador);
                    Poder poder = db.Poder.Find(idPoder);
                    jugador.Poder.Add(poder);
                    poder.Jugador.Add(jugador);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                //error en base de datos
                Debug.Write(e.InnerException);
                return false;
            }
        }


        /**
         * Agrega una nueva partida online a la DB 
         * 
         **/
        public int agregaPartidaOnline(Partida partida)
        {
            try
            {
                using (var db = new MyBattlePongEntities())
                {
                    db.Partida.Add(partida);
                    db.SaveChanges();
                    return partida.idPartida;
                }
            }
            catch (Exception e)
            {
                //error en base de datos
                Debug.Write(e.InnerException);
                return 0;
            }
        }

        /**
 * Agrega una nueva partida online a la DB 
 * 
 **/
        public bool agregaPartidaHistorica(PartidaHistorica partidaHistorica)
        {
            try
            {
                using (var db = new MyBattlePongEntities())
                {
                    db.PartidaHistorica.Add(partidaHistorica);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                //error en base de datos
                Debug.Write(e.InnerException);
                return false;
            }
        }

        public bool agregarDispositivo(Dispositivo dispositivo)
        {

            try
            {
                using (var db = new MyBattlePongEntities())
                {
                    var query = (from st in db.Dispositivo
                                 where st.idDispositivo == dispositivo.idDispositivo
                                 select st);
                    Dispositivo dispositivo2 = query.FirstOrDefault();
                    if (dispositivo2 == null)
                    {
                        db.Dispositivo.Add(dispositivo);
                        db.SaveChanges();
                        return true;
                    }
                    else
                    {
                        //nombre de nave ya existe
                        dispositivo2.UltimaConexion = dispositivo.UltimaConexion;
                        db.SaveChanges();
                        return true;
                    }
                }
            }
            catch
            {
                //error en base de datos
                return false;
            }
        }

        public void agregarCasillaTableroVirtual(Tablero_Virtual casilla, int tablero)
        {
            try
            {
                using (var db = new MyBattlePongEntities())
                {
                    if (tablero == 1)
                    {
                        Tablero_Virtual_1 casillaNuev = new Tablero_Virtual_1();
                        casillaNuev.Destruido = casilla.Destruido;
                        casillaNuev.Nave_idNave = casilla.Nave_idNave;
                        casillaNuev.NumeroNave = casilla.NumeroNave;
                        casillaNuev.Partida_idPartida = casilla.Partida_idPartida;
                        casillaNuev.Poder = casilla.Poder;
                        casillaNuev.x = casilla.x;
                        casillaNuev.y = casilla.y;
                        db.Tablero_Virtual_1.Add(casillaNuev);
                        db.SaveChanges();
                        Debug.Write("Casilla Agregada");
                    }
                    else
                    {
                        Tablero_Virtual_2 casillaNuev = new Tablero_Virtual_2();
                        casillaNuev.Destruido = casilla.Destruido;
                        casillaNuev.Nave_idNave = casilla.Nave_idNave;
                        casillaNuev.NumeroNave = casilla.NumeroNave;
                        casillaNuev.Partida_idPartida = casilla.Partida_idPartida;
                        casillaNuev.Poder = casilla.Poder;
                        casillaNuev.x = casilla.x;
                        casillaNuev.y = casilla.y;
                        db.Tablero_Virtual_2.Add(casillaNuev);
                        db.SaveChanges();
                        Debug.Write("Casilla Agregada");
                    }
                }
            }
            catch (Exception e)
            {
                //error en base de datos
                Debug.Write(e.InnerException);
            }
        }

 }
}

