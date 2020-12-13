using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiForza.DALL
{
    class Contexto : DbContext
    {
        public Contexto()
            : base("name=ConexionApi")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<Contexto>(null);
        }
    }
}
