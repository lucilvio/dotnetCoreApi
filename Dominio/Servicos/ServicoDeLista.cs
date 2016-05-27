using TodoApi.Dominio.Repositorios;
using TodoApi.Models;

namespace TodoApi.Servicos
{
    public class ServicoDeListas
    {
        private readonly IRepositorio<Lista> _repositorioDeListas;
        private readonly IRepositorio<Usuario> _repositorioDeUsuarios;
        
        public ServicoDeListas(IRepositorio<Lista> repositorioDeListas, IRepositorio<Usuario> repositorioDeUsuarios) {
            this._repositorioDeListas = repositorioDeListas;
            this._repositorioDeUsuarios = repositorioDeUsuarios;
        }
        public void CadastrarNovaLista(Lista lista) {
            var usuarioEncontrado = this._repositorioDeUsuarios.Pegar(u => u.Id == lista.IdDoUsuario);
            var listaParaCadastro = new Lista(usuarioEncontrado);
            
            this._repositorioDeListas.Inserir(lista);
        }
    }
}