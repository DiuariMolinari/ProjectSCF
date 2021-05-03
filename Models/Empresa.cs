using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCF.Models
{
    public class Empresa
    {
        public Empresa()
        {

        }

        public int EmpresaId { get; set; }

        public string NomeFantasia { get; set; }

        public string Cnpj { get; set; }

        public int EstadoId { get; set; }

        public Estado Estado { get; set; }

        public ICollection<EmpresaFornecedor> EmpresasFornecedores { get; set; }
    }
}
