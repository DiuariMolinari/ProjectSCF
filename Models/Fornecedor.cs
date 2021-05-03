using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SCF.Models
{
    public class Fornecedor
    {
        public Fornecedor()
        {

        }

        public int FornecedorId { get; set; }

        public string Nome { get; set; }

        public string CpfCnpj { get; set; }

        public string Rg { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CadastradoEm { get; set; }

        public ICollection<Contato> Contatos { get; set; }

        public ICollection<EmpresaFornecedor> EmpresasFornecedores { get; set; }
    }
}
