using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace _4_Tesis.DataAccess.DataBaseObjects
{
    public class ETLCRMContext : DbContext
    {
        public ETLCRMContext()
        {

        }

        public ETLCRMContext(DbContextOptions<ETLCRMContext> options) : base(options)
        {

        }

        public DbSet<EstadoPersona> EstadoPersonas { get; set; }
        public DbSet<Persona> Persona { get; set; }
        public DbSet<EstadoContratacion> EstadoContratacion { get; set; }
        public DbSet<Cumplimiento> Cumplimientos { get; set; }
        public DbSet<Modalidad> Modalidades { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Item> items { get; set; }
        public DbSet<Proyecto> Proyectos { get; set; }
        public DbSet<Programacion> Programaciones { get; set; }
        public DbSet<EstadoActa> EstadoActas { get; set; }
        public DbSet<TipoDocumento> TipoDocumentos { get; set; }
        public DbSet<Clasificacion> Clasificaciones { get; set; }
        public DbSet<Documento> Documentos { get; set; }
        public DbSet<Ares> ares { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json")
                        .Build();

                var connectionString = configuration.GetConnectionString("RacafeCRM");

                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            modelBuilder.Entity<EstadoPersona>().ToTable("estado_persona");
            modelBuilder.Entity<Persona>().ToTable("persona");
            modelBuilder.Entity<EstadoContratacion>().ToTable("estado_contratacion");
            modelBuilder.Entity<Cumplimiento>().ToTable("cumplimiento");
            modelBuilder.Entity<Modalidad>().ToTable("modalidad");
            modelBuilder.Entity<Rol>().ToTable("rol");
            modelBuilder.Entity<Item>().ToTable("item");
            modelBuilder.Entity<Proyecto>().ToTable("proyecto");
            modelBuilder.Entity<Programacion>().ToTable("programacion");
            modelBuilder.Entity<EstadoActa>().ToTable("estado_acta");
            modelBuilder.Entity<TipoDocumento>().ToTable("tipo_documento");
            modelBuilder.Entity<Clasificacion>().ToTable("clasificacion");
            modelBuilder.Entity<Documento>().ToTable("documento");
            modelBuilder.Entity<Ares>().ToTable("ares");
        }
    }
}
