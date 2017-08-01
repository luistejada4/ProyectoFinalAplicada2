using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinalAplicada2.Models
{
    public class Context : DbContext
    {
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Boleta> Boletas { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {
                
        }
    }
}
