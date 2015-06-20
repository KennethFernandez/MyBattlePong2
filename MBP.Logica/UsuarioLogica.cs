using MBP.CapaTransversal.ModelsMVC;
using MBP.Datos;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBP.Logica
{
    public class UsuarioLogica
    {

        public UsuarioModel verificarIngreso(InicioModel model)
        {
            ObtenerModelos obtenerDatos = new ObtenerModelos();
            IEncriptacion encrip = new FabricaEncriptacion().fabricaEncripta(1);
            model.Contrasena = encrip.encriptar(model.Contrasena);

            Cuenta cuenta = obtenerDatos.obtenerCuenta(model.Usuario, model.Contrasena);
            Debug.WriteLine("idCuenta: " + cuenta.idCuenta);
            Usuario usuario = obtenerDatos.obtenerUsuario(cuenta.idCuenta);
            Debug.WriteLine("tipo: " + usuario.Tipo);
            IMapperUsuario mapper = new FabricaMapper().getMapper(usuario.Tipo);
            return mapper.mapper(cuenta, usuario);
        }
        public bool modificarUsuario(CompositeRegModel model)
        {
            FabricaModificarUsuario fabrica = new FabricaModificarUsuario();
            IModificarUsuario modificar = fabrica.fabricaModifUsuario(model.ModeloBase.Tipo);
            return modificar.modificarUsuario(model);
        }

        public bool modificarContrasena(UsuarioContraModel model)
        {
            ModificarModelos modificar = new ModificarModelos();
            ObtenerModelos obtener = new ObtenerModelos();
            IEncriptacion encrip = new FabricaEncriptacion().fabricaEncripta(1);
            model.contrasenaVieja = encrip.encriptar(model.contrasenaVieja);
            Cuenta cuenta = obtener.obtenerCuenta(model.username, model.contrasenaVieja);
            cuenta.Contrasena = encrip.encriptar(model.contrasena);
            return modificar.modificarContrasena(cuenta);
        }

        public bool desactivarCuenta(int idCuenta) { 
            ModificarModelos modificar = new ModificarModelos();
            return modificar.desactivarCuenta(idCuenta);
            
        }

        public bool agregarUsuario(CompositeRegModel model) {
            IAgregarUsuario nuevo = new FabricaAgregarUsuario().fabricaAgregUsuario(model.ModeloBase.Tipo);
            return nuevo.agregarUsuario(model);
        }

        public List<string> obtenerListaPaises() {
            ObtenerModelos obtenerDatos = new ObtenerModelos();
            return obtenerDatos.obtenerListaPaises();
        }
    }
}
