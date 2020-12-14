using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiForza.Modelo
{
    public class Producto
    {

        [Key]
        public int IdProducto { get; set ;  }

        public string Nombre { get; set; }
        public string Codigopr { get; set; }
        public int IdEstado { get; set; }

        public DateTime Fecha { get; set; }
        public decimal Precio { get; set; }
        public decimal Costo { get; set; }
        public int Existencia { get; set; }
    }
}
