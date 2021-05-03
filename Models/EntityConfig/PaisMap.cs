using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCF.DataAccess.EntityConfig
{
    public class PaisMap : IEntityTypeConfiguration<Pais>
    {
        public void Configure(EntityTypeBuilder<Pais> builder)
        {
            builder.Property(e => e.Nome).HasColumnType("varchar(100)").IsRequired();
            builder.Property(e => e.Sigla).HasColumnType("varchar(10)").IsRequired();
        }
    }
}
