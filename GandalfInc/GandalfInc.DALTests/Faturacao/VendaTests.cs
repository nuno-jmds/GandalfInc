using Microsoft.VisualStudio.TestTools.UnitTesting;
using GandalfInc.DAL.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GandalfInc.DAL.Faturacao;

namespace GandalfInc.DAL.Entidades.Tests
{
    [TestClass()]
    public class VendaTests
    {
        [TestMethod()]
        public void EfetivarVendaTest()
        {
            //Arrange
            var stock = new Stock
            {
                ProdutosParaVenda = new List<Produto>
                {
                    new Produto { Nome = "Computador" },
                    new Produto { Nome = "Computador" },
                    new Produto { Nome = "Computador" },
                    new Produto { Nome = "Computador",Quantidade=10 },
                    new Produto { Nome = "Smarthphone" }
                }
            };

            var vendaParaOJoao = new Venda
            {
                DetalheVenda = new DetalheVenda { Produtos = new List<Produto>() }
            };
            vendaParaOJoao.DetalheVenda.Produtos.Add(new Produto { Nome = "Smarthphone" });
            vendaParaOJoao.DetalheVenda.Produtos.Add(new Produto { Nome = "Smarthphone" });
            vendaParaOJoao.DetalheVenda.Produtos.Add(new Produto { Nome = "Computador" });


            //Act
            var vendaPossivel = stock.ValidarDisponibilidade(vendaParaOJoao.DetalheVenda.Produtos);
            //Assert
            Assert.IsFalse(vendaPossivel);
        }
        /// <summary>
        /// Tentar comprar mais artigos do que os existentes no stock.  
        /// </summary>
        [TestMethod()]
        public void ValidarVendaTest()
        {
            //Arrange
            var stock = new Stock
            {
                ProdutosParaVenda = new List<Produto>
                {
                    new Produto { Nome = "Computador" },
                    new Produto { Nome = "Computador" },
                    new Produto { Nome = "Computador" },
                    new Produto { Nome = "Computador",Quantidade=10 },
                    new Produto { Nome = "Smarthphone" }
                }
            };

            var vendaParaOJoao = new Venda
            {
                DetalheVenda = new DetalheVenda { Produtos = new List<Produto>() }
            };
            vendaParaOJoao.DetalheVenda.Produtos.Add(new Produto { Nome = "Smarthphone" ,
                PrecoUnitario = 50,
                Quantidade = 1,
            });
            vendaParaOJoao.DetalheVenda.Produtos.Add(new Produto { Nome = "Smarthphone",
                PrecoUnitario = 50,
                Quantidade = 1,
            });
            vendaParaOJoao.DetalheVenda.Produtos.Add(new Produto
            {
                Nome = "Computador",
                PrecoUnitario = 50,
                Quantidade = 3,
            });


            //Act
            var validarVenda = vendaParaOJoao.ValidarVenda(stock);
            //Assert
            Assert.IsFalse(validarVenda);
        }

        [TestMethod()]
        public void GerarReciboTest()
        {
            //Arrange
            var loja1 = new Loja
            {   
                Nome="Loja dos Descontos",
                NumeroFiscal="503152554",
                Morada=new Morada
                {
                    Rua="Rua da Loja 1",
                    CodigoPostal="3770-221",
                    Concelho="Oliveira Do Bairro",
                    Distrito="Aveiro"
                },
                Telefone="232562514",
                Email="loja@loja.com",
                Gerente = "Vitor Andrade",
            };

            var pontoDeVenda1 = new PontoDeVenda();
            pontoDeVenda1.Loja = loja1;

            var funcionario = new Funcionario 
            {
                Nome="João Nascimento",
                UserName="João32",
                Password="123Password"
            };

            var cliente = new Cliente
            {
                Nome = "José Castro",
                NumeroFiscal="256325148",
                Morada = new Morada
                {
                    Rua = "Rua do cliente",
                    CodigoPostal = "3700-221",
                    Concelho = "Aveiro",
                    Distrito = "Aveiro"
                },
                Telemovel="912545216",
                Email="cliente@cliente.com",
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
                TipoDePagamento=tipoDePagamento,
                
                DetalheVenda=detalheVenda

            };

            //Act
            vendaParaCliente.GerarRecibo();
            //Assert

            Assert.IsTrue(true);
        }
    }
}