using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace ApiForza.DAL
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
