using ApiForza.DALL.Entidades;
using ApiForza.SLL.Helpers;
using KellermanSoftware.CompareNetObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiForza.SLL.SL
{
    public partial class ControlApi
    {
        public List<Producto> ObtenerProducto()
        {
			try
			{
				return _repProducto.ObtenerTodos().ToList();
			}
			catch (Exception ex)
			{
				return null;
			}
        }

		public Mensaje GuardarProducto( List<Producto> lista, IList<Producto> a_eliminar)
		{
            var mensaje = new Mensaje { Titulo = string.Concat(Mensaje.MSG_GUARDAR, "Producto") };
            var tran = _unidad.BeginTransaction();
            try
            {
                var comparar = new CompareLogic();
                lista.ForEach(item =>
                {

                    if (item.IdProducto == 0)
                        _repProducto.Insertar(item);
                    else
                    {
                        var ent = _repProducto.ObtenerPorId(item.IdProducto);
                        var re = comparar.Compare(item, ent);
                        if (!re.AreEqual)
                            _repProducto.Actualizar(item);
                    }
                });

                if (a_eliminar != null && a_eliminar.Count > 0)
                {
                    _repProducto.Eliminar(a_eliminar);
                }
                _unidad.GuardarCambios();
                tran.Commit();
                mensaje.Tipo = Mensaje.TipoMensaje.Confirmacion;
                mensaje.Texto = Mensaje.MSG_GUARDAR;
            }
            catch (Exception ex)
            {
                tran.Rollback();
                mensaje = new Mensaje(ex.Message, Mensaje.TipoMensaje.Error);
            }
            return mensaje;
        }
    }
}
