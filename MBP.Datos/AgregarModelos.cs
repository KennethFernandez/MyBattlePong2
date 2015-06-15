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
        public string agregarNave(string nombre, int puntaje, int tam,string pathIma)
        {
            try{
                using (var db = new MyBattlePongEntities())
                {
                    var query = (from st in db.Nave
                                 where st.Nombre == nombre
                                 select st);
                    Nave nuevaNave = new Nave();
                    nuevaNave = query.FirstOrDefault();
                    if (nuevaNave == null)
                    {
                        nuevaNave.Nombre = nombre;
                        nuevaNave.Puntaje = puntaje;
                        nuevaNave.TamanoX = tam;
                        nuevaNave.TamanoY = tam;
                        nuevaNave.Imagen = pathIma;
                        db.Nave.Add(nuevaNave);
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
                    return "Error en conectar con la base de datos";
                }
                

            }

        /**
         * Agrega una nueva partida en vivo a la DB 
         * 
         **/
        public void agregaPais() {
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
            catch(Exception e)
            {
                //error en base de datos
                Debug.Write(e.InnerException);
                return 0;
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
            catch(Exception e)
            {
                //error en base de datos
                Debug.Write(e.InnerException);
            }
        }
        }
}

