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
        public List<Venta> ObtenerVentas()
        {
			try
			{
				return _repVenta.ObtenerTodos().ToList();
			}
			catch (Exception ex)
			{

				throw;
			}
        }

		public Mensaje GuardarVentas( List<Venta> lista, IList<Venta> a_eliminar)
		{
            var mensaje = new Mensaje { Titulo = string.Concat(Mensaje.MSG_GUARDAR, "Ventas") };
            var tran = _unidad.BeginTransaction();
            try
            {
                var comparar = new CompareLogic();
                lista.ForEach(item =>
                {

                    if (item.IdVenta == 0)
                        _repVenta.Insertar(item);
                    else
                    {
                        var ent = _repVenta.ObtenerPorId(item.IdVenta);
                        var re = comparar.Compare(item, ent);
                        if (!re.AreEqual)
                            _repVenta.Actualizar(item);
                    }
                });

                if (a_eliminar != null && a_eliminar.Count > 0)
                {
                    _repVenta.Eliminar(a_eliminar);
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
