using ApiForza.DALL.Entidades;
using ApiForza.SLL.Helpers;
using KellermanSoftware.CompareNetObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;

namespace ApiForza.SLL.SL
{
    public partial class ControlApi
    {
        public List<Compras> ObtenerCompras()
        {
			try
			{
				return _repCompras.ObtenerTodos().ToList();

			}
			catch (Exception ex)
			{

				return null;
			}
        }

		public Mensaje GuardarCompras( List<Compras> lista, IList<Compras> a_eliminar)
		{
			var mensaje = new Mensaje { Titulo = string.Concat(Mensaje.MSG_GUARDAR, "Compras") };
			var tran = _unidad.BeginTransaction();
			try
			{
                var comparar = new CompareLogic();
                lista.ForEach(item =>
                {

                    if (item.IdCompras == 0)
                        _repCompras.Insertar(item);
                    else
                    {
                        var ent = _repCompras.ObtenerPorId(item.IdCompras);
                        var re = comparar.Compare(item, ent);
                        if (!re.AreEqual)
                            _repCompras.Actualizar(item);
                    }
                });

                if (a_eliminar != null && a_eliminar.Count > 0)
                {
                    _repCompras.Eliminar(a_eliminar);
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
