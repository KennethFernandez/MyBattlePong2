using MBP.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBP.Logica
{
    public class VerificarPartidaJugador
    {
        public void jugadorTienePartida(int idCuenta)
        {
            // Verifica si ya tiene una partida creada y si es asi la borra;
            ConsultarModelos consulta = new ConsultarModelos();
            if (consulta.existePartidaJugador(idCuenta))
            {
                EliminarModelos eliminar = new EliminarModelos();
                eliminar.eliminarPartidasDeJugador(idCuenta);
            }
        }
    }
}
