using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApiPruebaF.Model;

namespace ApiPruebaF.Data
{
    public class ApiPruebaFContext : DbContext
    {
        public ApiPruebaFContext (DbContextOptions<ApiPruebaFContext> options)
            : base(options)
        {
        }

        public DbSet<ApiPruebaF.Model.Ventas> Ventas { get; set; }
    }
}
