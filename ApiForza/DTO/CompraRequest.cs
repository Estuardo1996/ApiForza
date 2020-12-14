using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiForza.DTO
{
    public class CompraRequest
    {
        public decimal Total { get; set; }
        public DateTime Fecha { get; set; }
        public int IdEstado { get; set; }

        public List<DetalleCompraRequest> detalleRequests { get; set; }

        public CompraRequest()
        {
            this.detalleRequests = new List<DetalleCompraRequest>();
        }


    }

    public class DetalleCompraRequest
    {
        public int IdCompra { get; set; }
        public decimal CostoUnitario { get; set; }
        public decimal PrecioUnitario { get; set; }
        public int Cantidad { get; set; }
        public int IdProducto { get; set; }
    }
}
