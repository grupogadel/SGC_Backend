using Microsoft.EntityFrameworkCore;
using SGC.Data.Mapping.BatchMineral;
using SGC.Entities.Entities.BatchMineral;


namespace SGC.Data
{
    public class DbContextSGC: DbContext
    {
        public DbSet<Zone> Zones { get; set; }
        public DbSet<Origin> Origins { get; set; }


        public DbContextSGC(DbContextOptions<DbContextSGC> options) : base(options)
        {

        }
        //Metodo para mapear las indentidades de la BD
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Indicando a la clase padre que cuando cree el modelo,, que cree el modelBuilder
            base.OnModelCreating(modelBuilder);         
            modelBuilder.ApplyConfiguration(new ZoneMap());
            modelBuilder.ApplyConfiguration(new OriginMap());

        }
    }
}
