using System;
using System.Collections.Generic;

namespace Projeto.DataAccessLayer.Repositorios
{
    interface IRepositorio<T>
    {
        //CRUD
        void Criar(T obj);
        T Atualizar(T obj, T novoObj);
        T ObterPorIdentificador(Guid guid);
        List<T> ObterPorNome(string nome);
        List<T> ObterTodos();
        void Apagar(T obj);
    }
}
