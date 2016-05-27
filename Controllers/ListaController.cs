using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Dominio.Repositorios;
using TodoApi.Models;
using TodoApi.Servicos;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    public class ListaController : Controller
    {
        private readonly ServicoDeListas _servicoDeListas;
        private readonly IRepositorio<Lista> _repositorioDeListas;

        public ListaController(ServicoDeListas servicoDeListas, IRepositorio<Lista> repositorioDeListas)
        {
            this._servicoDeListas = servicoDeListas;
            this._repositorioDeListas = repositorioDeListas;
        }

        [HttpGet]
        public IEnumerable<Lista> Get()
        {
            return this._repositorioDeListas.Listar();
        }
        
        [HttpGet("{id}")]
        public IActionResult Get(int id) {
            if(id <= 0)
                return BadRequest("id não informado");
            
            var lista = this._repositorioDeListas.Pegar(id);
            
            if(lista == null)
                return NotFound("Lista não encontrada");
            
            return new ObjectResult(lista);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Lista lista)
        {
            try
            {
                this._servicoDeListas.CadastrarNovaLista(lista);
                return Created("", lista);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}