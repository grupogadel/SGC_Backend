using Microsoft.EntityFrameworkCore;
using SGC.Data.Mapping.BatchMineral;
using SGC.Entities.Entities.BatchMineral;
using SGC.Entities.Entities.Configuracion.Sistema;
using SGC.Entities.Entities.Comercial.Maestro;
using SGC.Entities.View.Configuracion.Sistema;
using SGC.Data.Mapping;

namespace SGC.Data
{
    public class DbContextSGC: DbContext
    {
        public DbSet<Zone> Zones { get; set; }
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
            //Indicando a la clase padre que cuando cree el modelo,, que cree el modelBuilder  
            modelBuilder.ApplyConfiguration(new ZoneMap());
            modelBuilder.ApplyConfiguration(new OriginMap());
            modelBuilder.ApplyConfiguration(new CompanyMap());
            modelBuilder.ApplyConfiguration(new CollectorMap());
            modelBuilder.ApplyConfiguration(new PeriodMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
