using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBP.Datos
{
    public class AgregarModelos
    {
        public string agregarNave(string nombre, int puntaje, int tam,string pathIma)
        {
            try{
                using (var db = new MBPentity())
                {
                    var query = (from st in db.Naves
                                 where st.Nombre == nombre
                                 select st);
                    Nave nuevaNave = new Nave();
                    nuevaNave = query.FirstOrDefault();
                    if (nuevaNave == null)
                    {
                        nuevaNave.Nombre = nombre;
                        nuevaNave.Puntaje = puntaje;
                        nuevaNave.Tamano = tam;
                        nuevaNave.Imagen = pathIma;
                        db.Naves.Add(nuevaNave);
                        db.SaveChanges();
                        return "Nave agregada";

                    }
                    else
                    {
                        //nombre de nave ya existe
                        return "El nombre de la nave ya fue usado";
                    }
                }
            }
                catch{
                    //error en base de datos
                    return "Error en conectar con la base de datos";
                }
                

            }

        public void agregaPartidaVivo() { 
        
        }


            // Verificar si el nombre de la nave ya existe
            // Agregar la nave
        }
    }

