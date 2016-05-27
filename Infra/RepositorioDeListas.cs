using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TodoApi.Dominio.Repositorios;
using TodoApi.Models;

namespace TodoApi.Infra
{
    public class RepositorioDeListas : IRepositorio<Lista>
    {
        private int _id;
        private readonly ICollection<Lista> _listas;
        
        public RepositorioDeListas() {
            this._listas = new Collection<Lista>();
        }

        public void Inserir(Lista lista)
        {
            if(lista == null)
                return;
                
            lista.Id = ++this._id;    
                
            this._listas.Add(lista);
        }

        public IEnumerable<Lista> Listar()
        {
            return this._listas.ToList();
        }

        public IEnumerable<Lista> Listar(Func<Lista, bool> filtro)
        {
            return this._listas.Where(filtro);
        }

        public Lista Pegar(Func<Lista, bool> filtro)
        {
            return this._listas.FirstOrDefault(filtro);
        }

        public Lista Pegar(int id)
        {
            return this._listas.FirstOrDefault(l => l.Id == id);
        }
    }
}