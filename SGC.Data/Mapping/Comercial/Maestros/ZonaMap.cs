using Microsoft.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGC.Entities.Entities.Comercial.Maestros;

namespace SGC.Data.Mapping.Comercial.Maestros
{
    public class ZonaMap : IEntityTypeConfiguration<Zona>
    {
        public void Configure(EntityTypeBuilder<Zona> builder)
        {
            builder.ToTable("zona")
                .HasKey(o => o.Zona_ID);
        }
    }
}
