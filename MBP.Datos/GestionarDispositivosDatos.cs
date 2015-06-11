using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBP.Datos
{
    public class GestionarDispositivosDatos
    {
        public bool agregarDispositivo(Dispositivo dispositivo){

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

        /**
         * Retorna el ultimo tiempo en el que se actualizo el dispositivo
         **/
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


    }
}
