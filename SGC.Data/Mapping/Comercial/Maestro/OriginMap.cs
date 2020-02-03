using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGC.Entities.Entities.Comercial.Maestros;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGC.Data.Mapping.Comercial.Maestros
{
    public class OriginMap : IEntityTypeConfiguration<Origin>
    {
        public void Configure(EntityTypeBuilder<Origin> builder)
        {
            builder.ToTable("origin")
                .HasKey(o => o.Orig_ID);

        }
    }
}
