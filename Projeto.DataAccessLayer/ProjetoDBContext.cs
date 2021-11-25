using GandalfInc.DataAccessLayer.Entidades;
using GandalfInc.DataAccessLayer.Faturacao;
using Microsoft.EntityFrameworkCore;
using Projeto.DataAccessLayer.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.DataAccessLayer
{
    public class ProjetoDBContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionString = @"Server=(LocalDB)\MSSQLLocalDB;Database=ProjetoDB;Trusted_Connection=True;";
            options.UseSqlServer(connectionString);
        }

        DbSet<Morada> Moradas { get; set; }
        DbSet<Funcionario> Funcionario { get; set; }
        DbSet<Cliente> Clientes { get; set; }
        DbSet<Fornecedor> Fornecedores { get; set; }
        DbSet<Loja> Lojas { get; set; }
        DbSet<Produto> Produtos { get; set; }
        DbSet<CategoriaProduto> CategoriaProdutos { get; set; }

        DbSet<Stock> Stocks { get; set; }
       



    }
}
