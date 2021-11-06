using Microsoft.VisualStudio.TestTools.UnitTesting;
using GandalfInc.DAL.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GandalfInc.DAL.Entidades.Tests
{
    [TestClass()]
    public class PessoaTests
    {
        [TestMethod()]
        public void DeveCriarClienteTest()
        {
            //Arrange
            var cliente = new Cliente();
            cliente.Morada.Rua = "Travessa C da Rua do Rossio Lt55 FrA";
            cliente.Morada.CodigoPostal = "3770-221";
            cliente.Morada.Concelho = "Oliveira do Bairro";
            cliente.Morada.Distrito = "Aveiro";
            cliente.NumeroFiscal = "248129554";
            cliente.Telemovel = "915606371";
            //Act
            var possuiIdentificadorAtribuido = cliente.Identificador != new Guid();
            var possuiDataRegistoAtribuida = cliente.DataRegisto != new DateTime();
            //Assert
            Assert.IsNotNull(cliente);
            Assert.IsNotNull(cliente.Ativo);
            Assert.IsInstanceOfType(cliente, typeof(Cliente));
            Assert.IsInstanceOfType(cliente,typeof(Pessoa));
            Assert.IsInstanceOfType(cliente, typeof(Entidade));
            Assert.IsTrue(possuiIdentificadorAtribuido);
            Assert.IsTrue(possuiDataRegistoAtribuida);
        }
    }
}