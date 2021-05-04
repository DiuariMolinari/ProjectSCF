using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCF.DataAccess.EntityConfig
{
    class ContatoMap : IEntityTypeConfiguration<Contato>
    {
        public void Configure(EntityTypeBuilder<Contato> builder)
        {
            builder.Property(e => e.Telefone).HasColumnType("varchar(20)").IsRequired();
            builder.HasOne(c => c.Fornecedor).WithMany(c => c.Contatos)
                        .HasForeignKey(c => c.FornecedorId).HasPrincipalKey(c => c.FornecedorId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
