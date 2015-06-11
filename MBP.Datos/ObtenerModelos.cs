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
        public  Cuenta ObtenerCuenta(string username)  {
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

        public List<Partida> obtieneUsuario()
        {
            using (var db = new MyBattlePongEntities())
            {
                Partida[] partidas;
                //pais
                var query = (from st in db.Partida
                             where st.Estado == "D"
                             select st);    
                return null;
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

        

    }
}
