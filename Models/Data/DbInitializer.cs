using SCF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCF.Models.Data
{
    public static class DbInitializer
    {
        public static void Initialize(Context context)
        {
            if (context.Paises.Any())
                return;

            var paises = new Pais[]
            {
                new Pais
                {
                    Nome = "Brasil",
                    Sigla = "BR"
                },
                new Pais
                {
                    Nome = "Argentina",
                    Sigla = "AR"
                },
                new Pais
                {
                    Nome = "Chile",
                    Sigla = "CL"
                }
            };
            context.AddRange(paises);

            var estados = new Estado[]
            {
                new Estado
                {
                    Nome = "Paraná",
                    Sigla = "PR",
                    Pais = paises[0]
                },
                new Estado
                {
                    Nome = "Santa Catarina",
                    Sigla = "SC",
                    Pais = paises[0]
                },

                new Estado
                {
                    Nome = "Buenos Aires",
                    Sigla = "Bs.As",
                    Pais = paises[1]
                }
            };
            context.AddRange(estados);

            var empresas = new Empresa[]
            {
                new Empresa
                {
                    NomeFantasia = "EmpresaX",
                    Estado = estados[0],
                    Cnpj = "25010370000130"
                },
                new Empresa
                {
                    NomeFantasia = "EmpresaY",
                    Estado = estados[1],
                    Cnpj = "48042566000102"
                },
                new Empresa
                {
                    NomeFantasia = "EmpresaZ",
                    Estado = estados[2],
                    Cnpj = "56742761000173"
                }
            };
            context.AddRange(empresas);

            var fornecedores = new Fornecedor[]
            {
                new Fornecedor
                {
                    Nome = "Fornecedor 1",
                    CpfCnpj = "87281763000136",
                    CadastradoEm = DateTime.Now
                },
                new Fornecedor
                {
                    Nome = "Fornecedor 2",
                    CpfCnpj = "09875463094",
                    Rg = "218947781",
                    DataNascimento = new DateTime(2000, 1, 1),
                    CadastradoEm = DateTime.Now
                },
                new Fornecedor
                {
                    Nome = "Fornecedor 3",
                    CpfCnpj = "38217917051",
                    Rg = "175347645",
                    DataNascimento = new DateTime(2010, 12, 15),
                    CadastradoEm = DateTime.Now
                },
            };
            context.AddRange(fornecedores);

            var contatos = new Contato[]
            {
                new Contato
                {
                    Telefone = "47999999999",
                    Fornecedor = fornecedores[0],
                },
                new Contato
                {
                    Telefone = "47888888888",
                    Fornecedor = fornecedores[0],
                },
                new Contato
                {
                    Telefone = "47777777777",
                    Fornecedor = fornecedores[1],
                },
                new Contato
                {
                    Telefone = "47666666666",
                    Fornecedor = fornecedores[2],
                },
            };
            context.AddRange(contatos);

            var empresasFornecedores = new EmpresaFornecedor[]
            {
                new EmpresaFornecedor
                {
                    Empresa = empresas[0],
                    Fornecedor = fornecedores[0],
                    CadastradoEm = DateTime.Now,
                },
                new EmpresaFornecedor
                {
                    Empresa = empresas[0],
                    Fornecedor = fornecedores[1],
                    CadastradoEm = DateTime.Now,
                },
                new EmpresaFornecedor
                {
                    Empresa = empresas[1],
                    Fornecedor = fornecedores[1],
                    CadastradoEm = DateTime.Now,
                },
                new EmpresaFornecedor
                {
                    Empresa = empresas[2],
                    Fornecedor = fornecedores[2],
                    CadastradoEm = DateTime.Now,
                },
            };
            context.AddRange(empresasFornecedores);

            context.SaveChanges();
        }
    }
}
