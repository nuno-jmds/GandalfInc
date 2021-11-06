using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GandalfInc.DAL.Entidades
{
    public class Stock
    {
        public List<Produto> ProdutosPartaVenda { get; set; }

        public bool ValidarDisponibilidade(List<Produto> produtosSolicitados)
        {
            var quantidadePorProduto = produtosSolicitados
                .GroupBy(x => x.Nome)
                .Select(x => 
                new
                {
                    Nome = x.Key,
                    Quantidade=x.Count()
                }).ToList();

            //Impedir "devolucao de produto"
            var existeAlgumItemComValorInvalido = quantidadePorProduto.Any(produto => produto.Quantidade <= 0);
            if (existeAlgumItemComValorInvalido || produtosSolicitados.Count <= 0)
            {
                return false;
            }

            foreach (var produtoPedido in quantidadePorProduto)
            {
                var quantidadeEmStock = ProdutosPartaVenda.Where(x => x.Nome == produtoPedido.Nome).Count();

                if (quantidadeEmStock < produtoPedido.Quantidade ||produtoPedido.Quantidade<=0)
                {
                    return false;
                }
            }
            return true;
        }

    }
}
