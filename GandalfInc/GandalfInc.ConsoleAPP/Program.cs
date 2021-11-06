using System;
using System.Linq;
using System.Text;
using GandalfInc.DAL.Entidades;
using GandalfInc.DAL.Repositorios;

namespace GandalfInc.ConsoleAPP
{
    class Program
    {
        static void Main(string[] args)
        {




            Console.WriteLine("Hello World!");
            Login();
            ListarProdutos();
        }


        public static void Login() 
        {
            var funcionario = new Funcionario();
            funcionario.Nome = "Nuno";
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
