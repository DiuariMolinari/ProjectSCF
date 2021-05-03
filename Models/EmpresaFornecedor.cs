using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCF.Models
{
    public class EmpresaFornecedor
    {
        public int Id { get; set; }

        public int EmpresaId { get; set; }

        public Empresa Empresa { get; set; }

        public int FornecedorId { get; set; }

        public Fornecedor Fornecedor { get; set; }
    }
}
