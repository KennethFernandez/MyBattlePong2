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
        public string modificaNave(int id,string nombre, int puntaje, int tam, string pathIma)
        {
            try{
                using (var db = new MBPentity())
                {
  
                    Nave nave = db.Naves.Find(id);
                    nave.Nombre=nombre;
                    nave.Puntaje=puntaje;
                    nave.Tamano=tam;
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

