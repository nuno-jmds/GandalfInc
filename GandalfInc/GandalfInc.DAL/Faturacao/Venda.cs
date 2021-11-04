using GandalfInc.DAL.Faturacao;
using GandalfInc.DAL.Infraestrutura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GandalfInc.DAL.Entidades
{
    class Venda:IImpressora
    {

        public PontoDeVenda PontoDeVenda { get; set; }
        public Funcionario Funcionario { get; set; }
        public Cliente Cliente { get; set; }

        public DateTime DataVenda { get; set; }
        public int NumeroSerie { get; set; }

        public TipoDePagamento TipoDePagamento { get; set; }

        public Decimal ValorTotal { get; set; }

        public DetalheVenda DetalheVenda{get;set;}

        public void GerarRecibo() 
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Loja:{PontoDeVenda.Loja.Nome}");
            sb.AppendLine($"Contacto: {PontoDeVenda.Loja.Contacto.Telefone}");
            sb.AppendLine($"Morada: {PontoDeVenda.Loja.Morada}");
            sb.AppendLine($"NIF: {PontoDeVenda.Loja.NumeroFiscal}");

            sb.AppendLine($"FaturaNr: {DataVenda.Year}/{NumeroSerie}");
            sb.AppendLine($"Data/Hora: {DataVenda.Year}/{DataVenda.Month}/{DataVenda.Day} {DataVenda.Hour}:{DataVenda.Minute} ");

            DetalheVenda.Produtos.Select(x=>sb.AppendLine($"Nome:{x.Nome} - valor unitário:{x.PrecoUnitario} - Número de série:{x.ReferenciaInternacionalProduto}"));

            sb.AppendLine($"Total a Pagar: {ValorTotal}");
            sb.AppendLine($"Tipo Pagamento: {TipoDePagamento} ");
            

            sb.AppendLine($"Vendedor: {Funcionario.Nome}");
            sb.AppendLine($"Identificação:{Funcionario.Identificador}");
        }

    }
}
