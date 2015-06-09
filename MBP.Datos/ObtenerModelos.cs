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
        public  CuentaUser ObtenerUser(string username)  {
            using (var db = new MyBattlePongEntities2())
            {
                var query = (from st in db.CuentaUsers
                               where st.Username == username
                               select st);
                CuentaUser us = new CuentaUser();
                us = query.FirstOrDefault();
                return us;
            }
            
        }

    }
}
