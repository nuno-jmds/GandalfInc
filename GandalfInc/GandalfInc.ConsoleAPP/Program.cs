using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GandalfInc.DAL.Entidades;
using GandalfInc.DAL.Faturacao;
using GandalfInc.DAL.Repositorios;

namespace GandalfInc.ConsoleAPP
{
    class Program
    {
        static void Main(string[] args)
        {




            Console.WriteLine("Hello World!");
            ImprimirRecibo();
            //ListarProdutos();
        }


        public static void ImprimirRecibo() 
        {
            //Arrange
            var loja1 = new Loja
            {
                Nome = "Loja dos Descontos",
                NumeroFiscal = "503152554",
                Morada = new Morada
                {
                    Rua = "Rua da Loja 1",
                    CodigoPostal = "3770-221",
                    Concelho = "Oliveira Do Bairro",
                    Distrito = "Aveiro"
                },
                Telefone = "232562514",
                Email = "loja@loja.com",
                Gerente = "Vitor Andrade",
            };

            var pontoDeVenda1 = new PontoDeVenda();
            pontoDeVenda1.Loja = loja1;

            var funcionario = new Funcionario
            {
                Nome = "João Nascimento",
                UserName = "João32",
                Password = "123Password"
            };

            var cliente = new Cliente
            {
                Nome = "José Castro",
                NumeroFiscal = "256325148",
                Morada = new Morada
                {
                    Rua = "Rua do cliente",
                    CodigoPostal = "3700-221",
                    Concelho = "Aveiro",
                    Distrito = "Aveiro"
                },
                Telemovel = "912545216",
                Email = "cliente@cliente.com",
                DataDeNascimento = new DateTime(1971, 12, 25)

            };

            var numeroDeSerie = 125;
            var tipoDePagamento = TipoDePagamento.Dinheiro;
            var valorTotal = 100M;
            var detalheVenda = new DetalheVenda
            {
                Produtos = new List<Produto>
                {
                    new Produto
                    {
                        Nome = "Sapatilhas A21",
                        PrecoUnitario=50,
                        Quantidade=10,
                        Fabricante="China",
                        Marca="Adidas",
                        Categoria="Calçado",
                    },
                    new Produto
                    {
                        Nome = "Sapatilhas N21",
                        PrecoUnitario=50,
                        Quantidade=10,
                        Fabricante="China",
                        Marca="Nike",
                        Categoria="Calçado",
                    }
                }
            };
            var vendaParaCliente = new Venda
            {
                PontoDeVenda = pontoDeVenda1,
                Funcionario = funcionario,
                Cliente = cliente,
                NumeroSerie = numeroDeSerie,
                TipoDePagamento = tipoDePagamento,
                ValorTotal = valorTotal,
                DetalheVenda = detalheVenda

            };

            //Act
            vendaParaCliente.GerarRecibo();
        }
        public static void ListarProdutos()
        {
            var repositorio = new RepositorioEntidade();
            var lista = repositorio.ObterTodos();
            var sb = new StringBuilder();
            Console.WriteLine($"Total de Produtos { lista.Count} ");
        }
    }
}
