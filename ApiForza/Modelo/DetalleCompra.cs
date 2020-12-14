using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiForza.Modelo
{
    public class DetalleCompra
    {

        [Key]
        public int IdDetalleCompra { get ;  set ; }

        public int IdCompra { get; set; }
        public decimal CostoUnitario { get; set; }
        public decimal PrecioUnitario { get; set; }
        public int Cantidad { get; set; }
        public int IdProducto { get; set; }


    }
}
