using Microsoft.EntityFrameworkCore;
using SGC.Entities.Entities.BatchMineral;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGC.Data.Mapping.BatchMineral
{
    public class OriginMap: IEntityTypeConfiguration<Origin>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Origin> builder)
        {
            builder.ToTable("Origin")
               .HasKey(o => o.Orig_ID);
        }
    }
}
