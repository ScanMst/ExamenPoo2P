using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using examen2Poo.Entities;
using Microsoft.EntityFrameworkCore;

namespace examen2Poo
{
    public class ApplicationDbContext : DbContext
    {
        protected ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions options) : base (options)
        {
        }
        public DbSet<Juguete> Juguetes { get; set; }
        public DbSet<Marca> Marcas { get; set; }
         //public DbSet<nombreEntitie> Specialists { get; set; }
    }
}