using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiForza.Modelo
{
    public class Venta
    {

        [Key]
        public int IdVenta { get; set; }

        public decimal Total { get; set; }
        public DateTime Fecha { get; set; }
        public int IdEstado { get; set; }
    }
}
