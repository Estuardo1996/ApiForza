using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiForza.DTO
{
    public class VentaRequest
    {
        public decimal Total { get; set; }
        public DateTime Fecha { get; set; }
        public int IdEstado { get; set; }

        public List<DetalleVentaRequest> detalleRequests { get; set; }

        public VentaRequest()
        {
            this.detalleRequests = new List<DetalleVentaRequest>();   
        }


    }

    public class DetalleVentaRequest
    {
        public int IdVenta { get; set; }
        public decimal CostoUnitario { get; set; }
        public decimal PrecioUnitario { get; set; }
        public int Cantidad { get; set; }
        public int IdProducto { get; set; }
    }
}
