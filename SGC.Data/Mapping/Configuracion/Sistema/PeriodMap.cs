using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SGC.Entities.Entities.Configuracion.Sistema;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SGC.Data.Mapping
{
    class PeriodMap : IEntityTypeConfiguration<Period>
    {
        public void Configure(EntityTypeBuilder<Period> builder)
        {
            builder.ToTable("Period").HasKey(c => c.Period_ID);
            builder.Property(c => c.Period_ID).HasColumnName("Period_ID").IsRequired();
            builder.Property(c => c.Company_ID).HasColumnName("Company_ID").IsRequired();
            builder.Property(c => c.Period_Value).HasColumnName("Period_Value").HasMaxLength(4);
            builder.Property(c => c.Period_Cod).HasColumnName("Period_Cod").HasMaxLength(20);
            builder.Property(c => c.Period_Year).HasColumnName("Period_Year").HasMaxLength(4);
            builder.Property(c => c.Period_Date_Start).HasColumnName("Period_Date_Start");
            builder.Property(c => c.Period_Date_End).HasColumnName("Period_Date_End");
            builder.Property(c => c.Creation_User).HasColumnName("Creation_User").HasMaxLength(20);
            builder.Property(c => c.Creation_Date).HasColumnName("Creation_Date");
            builder.Property(c => c.Modified_User).HasColumnName("Modified_User").HasMaxLength(20);
            builder.Property(c => c.Modified_Date).HasColumnName("Modified_Date");
            builder.Property(c => c.Period_Status).HasColumnName("Period_Status").HasMaxLength(4);
            builder.Ignore(c => c.Status);
            builder.Ignore(c => c.Period_Global);

            //Relations
            builder.HasOne(r => r.Company)
                .WithMany(r => r.Periods)
                .HasForeignKey(r => r.Company_ID);
        }
    }
}
