namespace TodoApi.Models
{
    public class Item
    {
        public Item() {
            this.Concluido = false;
            this.Arquivado = false;
        }
        
        public Item(string descricao) : this() {
            this.Descricao = descricao;
        }
        
        public int Id { get; set; }
        public string Descricao { get; set; }
        public bool Concluido { get; set; }
        public bool Arquivado { get; private set; }
        
        public int IdDaLista { get; set; }
        
        public void Arquivar() {
            this.Arquivado = true;
        }
        
        public bool Valido() {
            return !string.IsNullOrEmpty(this.Descricao) && this.IdDaLista > 0;
        }
    }
}
