using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiForza.Modelo
{
    public class Estado
    {

        [Key]
        public int IdEstado { get; set; }

        public string descripcion { get; set; }
    }
}
