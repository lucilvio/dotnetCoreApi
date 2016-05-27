using TodoApi.Models;
using Xunit;

namespace TodoApi.Tests
{
    public class ListaTeste {
        
        private readonly Lista _lista;
        
        public ListaTeste() {
            this._lista = new Lista(new Usuario("Lucilvio"));
        }
        
        [Fact]
        public void TemUsuario() {
            Assert.NotNull(this._lista.Usuario);
        }
        
        [Fact]
        public void AdicionaItem() {
            this._lista.AdicionarItem(new Item("Primeira atividade"));
            
            Assert.NotEmpty(this._lista.Itens);
        }
        
        [Fact]
        public void MarcaItemComoCompletado() {
            var item = new Item("Atividade de exemplo");
            this._lista.AdicionarItem(item);
        }
    }
}