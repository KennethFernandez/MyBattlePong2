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
        public  Cuenta ObtenerUser(string username)  {
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

    }
}
