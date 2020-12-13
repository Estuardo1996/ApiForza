using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiForza.DALL.Entidades
{
    [Table("Producto")]
    public partial class Producto : EntidadBase
    {
        [Column("IdProducto", TypeName = "int")]
        public override object Codigo { get => base.Codigo; set => base.Codigo = value; }

        [Key]
        public int IdProducto { get { return Convert.ToInt32(Codigo); } set { Codigo = value; } }

        public string Nombre { get; set; }
        public string Codigopr { get; set; }
        public int IdEstado  { get; set; }

        public DateTime Fecha { get; set; }
        public decimal Precio { get; set; }
        public decimal Costo { get; set; }
        public int Existencia { get; set; }

    }
}
