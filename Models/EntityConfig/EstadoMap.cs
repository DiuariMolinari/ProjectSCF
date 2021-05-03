using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCF.DataAccess.EntityConfig
{
    public class EstadoMap : IEntityTypeConfiguration<Estado>
    {
        public void Configure(EntityTypeBuilder<Estado> builder)
        {
            builder.Property(e => e.Nome).HasColumnType("varchar(100)").IsRequired();
            builder.Property(e => e.Sigla).HasColumnType("varchar(10)").IsRequired();
        }
    }
}
