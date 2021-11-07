using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GandalfInc.DAL.Entidades
{
    public class Produto : Entidade
    {
        public Produto()
        {
            Quantidade = 1;
        }
        public decimal PrecoUnitario { get; set; }

        public int Quantidade { get; set; }

        public string Fabricante { get; set; }

        public string Marca { get; set; }

        public string Categoria { get; set; }

        public Fornecedor Fornecedor { get; set; }

        public string ReferenciaInternacionalProduto { get; set; }
        public string NumeroSerie { get; set; }
    }
}
