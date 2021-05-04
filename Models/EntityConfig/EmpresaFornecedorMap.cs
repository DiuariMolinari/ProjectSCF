using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCF.DataAccess.EntityConfig
{
    public class EmpresaFornecedorMap : IEntityTypeConfiguration<EmpresaFornecedor>
    {
        public void Configure(EntityTypeBuilder<EmpresaFornecedor> builder)
        {
            builder.HasKey(ef => ef.Id);
            builder.HasOne(ef => ef.Empresa).WithMany(ef => ef.EmpresasFornecedores).HasForeignKey(ef => ef.EmpresaId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(ef => ef.Fornecedor).WithMany(ef => ef.EmpresasFornecedores).HasForeignKey(ef => ef.FornecedorId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
