using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCF.DataAccess.EntityConfig
{
    public class FornecedorMap : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            builder.Property(e => e.Nome).HasColumnType("varchar(200)").IsRequired();
            builder.Property(e => e.CpfCnpj).HasColumnType("varchar(15)").IsRequired();
            builder.Property(e => e.Rg).HasColumnType("varchar(15)");
            builder.HasMany(f => f.Contatos).WithOne(f => f.Fornecedor).HasForeignKey(f => f.FornecedorId).HasPrincipalKey(f => f.FornecedorId).OnDelete(DeleteBehavior.Restrict); ;
        }
    }
}
