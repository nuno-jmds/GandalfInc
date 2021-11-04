using System.Collections.Generic;

namespace GandalfInc.DAL.Repositorios
{
    interface IRepositorio<T>
    {
        //CRUD
        void Criar(T obj);
        T Atualizar(string nomeAntigo, string nomeNovo);
        T ObterPorNome(string Nome);
        List<T> ObterTodos();
        void Apagar(T obj);
    }
}
