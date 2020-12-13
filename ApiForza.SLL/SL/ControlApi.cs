using ApiForza.DALL;
using ApiForza.DALL.Repositorios;
using ApiForza.DALL.Entidades;
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
        internal IRepositorio<Compras> _repCompras;
        internal IRepositorio<DetalleCompra> _repDetalleCompra;
        internal IRepositorio<Venta> _repVenta;
        internal IRepositorio<VentaDetalle> _repVentaDetalle;
        internal IRepositorio<Producto> _repProducto;
        internal IRepositorio<Estado> _repEstado;

    
    

        public ControlApi()
        {
            _unidad = new UnidadDeTrabajo();
            _repCompras = _unidad.ObtenerRepositorio<Compras>();
            _repDetalleCompra = _unidad.ObtenerRepositorio<DetalleCompra>();
            _repEstado = _unidad.ObtenerRepositorio<Estado>();
            _repVenta = _unidad.ObtenerRepositorio<Venta>();
            _repVentaDetalle = _unidad.ObtenerRepositorio<VentaDetalle>();
            _repProducto = _unidad.ObtenerRepositorio<Producto>();

        }
        public void Dispose()
        {
            _repCompras = null;
            _repDetalleCompra = null;
            _repVenta = null;
            _repVentaDetalle = null;
            _repEstado = null;
            _repProducto = null;

            _unidad.Dispose();
        }

    }
   
}
