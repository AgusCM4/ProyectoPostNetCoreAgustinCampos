using Microsoft.EntityFrameworkCore;
using ProyectoPostNetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoPostNetCore.Data
{
    public class TiendaContext:DbContext
    {
        public TiendaContext(DbContextOptions<TiendaContext> options) : base(options) { }

        public DbSet<Fabricante> Fabricantes { get; set; }

        public DbSet<Producto> Productos { get; set; }
    }
}
