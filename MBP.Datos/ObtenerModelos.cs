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
            using (var db = new MBPentity())
            {
                var query = (from st in db.Cuentas
                               where st.Username == username
                               select st);
                Cuenta us = new Cuenta();
                us = query.FirstOrDefault();
                return us;
            }
            
        }

        public void obtienePais(int id){
             using (var db = new MBPentity())
            {
                 //pais
                var query = (from st in db.Pais
                               where st.idPais == id
                               select st).FirstOrDefault();
            }
        }

        public void obtieneUsuario(int id)
        {
            using (var db = new MBPentity())
            {
                //pais
                var query = (from st in db.Usuarios
                             where st.Cuenta_idCuenta == id
                             select st).FirstOrDefault();
            }
        }

        public void obtieneJugador(int id)
        {
            using (var db = new MBPentity())
            {
                //pais
                var query = (from st in db.Jugadors
                             where st.Usuario_Cuenta_idCuenta == id
                             select st).FirstOrDefault();
            }
        }

        public void obtieneModerador(int id)
        {
            using (var db = new MBPentity())
            {
                //pais
                var query = (from st in db.Moderadors
                             where st.Usuario_Cuenta_idCuenta == id
                             select st).FirstOrDefault();
            }
        }

        

    }
}
