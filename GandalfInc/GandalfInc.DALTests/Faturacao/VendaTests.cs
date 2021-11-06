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
                ProdutosPartaVenda = new List<Produto>
                {
                    new Produto { Nome = "Computador" },
                    new Produto { Nome = "Computador" },
                    new Produto { Nome = "Computador" },
                    new Produto { Nome = "Computador" },
                    new Produto { Nome = "Smarthphone" }
                }
            };

            var vendaParaOJoao = new Venda
            { 
            DetalheVenda=new DetalheVenda {Produtos=new List<Produto>() }
            };
            vendaParaOJoao.DetalheVenda.Produtos.Add(new Produto { Nome = "Smarthphone" });
            vendaParaOJoao.DetalheVenda.Produtos.Add(new Produto { Nome = "Smarthphone" });
            
            
            //Act
            var vendaPossivel = stock.ValidarDisponibilidade(vendaParaOJoao.DetalheVenda.Produtos);
            //Assert
            Assert.IsFalse(vendaPossivel);
        }
    }
}