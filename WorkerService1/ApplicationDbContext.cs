using Microsoft.EntityFrameworkCore;
using WorkerService1.Models;

namespace WorkerService1
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Documento> Documentos { get; set; }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Programacion> Programacions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=MyDatabase;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Documento>().HasKey();
        }
    }
}
