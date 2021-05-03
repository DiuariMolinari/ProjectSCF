using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCF.Models
{
    public class Contato
    {
        public int ContatoId { get; set; }

        public string Telefone { get; set; }

        public int FornecedorId { get; set; }

        public Fornecedor Fornecedor { get; set; }
    }
}
