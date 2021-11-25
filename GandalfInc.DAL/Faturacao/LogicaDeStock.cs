using GandalfInc.DataAccessLayer.Entidades;
using GandalfInc.DataAccessLayer.Faturacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GandalfInc.BusinessLogicLayer.Faturacao
{
    public class LogicaDeStock
    {
        private Stock _stock { get; set; }

        public LogicaDeStock(Stock stock)
        {
            _stock = stock;
        }
        public List<Produto> ProdutosParaVenda { get; set; }

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
                var quantidadeEmStock = ProdutosParaVenda.Where(x => x.Nome == produtoPedido.Nome).Count();

                if (quantidadeEmStock < produtoPedido.Quantidade)
                {
                    return false;
                }
            }
            return true;
        }

    }
}
