using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SCF.Models
{
    public class Estado
    {
        public Estado()
        {

        }

        public int EstadoId { get; set; }

        public string Nome { get; set; }

        public string Sigla { get; set; }

        public int PaisId { get; set; }

        public Pais Pais { get; set; }
    }
}
