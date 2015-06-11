﻿using MBP.CapaTrasversal.ModelsMVC;
using MBP.EjeVertical;
using MBP.EjeVertical.ModelsMVC;
using MBP.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBP.Servicio
{
    public class FachadaServicio
    {
        public UsuarioModel verificarLogin(InicioModel Modelo)
        {
            UsuarioLogica comp = new UsuarioLogica();
            return comp.verificarIngreso(Modelo);
        }
        public string agregarNave(NaveModel nave)
        {
            GestionarNave gestionarNave = new GestionarNave();
            return gestionarNave.agregarNave(nave);
        }

        public string modificarNave(NaveModel nave)
        {
            GestionarNave gestionarNave = new GestionarNave();
            return gestionarNave.agregarNave(nave);
        }

        public bool desactivarNave(int idNave)
        {
            GestionarNave gestionarNave = new GestionarNave();
            return gestionarNave.desactivarNave(idNave);
        }
        public bool IngresarPartidaVivo()
        {
            GestionarPartidaVivo partidaVIvo = new GestionarPartidaVivo();
            return true;
        }

        public bool IngresarPartidaOnline(PartidaModel partida)
        {
               return new GestionarPartidaOnline().ingresarPartidaOnline(partida);
        }
    }
}
