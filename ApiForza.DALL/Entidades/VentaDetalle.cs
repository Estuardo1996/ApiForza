using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiForza.DALL.Entidades
{
    [Table("VentaDetalle")]
    public partial class VentaDetalle : EntidadBase
    {
        [Column("IdDetalleVenta", TypeName = "int")]
        public override object Codigo { get => base.Codigo; set => base.Codigo = value; }

        [Key]
        public int IdDetalleVenta { get { return Convert.ToInt32(Codigo); } set { Codigo = value; } }

        public int IdVenta { get; set; }
        public decimal CostoUnitario { get; set; }
        public decimal PrecioUnitario { get; set; }
        public int Cantidad { get; set; }
        public int IdProdcuto { get; set; }
    }
}
