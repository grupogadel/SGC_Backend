using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SGC.Entities.Entities.Comercial.Maestro;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SGC.Data.Mapping
{
    class CollectorMap : IEntityTypeConfiguration<Collector>
    {
        public void Configure(EntityTypeBuilder<Collector> builder)
        { 
            builder.ToTable("Collector").HasKey(c => c.Collec_ID);
            builder.Property(c => c.Collec_ID).HasColumnName("Collec_ID").IsRequired();
            builder.Property(c => c.Collec_Cod).HasColumnName("Collec_Cod").HasMaxLength(20);
            builder.Property(c => c.Collec_TaxID).HasColumnName("Collec_TaxID").HasMaxLength(20);
            builder.Property(c => c.Collec_Name).HasColumnName("Collec_Name");
            builder.Property(c => c.Collec_LastName).HasColumnName("Collec_LastName");
            builder.Property(c => c.Creation_User).HasColumnName("Creation_User").HasMaxLength(20);
            builder.Property(c => c.Creation_Date).HasColumnName("Creation_Date");
            builder.Property(c => c.Modified_User).HasColumnName("Modified_User").HasMaxLength(20);
            builder.Property(c => c.Modified_Date).HasColumnName("Modified_Date");
            builder.Property(c => c.Collec_Status).HasColumnName("Collec_Status").HasMaxLength(4);
        }
    }
}
