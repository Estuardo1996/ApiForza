using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPruebaF.Model
{
    public class Ventas
    {
        [Key]
        public int IdVentas { get; set; }
        public decimal Total { get; set; }
        public DateTime Fecha { get; set; }
        public int IdEstado { get; set; }
    }
}
