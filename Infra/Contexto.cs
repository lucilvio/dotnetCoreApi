using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Infra
{
    public class Contexto : DbContext {
        
        public Contexto(DbContextOptions<Contexto> options) : base(options) {
        
        }
        
        public DbSet<Lista> Listas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Item> Itens { get; set; }
    }
}