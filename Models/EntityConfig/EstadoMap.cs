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
            builder.HasOne(e => e.Pais).WithMany(e => e.Estados).HasForeignKey(c => c.PaisId).HasPrincipalKey(c => c.PaisId).OnDelete(DeleteBehavior.Restrict);
            builder.Property(e => e.Nome).HasColumnType("varchar(100)").IsRequired();
            builder.Property(e => e.Sigla).HasColumnType("varchar(10)").IsRequired();
        }
    }
}
