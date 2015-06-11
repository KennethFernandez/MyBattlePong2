﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
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
                using (var db = new MyBattlePongEntities())
                {
                    var query = (from st in db.Nave
                                 where st.Nombre == nombre
                                 select st);
                    Nave nuevaNave = new Nave();
                    nuevaNave = query.FirstOrDefault();
                    if (nuevaNave == null)
                    {
                        nuevaNave.Nombre = nombre;
                        nuevaNave.Puntaje = puntaje;
                        nuevaNave.TamanoX = tam;
                        nuevaNave.TamanoY = tam;
                        nuevaNave.Imagen = pathIma;
                        db.Nave.Add(nuevaNave);
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

        /**
         * Agrega una nueva partida en vivo a la DB 
         * 
         **/
        public void agregaPais() {
            try
            {
                var context = new MyBattlePongEntities();

                var t = new Pais //Make sure you have a table called test in DB
                {
                    idPais = 10,
                    Nombre = "pppppppp",
                };

                context.Pais.Add(t);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                //error en base de datos
                Console.WriteLine(e);
            }
        }

        /**
         * Agrega una nueva partida online a la DB 
         * 
         **/
        public bool agregaPartidaOnline(Partida partida)
        {
            try
            {
                using (var db = new MyBattlePongEntities())
                {
                    db.Partida.Add(partida);
                    db.SaveChanges();
                    Debug.Write("Partida Agregada");
                    return true;
                }
            }
            catch(Exception e)
            {
                //error en base de datos
                Debug.Write("----------------------"+e.InnerException+"-------------------------------------\n");
                return false;
            }
        }
        }
    }

