using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Dominio.Repositorios;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        private readonly IRepositorio<Usuario> _repositorioDeUsuarios;

        public UsuarioController(IRepositorio<Usuario> repositorioDeUsuarios)
        {
            this._repositorioDeUsuarios = repositorioDeUsuarios;
        }

        [HttpGet]
        public IEnumerable<Usuario> Get()
        {
            return this._repositorioDeUsuarios.Listar();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id <= 0)
                return BadRequest("Id não informado");

            var usuario = this._repositorioDeUsuarios.Pegar(id);

            if (usuario == null)
                return NotFound("Usuário não encontrado");

            return new ObjectResult(usuario);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Usuario usuario)
        {
            try
            {
                this._repositorioDeUsuarios.Inserir(usuario);
                return Created("", usuario);
            }
            catch (InvalidOperationException)
            {
                return BadRequest("");
            }
            catch (Exception)
            {
                throw new Exception("");
            }
        }
    }
}
