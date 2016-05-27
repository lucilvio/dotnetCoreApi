using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TodoApi.Dominio.Repositorios
{
    public interface IRepositorio<T> where T : class
    {
        T Pegar(int id);
        T Pegar(Func<T, bool> filtro);
        IEnumerable<T> Listar();
        IEnumerable<T> Listar(Func<T, bool> filtro);
        void Inserir(T objeto);
    }
}