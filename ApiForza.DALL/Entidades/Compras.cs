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
    public partial class Compras : EntidadBase
    {
        [Column("IdCompras", TypeName = "int")]
        public override object Codigo { get => base.Codigo; set => base.Codigo = value; }

        [Key]
        public int IdCompras { get { return Convert.ToInt32(Codigo); } set { Codigo = value; } }

        public decimal Total { get; set; }
        public DateTime Fecha { get; set; }
        public int IdEstado { get; set; }

    }
}
