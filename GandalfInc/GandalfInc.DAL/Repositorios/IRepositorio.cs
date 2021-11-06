using System;
using System.Collections.Generic;

namespace GandalfInc.DAL.Repositorios
{
    interface IRepositorio<T>
    {
        //CRUD
        void Criar(T obj);
        T Atualizar(T obj, T novoObj);
        T ObterPorIdentificador(Guid guid);
        T ObterPorNome(string nome);
        List<T> ObterTodos();
        void Apagar(T obj);
    }
}
