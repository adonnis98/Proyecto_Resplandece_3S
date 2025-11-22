using Microsoft.EntityFrameworkCore;
using Proyecto_Resplandece.Clases;
using Proyecto_Resplandece.Clases.Base;
using Proyecto_Resplandece.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Resplandece.Clases.Base
{
    public class BaseDeDatos : DbContext
    {
       
        public BaseDeDatos() { }
        public BaseDeDatos(DbContextOptions<BaseDeDatos> options) : base(options) { }
        //2. DEFINICIÓN DE TABLAS
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Beneficiarios> Beneficiarios { get; set; }

      

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("server=localhost;database=Proyecto_Resplandecededb;user=root;password=smilecry98;");
            }

            // Opcional: Configuración para SQL Server (Mantenida comentada)
            // optionsBuilder.UseSqlServer("Server=DESKTOP-B2C6BQU\\SQLEXPRESS;Database=Proyecto_Resplandece;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuarios>()
        .HasIndex(u => u.Username)
        .IsUnique();
            modelBuilder.Entity<Beneficiarios>()
        .HasIndex(b => b.Cedula)
        .IsUnique();
        }
        
    }
}
