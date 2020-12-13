using ApiForza.DALL;
using ApiForza.DALL.Repositorios;
using ApiForza.SLL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiForza.SLL.SL
{

    public partial class ControlApi : IDisposable
    {
        internal IUnidadDeTrabajo _unidad;
        internal IRepositorio<Menu> _repMenu;
        internal IRepositorio<MenuOpcion> _repMenuOpcion;

    
    

        public ControlApi()
        {
            _unidad = new UnidadDeTrabajo();
            _repMenu = _unidad.ObtenerRepositorio<Menu>();
            _repMenuOpcion = _unidad.ObtenerRepositorio<MenuOpcion>();

        }
        public void Dispose()
        {
            _repMenu = null;
            _repMenuOpcion = null;
       
            _unidad.Dispose();
        }


    

        protected Usuario ObtenerUsuarioPorTipoDeAcceso(TipoAcceso tipoAcceso, string usuario)
        {
            Usuario entUsuario = null;

            switch (tipoAcceso)
            {
                case TipoAcceso.CodigoEmpleado:
                    entUsuario = _repUsuario.Tabla.Where(u => u.CodigoEmpleado == usuario).SingleOrDefault();
                    break;
                case TipoAcceso.UsuarioDominio:
                    entUsuario = _repUsuario.Tabla.Where(u => u.UsuarioDominio == usuario).SingleOrDefault();
                    break;
                default:
                    break;
            }

            return entUsuario;
        }



    }
   
}
