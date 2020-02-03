using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SGC.Entities.Entities.Configuracion.Sistema;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SGC.Data.Mapping
{
    class CompanyMap : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        { 
            builder.ToTable("Company").HasKey(c => c.Compa_ID);
            builder.Property(c => c.Compa_ID).HasColumnName("Compa_ID").IsRequired();
            builder.Property(c => c.Compa_Cod).HasColumnName("Compa_Cod").HasMaxLength(50);
            builder.Property(c => c.Compa_Name).HasColumnName("Compa_Name").HasMaxLength(20);
            builder.Property(c => c.Compa_TaxID).HasColumnName("Compa_TaxID").HasMaxLength(20);
            builder.Property(c => c.Compa_Country).HasColumnName("Compa_Country").HasMaxLength(20);
            builder.Property(c => c.Compa_Region).HasColumnName("Compa_Region").HasMaxLength(10);
            builder.Property(c => c.Compa_Address).HasColumnName("Compa_Address");
            builder.Property(c => c.Compa_Curr_Funct).HasColumnName("Compa_Curr_Funct").HasMaxLength(10);
            builder.Property(c => c.Compa_Curr_Loc).HasColumnName("Compa_Curr_Loc").HasMaxLength(10);
            builder.Property(c => c.Compa_Curr_Grp).HasColumnName("Compa_Curr_Grp").HasMaxLength(10);
            builder.Property(c => c.Compa_AcctDeb).HasColumnName("Compa_AcctDeb").HasMaxLength(20);
            builder.Property(c => c.Compa_AcctCre).HasColumnName("Compa_AcctCre").HasMaxLength(20);
            builder.Property(c => c.Compa_Status).HasColumnName("Compa_Status").HasMaxLength(4);
        }
    }
}
