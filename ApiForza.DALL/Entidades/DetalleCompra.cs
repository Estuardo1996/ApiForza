using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiForza.DALL.Entidades
{
    [Table("Compras")]
    public partial class DetalleCompra : EntidadBase
    {
        [Column("IdDetalleCompra", TypeName = "int")]
        public override object Codigo { get => base.Codigo; set => base.Codigo = value; }

        [Key]
        public int IdDetalleCompra { get { return Convert.ToInt32(Codigo); } set { Codigo = value; } }

        public int IdCompra { get; set; }
        public decimal CostoUnitario { get; set; }
        public decimal PrecioUnitario { get; set; }
        public int Cantidad { get; set; }
        public int IdProdcuto { get; set; }

    }
}
