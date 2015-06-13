using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBP.Logica
{
    public class FabricaMapper
    {
        public IMapperUsuario getMapper(string valor)
        {
            IMapperUsuario mapper = null;
            switch (valor)
            {
                case "1":   //jugador
                    mapper = new MapperJugador(mapper);
                    break;
                case "2":   //moderador
                    mapper = new MapperModerador(mapper);
                    break;
                case "3":   //administrador
                    mapper = new MapperAdministrador();
                    break;
		        default:    //cuenta nula
                    mapper = new MapperNull();
                    break;
	        }
            return mapper;
            }
        }
    }
