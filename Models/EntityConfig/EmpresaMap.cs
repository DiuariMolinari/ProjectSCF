using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCF.DataAccess.EntityConfig
{
    public class EmpresaMap : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.Property(e => e.NomeFantasia).HasColumnType("varchar(200)").IsRequired();
            builder.Property(e => e.Cnpj).HasColumnType("varchar(15)").IsRequired();
            builder.HasKey(e => e.EmpresaId);
        }
    }
}
