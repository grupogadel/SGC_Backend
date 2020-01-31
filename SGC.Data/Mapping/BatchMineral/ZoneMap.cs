using Microsoft.EntityFrameworkCore;
using SGC.Entities.Entities.BatchMineral;

namespace SGC.Data.Mapping.BatchMineral
{
    public class ZoneMap:IEntityTypeConfiguration<Zone>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Zone> builder)
        {
            builder.ToTable("Zone")
               .HasKey(z => z.Zone_ID);
        }
    }
}
