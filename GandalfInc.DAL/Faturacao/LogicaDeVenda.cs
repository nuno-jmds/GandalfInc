using GandalfInc.BusinessLogicLayer.Infraestrutura;
using Projeto.DataAccessLayer.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GandalfInc.DataAccessLayer.Faturacao;

namespace GandalfInc.BusinessLogicLayer.Faturacao
{
    public class LogicaDeVenda:IImpressora
    {
        private Venda _venda { get; set; }

        public LogicaDeVenda(Venda venda)
        {
            _venda = venda;
        }

        private void CalcularValorTotal()
        {
            
        }
        public bool ValidarVenda(LogicaDeStock stock) 
        {
            var quant1 = _venda.DetalheVenda.Produtos
               .GroupBy(produto => produto.Nome).Select(x=>new 
               {
                   Nome = x.Key,
                   Quantidade=x.Sum(x=>x.Quantidade)
               } ).ToList();
           
            
            
            Decimal preco = 0;
            foreach (var product in _venda.DetalheVenda.Produtos)
                {
                    preco += product.PrecoUnitario*product.Quantidade;
                }
            
            var quantidadePorProduto1 = _venda.DetalheVenda.Produtos
                .GroupBy(produto => produto.Nome)
                .Select(produto =>
                new
                {
                    Nome = produto.Key,
                    Quantidade = produto.Count()
                }).ToList();


            var quantidadePorProduto = _venda.DetalheVenda.Produtos
               .GroupBy(produto => produto.Nome)
               .Select(produto =>
               new
               {
                   Nome = produto.Key,
                   Quantidade = produto.Count()
               }).ToList();

            //Impedir "devolucao de produto"
            var existeAlgumItemComValorInvalido = quantidadePorProduto.Any(produto => produto.Quantidade <= 0);
            if (existeAlgumItemComValorInvalido || _venda.DetalheVenda.Produtos.Count <= 0)
            {
                return false;
            }

            foreach (var produtoPedido in quantidadePorProduto)
            {
                var quantidadeEmStock = stock.ProdutosParaVenda.Where(x => x.Nome == produtoPedido.Nome).Count();

                if (quantidadeEmStock < produtoPedido.Quantidade)
                {
                    return false;
                }
            }
            return true;
        }

        public bool EfetuaVenda(LogicaDeStock stock) 
        {

            return true;
        }
        public void GerarRecibo() 
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Loja:{_venda.PontoDeVenda.Loja.Nome}");
            sb.AppendLine($"Contacto: {_venda.PontoDeVenda.Loja.Telefone}");
            sb.AppendLine($"Contacto: {_venda.PontoDeVenda.Loja.Email}");
            sb.AppendLine($"Morada: {_venda.PontoDeVenda.Loja.Morada.Rua}");
            sb.AppendLine($"Morada: {_venda.PontoDeVenda.Loja.Morada.CodigoPostal}");
            sb.AppendLine($"Morada: {_venda.PontoDeVenda.Loja.Morada.Concelho}");
            sb.AppendLine($"NIF: {_venda.PontoDeVenda.Loja.NumeroFiscal}");

            _venda.DataVenda = DateTime.Now;
            sb.AppendLine($"FaturaNr: {_venda.DataVenda.Year}/{_venda.NumeroSerie}");
            sb.AppendLine($"Data/Hora: {_venda.DataVenda.Year}/{_venda.DataVenda.Month}/{_venda.DataVenda.Day} {_venda.DataVenda.Hour}:{_venda.DataVenda.Minute} ");

            _venda.DetalheVenda.Produtos.Select(x=>sb.AppendLine($"Nome:{x.Nome} - valor unitário:{x.PrecoUnitario} - Número de série:{x.ReferenciaInternacionalProduto}"));

            sb.AppendLine($"Total a Pagar: {_venda.ValorTotal}");
            sb.AppendLine($"Tipo Pagamento: {_venda.TipoDePagamento} ");
            

            sb.AppendLine($"Vendedor: {_venda.Funcionario.Nome}");
            sb.AppendLine($"Identificação:{_venda.Funcionario.Identificador}");

            Console.WriteLine(sb);
        }

    }
}
