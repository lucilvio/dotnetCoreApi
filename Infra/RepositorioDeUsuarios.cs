using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TodoApi.Dominio.Repositorios;
using TodoApi.Models;
using Microsoft.EntityFrameworkCore;

namespace TodoApi.Infra
{
    public class RepositorioDeUsuarios : IRepositorio<Usuario>
    {
        private int _id;
        private readonly Contexto _contexto;
        
        public RepositorioDeUsuarios(Contexto contexto) {
            this._contexto = contexto;
        }

        public void Inserir(Usuario usuario)
        {
            if(usuario == null || !usuario.Valido())
                throw new InvalidOperationException();
                
            usuario.Id = ++this._id;
                
            this._contexto.Usuarios.Add(usuario);
            this._contexto.SaveChanges();
        }

        public IEnumerable<Usuario> Listar()
        {
            return this._contexto.Usuarios.ToList();
        }

        public IEnumerable<Usuario> Listar(Func<Usuario, bool> filtro)
        {
            return this._contexto.Usuarios.Where(filtro);
        }

        public Usuario Pegar(Func<Usuario, bool> filtro)
        {
            return this._contexto.Usuarios.FirstOrDefault(filtro);
        }

        public Usuario Pegar(int id)
        {
            return this._contexto.Usuarios.FirstOrDefault(u => u.Id == id);
        }
    }
}