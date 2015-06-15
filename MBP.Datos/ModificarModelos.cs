using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBP.Datos
{
    public class ModificarModelos
    {
        public bool desactivarNave(int idNave)
        {
            return true;
        }

        public bool desactivarCuenta(int idCuenta)
        {
            return true;
        }

        public bool actualizarPartida(Partida partida)
        {
            try
            {
                using (var db = new MyBattlePongEntities())
                {

                    Partida partidaAct = db.Partida.Find(partida.idPartida);
                    db.Entry(partidaAct).CurrentValues.SetValues(partida);
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                //error en base de datos
                return false;
            }
        }

        public bool actualizarEstadistica(Estadistica estadistica)
        {
            try
            {
                using (var db = new MyBattlePongEntities())
                {

                    Estadistica itemAct = db.Estadistica.Find(estadistica.Jugador_Usuario_Cuenta_idCuenta);
                    db.Entry(itemAct).CurrentValues.SetValues(estadistica);
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                //error en base de datos
                return false;
            }
        }



        public bool actualizarCasilla(Tablero_Virtual casilla, int tablero)
        {
            try
            {
                using (var db = new MyBattlePongEntities())
                {
                    if (tablero == 1)
                    {
                        Tablero_Virtual_1 casillaAct = db.Tablero_Virtual_1.Find(casilla.Id);
                        casillaAct.Poder = casilla.Poder;
                        casillaAct.Destruido = casilla.Destruido;
                    }
                    else
                    {
                        Tablero_Virtual_2 casillaAct = db.Tablero_Virtual_2.Find(casilla.Id);
                        casillaAct.Poder = casilla.Poder;
                        casillaAct.Destruido = casilla.Destruido;
                    }
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                //error en base de datos
                return false;
            }
        }


        public string modificaNave(int id,string nombre, int puntaje, int tam, string pathIma)
        {
            try{
                using (var db = new MyBattlePongEntities())
                {
  
                    Nave nave = db.Nave.Find(id);
                    nave.Nombre=nombre;
                    nave.Puntaje=puntaje;
                    nave.TamanoX= tam;
                    nave.TamanoY = tam;
                    nave.Imagen=pathIma;
                    db.SaveChanges();
                    return "Nave modificada";
                }
            }
                catch{
                    //error en base de datos
                    return "Error en conectar con la base de datos";
                }
                

            }
        }
    }

