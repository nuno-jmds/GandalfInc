using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GandalfInc.DAL.Entidades
{
    public class Produto : Entidade
    {
        public decimal PrecoUnitario { get; set; }

        public string Fabricante { get; set; }

        public Fornecedor Fornecedor { get; set; }

        public string ReferenciaInternacionalProduto { get; set; }
        public string NumeroSerie { get; set; }
    }
}
