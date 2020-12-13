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
        public List<Estado> ObtenerEstado()
        {
			try
			{
				return _repEstado.ObtenerTodos().ToList();
			}
			catch (Exception ex)
			{

				throw;
			}
        }

		public Mensaje GuardarEstado( List<Estado> lista, IList<Estado> a_eliminar)
		{
            var mensaje = new Mensaje { Titulo = string.Concat(Mensaje.MSG_GUARDAR, "Estado") };
            var tran = _unidad.BeginTransaction();
            try
            {
                var comparar = new CompareLogic();
                lista.ForEach(item =>
                {

                    if (item.IdEstado == 0)
                        _repEstado.Insertar(item);
                    else
                    {
                        var ent = _repEstado.ObtenerPorId(item.IdEstado);
                        var re = comparar.Compare(item, ent);
                        if (!re.AreEqual)
                            _repEstado.Actualizar(item);
                    }
                });

                if (a_eliminar != null && a_eliminar.Count > 0)
                {
                    _repEstado.Eliminar(a_eliminar);
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
