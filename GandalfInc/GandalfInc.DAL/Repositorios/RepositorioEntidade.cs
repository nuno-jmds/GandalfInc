using GandalfInc.DAL.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GandalfInc.DAL.Repositorios
{
    public class RepositorioEntidade : IRepositorio<Entidade>
    {
        private readonly List<Entidade> ListaEntidades;

        public RepositorioEntidade()
        {
            ListaEntidades = new List<Entidade>(); 
        }

        public void Apagar(Entidade obj)
        {
            ListaEntidades.Remove(obj);
        }

        public Entidade Atualizar(Entidade obj, Entidade novoObj)
        {
            var temp = obj.Identificador;
            obj = novoObj;
            obj.Identificador = temp;
            return obj;
        }

        public void Criar(Entidade obj)
        {
            ListaEntidades.Add(obj);
        }

        public Entidade ObterPorIdentificador(Guid guid)
        {
            var resultado = ListaEntidades.FirstOrDefault(entidade => entidade.Identificador == guid);
            return resultado;
        }
        public List<Entidade> ObterPorNome(string nome)
        {
            var resultado = ListaEntidades.Where(entidade => entidade.Nome == nome).ToList();
            return resultado;
        }

        public List<Entidade> ObterTodos()
        {
            return ListaEntidades;
        }
    }
}
