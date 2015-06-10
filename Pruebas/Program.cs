using MBP.EjeVertical;
using MBP.Servicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pruebas
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Prueba iniciada");
            PartidaModel partida = new PartidaModel();
            partida.disparos = 12;
            partida.idJugadorCreador = 1;
            partida.permisos = true;
            int[,] naves = new int[7,2] {{1,3},{2,4},{3,1},{4,4},{5,3},{6,3},{4,5}};
            partida.navesTipo = naves;
            partida.tamano = 10;
            new FachadaServicio().IngresarPartidaOnline(partida);
            Console.WriteLine("Prueba finalizada");
            while (true) ;
        }
    }
}
