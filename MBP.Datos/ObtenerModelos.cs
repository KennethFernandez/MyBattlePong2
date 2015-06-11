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
        public  Cuenta obtenerCuenta(string username)  {
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

        public Pais obtenerPais(int id){
            using (var db = new MyBattlePongEntities())
            {
                 //pais
                var query = (from st in db.Pais
                               where st.idPais == id
                               select st);
                Pais us = new Pais();
                us = query.FirstOrDefault();
                return us;
            }
        }

        public Usuario obtenerUsuario(int id)
        {
            using (var db = new MyBattlePongEntities())
            {
                //pais
                var query = (from st in db.Usuario
                             where st.Cuenta_idCuenta == id
                             select st);
                Usuario us = new Usuario();
                us = query.FirstOrDefault();
                return us;
            }
        }

        public Jugador obtenerJugador(int id)
        {
            using (var db = new MyBattlePongEntities())
            {
                //pais
                var query = (from st in db.Jugador
                             where st.Usuario_Cuenta_idCuenta == id
                             select st);
                Jugador us = new Jugador();
                us = query.FirstOrDefault();
                return us;
            }
        }

        public Moderador obtenerModerador(int id)
        {
            using (var db = new MyBattlePongEntities())
            {
                //pais
                var query = (from st in db.Moderador
                             where st.Usuario_Cuenta_idCuenta == id
                             select st);
                Moderador us = new Moderador();
                us = query.FirstOrDefault();
                return us;
            }
        }

        public Estadistica obtenerEstadistica(int id)
        {
            using (var db = new MyBattlePongEntities())
            {
                //pais
                var query = (from st in db.Estadistica
                             where st.Jugador_Usuario_Cuenta_idCuenta == id
                             select st);
                Estadistica us = new Estadistica();
                us = query.FirstOrDefault();
                return us;
            }
        }
    }
}
