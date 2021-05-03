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

            context.SaveChanges();
        }
    }
}
