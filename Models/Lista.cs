using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace TodoApi.Models
{
    public class Lista
    {
        public Lista() {
            this.Itens = new Collection<Item>();
        }
        
        public Lista(int idDoUsuario) : this()
        {
            if(idDoUsuario <= 0)
                throw new InvalidOperationException("Não é possível criar uma lista sem usuário");
                
            this.IdDoUsuario = idDoUsuario;
        }
        
        public Lista(Usuario usuario) : this() {
            if(usuario == null)
                throw new InvalidOperationException("Não é possível criar uma lista sem usuário");
                
            this.Usuario = usuario;
        }

        public void AdicionarItem(Item item)
        {
            if(item == null)
                return;
                
            this.Itens.Add(item);
        }

        public void ArquivarItem(Item item)
        {
            if(item == null)
                return;
                
            Item itemEncontrado = this.Itens.FirstOrDefault(i => i.Id == item.Id);
            itemEncontrado.Arquivar();
        }
        
        public int Id { get; set; }
        public int IdDoUsuario { get; set; }

        public Usuario Usuario { get; set; }
        public ICollection<Item> Itens { get; set; }
    }
}
