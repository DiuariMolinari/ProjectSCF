﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SCF.Models;

namespace SCF.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SCF.Models.Contato", b =>
                {
                    b.Property<int>("ContatoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FornecedorId");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.HasKey("ContatoId");

                    b.HasIndex("FornecedorId");

                    b.ToTable("Contatos");
                });

            modelBuilder.Entity("SCF.Models.Empresa", b =>
                {
                    b.Property<int>("EmpresaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.Property<int>("EstadoId");

                    b.Property<string>("NomeFantasia")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("EmpresaId");

                    b.HasIndex("EstadoId");

                    b.ToTable("Empresas");
                });

            modelBuilder.Entity("SCF.Models.EmpresaFornecedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmpresaId");

                    b.Property<int>("FornecedorId");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.HasIndex("FornecedorId");

                    b.ToTable("EmpresaFornecedor");
                });

            modelBuilder.Entity("SCF.Models.Estado", b =>
                {
                    b.Property<int>("EstadoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<int>("PaisId");

                    b.Property<string>("Sigla")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.HasKey("EstadoId");

                    b.HasIndex("PaisId");

                    b.ToTable("Estados");
                });

            modelBuilder.Entity("SCF.Models.Fornecedor", b =>
                {
                    b.Property<int>("FornecedorId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CadastradoEm");

                    b.Property<string>("CpfCnpj")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.Property<DateTime>("DataNascimento");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Rg")
                        .HasColumnType("varchar(15)");

                    b.HasKey("FornecedorId");

                    b.ToTable("Fornecedores");
                });

            modelBuilder.Entity("SCF.Models.Pais", b =>
                {
                    b.Property<int>("PaisId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Sigla")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.HasKey("PaisId");

                    b.ToTable("Paises");
                });

            modelBuilder.Entity("SCF.Models.Contato", b =>
                {
                    b.HasOne("SCF.Models.Fornecedor", "Fornecedor")
                        .WithMany("Contatos")
                        .HasForeignKey("FornecedorId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("SCF.Models.Empresa", b =>
                {
                    b.HasOne("SCF.Models.Estado", "Estado")
                        .WithMany()
                        .HasForeignKey("EstadoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SCF.Models.EmpresaFornecedor", b =>
                {
                    b.HasOne("SCF.Models.Empresa", "Empresa")
                        .WithMany("EmpresasFornecedores")
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SCF.Models.Fornecedor", "Fornecedor")
                        .WithMany("EmpresasFornecedores")
                        .HasForeignKey("FornecedorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SCF.Models.Estado", b =>
                {
                    b.HasOne("SCF.Models.Pais", "Pais")
                        .WithMany()
                        .HasForeignKey("PaisId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
