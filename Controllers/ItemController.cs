using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Dominio.Repositorios;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    public class ItemController : Controller {
        
        private readonly IRepositorio<Lista> _repositorioDeListas;
        
        public ItemController(IRepositorio<Lista> repositorioDeListas) {
            this._repositorioDeListas = repositorioDeListas;
        }
        
        [HttpGet("{idDaLista}")]
        public IActionResult Get(int idDaLista) {
            if(idDaLista <= 0)
                return BadRequest("Lista não informada");
            
            var lista = this._repositorioDeListas.Pegar(l => l.Id == idDaLista);
            
            if(lista == null) {
                return NotFound("Lista não encontrada");
            }
            
            return new ObjectResult(lista.Itens);
        }
        
        [HttpPost]
        public IActionResult Post([FromBody] Item item) {
            if(item == null || !item.Valido())
                return BadRequest("Item inválido");
            
            var lista = this._repositorioDeListas.Pegar(l => l.Id == item.IdDaLista);
            
            if(lista == null)
                return NotFound("Lista não encontrada");
            
            lista.AdicionarItem(item);
            
            return Created("", item);
        }
    }
}