
using Projeto.DataAccessLayer.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GandalfInc.DataAccessLayer.Faturacao
{
    public class Venda
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public PontoDeVenda PontoDeVenda { get; set; }
        public Funcionario Funcionario { get; set; }
        public Cliente Cliente { get; set; }

        public DateTime DataVenda { get; set; }
        public int NumeroSerie { get; set; }

        public TipoDePagamento TipoDePagamento { get; set; }

        private Decimal valorTotal;
        public Decimal ValorTotal { get { return valorTotal; } }

        public DetalheVenda DetalheVenda{get;set;}


        private void CalcularValorTotal()
        {
            
        }
        public bool ValidarVenda(Stock stock) 
        {
            var quant1 = DetalheVenda.Produtos
               .GroupBy(produto => produto.Nome).Select(x=>new 
               {
                   Nome = x.Key,
                   Quantidade=x.Sum(x=>x.Quantidade)
               } ).ToList();
           
            
            
            Decimal preco = 0;
            foreach (var product in DetalheVenda.Produtos)
                {
                    preco += product.PrecoUnitario*product.Quantidade;
                }
            
            var quantidadePorProduto1 = DetalheVenda.Produtos
                .GroupBy(produto => produto.Nome)
                .Select(produto =>
                new
                {
                    Nome = produto.Key,
                    Quantidade = produto.Count()
                }).ToList();


            var quantidadePorProduto = DetalheVenda.Produtos
               .GroupBy(produto => produto.Nome)
               .Select(produto =>
               new
               {
                   Nome = produto.Key,
                   Quantidade = produto.Count()
               }).ToList();

            //Impedir "devolucao de produto"
            var existeAlgumItemComValorInvalido = quantidadePorProduto.Any(produto => produto.Quantidade <= 0);
            if (existeAlgumItemComValorInvalido || DetalheVenda.Produtos.Count <= 0)
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

        public bool EfetuaVenda(Stock stock) 
        {

            return true;
        }
        public void GerarRecibo() 
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Loja:{PontoDeVenda.Loja.Nome}");
            sb.AppendLine($"Contacto: {PontoDeVenda.Loja.Telefone}");
            sb.AppendLine($"Contacto: {PontoDeVenda.Loja.Email}");
            sb.AppendLine($"Morada: {PontoDeVenda.Loja.Morada.Rua}");
            sb.AppendLine($"Morada: {PontoDeVenda.Loja.Morada.CodigoPostal}");
            sb.AppendLine($"Morada: {PontoDeVenda.Loja.Morada.Concelho}");
            sb.AppendLine($"NIF: {PontoDeVenda.Loja.NumeroFiscal}");
            
            DataVenda = DateTime.Now;
            sb.AppendLine($"FaturaNr: {DataVenda.Year}/{NumeroSerie}");
            sb.AppendLine($"Data/Hora: {DataVenda.Year}/{DataVenda.Month}/{DataVenda.Day} {DataVenda.Hour}:{DataVenda.Minute} ");

            DetalheVenda.Produtos.Select(x=>sb.AppendLine($"Nome:{x.Nome} - valor unitário:{x.PrecoUnitario} - Número de série:{x.ReferenciaInternacionalProduto}"));

            sb.AppendLine($"Total a Pagar: {ValorTotal}");
            sb.AppendLine($"Tipo Pagamento: {TipoDePagamento} ");
            

            sb.AppendLine($"Vendedor: {Funcionario.Nome}");
            sb.AppendLine($"Identificação:{Funcionario.Identificador}");

            Console.WriteLine(sb);
        }

    }
}
