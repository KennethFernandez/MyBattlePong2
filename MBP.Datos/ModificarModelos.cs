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
                    Nave NaveAct = db.Nave.Find(nave.idNave);
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
    }
    }

