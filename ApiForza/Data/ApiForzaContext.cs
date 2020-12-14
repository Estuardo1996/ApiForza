using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApiForza.Modelo;

namespace ApiForza.Data
{
    public class ApiForzaContext : DbContext
    {
        public ApiForzaContext (DbContextOptions<ApiForzaContext> options)
            : base(options)
        {
        }

        public DbSet<ApiForza.Modelo.Compras> Compras { get; set; }
        public DbSet<ApiForza.Modelo.Venta> Venta { get; set; }
        public DbSet<ApiForza.Modelo.Producto> Producto { get; set; }
        public DbSet<ApiForza.Modelo.Estado> Estado { get; set; }
        public DbSet<ApiForza.Modelo.DetalleCompra> DetalleCompra { get; set; }
        public DbSet<ApiForza.Modelo.DetalleVenta> DetalleVenta { get; set; }
    }
}
