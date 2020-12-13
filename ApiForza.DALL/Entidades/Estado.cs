using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiForza.DALL.Entidades
{
    [Table("Estado")]
    public partial class Estado : EntidadBase
    {
        [Column("IdEstado", TypeName = "int")]
        public override object Codigo { get => base.Codigo; set => base.Codigo = value; }

        [Key]
        public int IdEstado { get { return Convert.ToInt32(Codigo); } set { Codigo = value; } }

        public string descripcion { get; set; }

    }
}
