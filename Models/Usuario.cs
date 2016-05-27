namespace TodoApi.Models
{
    public class Usuario
    {
        public Usuario() {
            this.Ativo = true;                
        }
        public Usuario(int id) : this() {
            this.Id = id;
        }
        
        public Usuario(string nome) {
            this.Nome = nome;
        }
        
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
        
        public bool Valido() {
            return !string.IsNullOrEmpty(this.Nome);
        }
    }
}