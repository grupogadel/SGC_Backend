using Microsoft.EntityFrameworkCore;
using SGC.Data.Mapping.Comercial.Maestros;
using SGC.Entities.Entities.Comercial.Maestros;

namespace SGC.Data
{
    public class DbContextSGC : DbContext
    {
        public DbSet<Zona> Zonas { get; set; }
        public DbSet<Origin> Origins { get; set; }


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
        }
    }
}
