using Microsoft.VisualStudio.TestTools.UnitTesting;
using GandalfInc.DAL.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GandalfInc.DAL.Entidades;
using GandalfInc.BusinessLogicLayer.Repositorios;
using Projeto.DataAccessLayer.Entidades;

namespace GandalfInc.DAL.Repositorios.Tests
{
    [TestClass()]
    public class RepositorioEntidadeTests
    {
        [TestMethod()]
        public void DeveCriarEntidadeTest()
        {
            var repo = new RepositorioEntidade();
            var cliente = new Cliente();
            var loja = new Loja();

            repo.Criar(cliente);
            repo.Criar(loja);
            var quantidade = repo.ObterTodos().Count;


            Assert.AreEqual(2, quantidade);
        }

        [TestMethod()]
        public void ApagarTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AtualizarTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CriarTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeveObterPorIdentificadorEntidadeTest()
        {
            var repo = new RepositorioEntidade();

            var cliente = new Cliente { Nome = "Nuno" };
            var identificadorCliente = cliente.Identificador;
            var loja = new Loja();
            var cliente2 = new Cliente { Nome = "Pessoa Esquecida" };


            //act

            repo.Criar(cliente);
            repo.Criar(loja);
            repo.Criar(cliente2);
            var obtido = repo.ObterPorIdentificador(identificadorCliente);

            //Assert
            Assert.AreEqual("Nuno", obtido.Nome);
        }

        [TestMethod()]
        [DataRow("João",true)]
        [DataRow("Loja de Lisboa",true)]
        public void DeveObterPorNomeEntidadeTestTest(string nome,bool parametroExemplo)
        {
            //Arrange
            var repo = new RepositorioEntidade();
            var cliente = new Cliente { Nome = nome ,Ativo=true};
            //Act
            repo.Criar(cliente);
            //Assert
            Assert.AreEqual(parametroExemplo,cliente.Ativo);
        }

        [TestMethod()]
        public void ObterTodosTest()
        {
            Assert.Fail();
        }
    }
}