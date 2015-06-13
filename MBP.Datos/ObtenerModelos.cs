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
    }
}
