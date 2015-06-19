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
            try
            {
                using (var db = new MyBattlePongEntities())
                {

                    Nave NuevaNave = db.Nave.Find(idNave);
                    if (NuevaNave.Estado == true)
                    {
                        NuevaNave.Estado = false;
                    }
                    else {
                        NuevaNave.Estado = true;
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

        public bool modificarUsuario(Usuario usuario) {
            using (var db = new MyBattlePongEntities()) {
                Usuario usuarioAct = db.Usuario.Find(usuario.Cuenta_idCuenta);
                db.Entry(usuarioAct).CurrentValues.SetValues(usuario);
                db.SaveChanges();
                return true;
            }
        }

        public bool modificarJugador(Jugador jugador)
        {
            using (var db = new MyBattlePongEntities())
            {
                Jugador JugadorAct = db.Jugador.Find(jugador.Usuario_Cuenta_idCuenta);
                db.Entry(JugadorAct).CurrentValues.SetValues(jugador);
                db.SaveChanges();
                return true;
            }
        }

        public bool modificarModerador(Moderador moderador)
        {
            using (var db = new MyBattlePongEntities())
            {
                Moderador moderadorAct = db.Moderador.Find(moderador.Usuario_Cuenta_idCuenta);
                db.Entry(moderadorAct).CurrentValues.SetValues(moderador);
                db.SaveChanges();
                return true;
            }
        }

        public bool desactivarCuenta(int idCuenta)
        {
            try
            {
                using (var db = new MyBattlePongEntities())
                {

                    Cuenta cuenta = db.Cuenta.Find(idCuenta);
                    if (cuenta.Estado == "1")
                    {
                        cuenta.Estado = "0";
                    }
                    else
                    {
                        cuenta.Estado = "1";
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
        public string modificaNave(Nave nave)
        {
            try{
                using (var db = new MyBattlePongEntities())
                {
  
                    /**Nave NuevaNave = db.Nave.Find(nave.idNave);
                    NuevaNave.Nombre = nave.Nombre;
                    NuevaNave.Puntaje = nave.Puntaje;
                    NuevaNave.TamanoX = nave.TamanoX;
                    NuevaNave.TamanoY = nave.TamanoY;
                    NuevaNave.Imagen = nave.Imagen;**/
                    Nave NaveAct = db.Nave.Where(m => m.Nombre == nave.Nombre).FirstOrDefault();
                    nave.idNave = NaveAct.idNave;
                    db.Entry(NaveAct).CurrentValues.SetValues(nave);
                    db.SaveChanges();
                    return "Nave modificada";
                }
            }
                catch{
                    //error en base de datos
                    return "Error en conectar con la base de datos";
                }
                

            }

        public bool modificarContrasena(Cuenta cuenta)
        {
            using (var db = new MyBattlePongEntities())
            {
                Cuenta cuentaAct = db.Cuenta.Find(cuenta.idCuenta);
                db.Entry(cuentaAct).CurrentValues.SetValues(cuenta);
                db.SaveChanges();
                return true;
            }
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
    }
    }

