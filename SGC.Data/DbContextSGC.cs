using Microsoft.EntityFrameworkCore;
using SGC.Data.Mapping.Comercial.Maestros;
using SGC.Entities.Entities.Comercial.Maestros;


using SGC.Data.Mapping;
using SGC.Entities.Entities.Configuracion.Sistema;
using SGC.Entities.Entities.Comercial.Maestro;
using SGC.Entities.View.Configuracion.Sistema;

namespace SGC.Data
{
    public class DbContextSGC: DbContext
    {
        public DbSet<Zona> Zonas { get; set; }
        public DbSet<Origin> Origins { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Collector> Collector { get; set; }
        public DbSet<Period> Period { get; set; }

        //View
        public DbSet<PeriodView> PeriodView { get; set; }

        public DbContextSGC(DbContextOptions<DbContextSGC> options) : base(options)
        {

        }
        //Metodo para mapear las indentidades de la BD
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Origin>()
                .HasOne(p => p.Zona)
                .WithMany(b => b.Origins)
                .HasForeignKey(p => p.Zona_ID);
            //Indicando a la clase padre que cuando cree el modelo,, que cree el modelBuilder 
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ZonaMap());
            modelBuilder.ApplyConfiguration(new OriginMap());
            modelBuilder.ApplyConfiguration(new CompanyMap());
            modelBuilder.ApplyConfiguration(new CollectorMap());
            modelBuilder.ApplyConfiguration(new PeriodMap());
            
        }
    }
}
