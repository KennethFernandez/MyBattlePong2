using MBP.CapaTransversal.ModelsMVC;
using MBP.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBP.Logica
{
    public class MapperPoderes
    {
        public List<string> mapperPoderes(List<Poder> poderes)
        {
            List<string> mostrarPoder = new List<string>();
            foreach (Poder i in poderes)
            {
                mostrarPoder.Add(i.Nombre);
            }
            return mostrarPoder;
        }

        public PoderModel mapperPoder(Poder poder)
        {
            PoderModel mostrarPoder = new PoderModel();
            mostrarPoder.Nombre = poder.Nombre;
            mostrarPoder.Puntos = poder.Puntos == null ? 0 : poder.Puntos.Value;
            mostrarPoder.Ranking = poder.Ranking == null ? 0 : poder.Ranking.Value;
            mostrarPoder.Victorias = poder.Victorias == null ? 0 : poder.Victorias.Value;
            mostrarPoder.Derrotas = poder.Derrotas == null ? 0 : poder.Derrotas.Value;
            mostrarPoder.Experiencia = poder.Experiencia == null ? 0 : poder.Experiencia.Value;
            return mostrarPoder;
        }

        public Poder modelToPoder(PoderModel poder)
        {
            Poder modifPoder = new Poder();
            modifPoder.Experiencia = poder.Experiencia;
            modifPoder.Derrotas = poder.Derrotas;
            modifPoder.Nombre = poder.Nombre;
            modifPoder.Puntos = poder.Puntos;
            modifPoder.Ranking = poder.Ranking;
            modifPoder.Victorias = poder.Victorias;
            return modifPoder;
        }
    }
}
