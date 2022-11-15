using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebAPI_biblioteca.Models;

namespace WebAPI_biblioteca.Controllers
{
    [ApiController]
    [Route("api/clientes")]
    public class ClientesController : ControllerBase
    {
        // Criação de variável global CONTEXTO, para que CONTEXT receba o contexto passado pelo controller
        private readonly DataContext _context;

        // Construtor do controller
        public ClientesController(DataContext context) => _context = context;

        //GET: /api/clientes/listar
        [HttpGet]
        [Route("listar")]
        public IActionResult Listar()
        {
            return Ok(_context.Clientes.ToList());
        }

        //GET: /api/clientes/buscar/{id}
        [HttpGet]
        [Route("listar/{id:int}")]
        public IActionResult BuscarPorId([FromRoute] int id)
        {
            var cliente = _context.Clientes.FirstOrDefault(clienteCadastrado => clienteCadastrado.Id.Equals(id));
            if (cliente == null) return NotFound("Cliente não cadastrado no sistema!");
            
            return Ok(cliente);
        }

        //GET: /api/clientes/buscar/{id}
        [HttpGet]
        [Route("listar/{nome}")]
        public IActionResult BuscarPorNome([FromRoute] string nome)
        {
            //Faz a capitalizacao da primeira letra do nome
            string nomeConverted = char.ToUpper(nome[0]) + nome.Substring(1);
            
            var cliente = _context.Clientes.FirstOrDefault(clienteCadastrado => clienteCadastrado.Nome.Contains(nomeConverted));
            if (cliente == null) return NotFound("Cliente não cadastrado no sistema!");
            
            return Ok(cliente);
        }

        // POST: /api/clientes/cadastrar
        [HttpPost]
        [Route("cadastrar")]
        public IActionResult Cadastrar([FromBody] Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
            return Created("", cliente);
        }

        

        //Delete: /api/clientes/deletar/{id}
        [HttpDelete]
        [Route("deletar/{id}")]
        public IActionResult Deletar([FromRoute] int id)
        {
            Cliente cliente = _context.Clientes.FirstOrDefault(clienteCadastrado => clienteCadastrado.Id.Equals(id));

            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
                _context.SaveChanges();
                return Ok("Cliente deletado com sucesso");
            }

            return NotFound("Cliente não cadastrado no sistema!");
        }

        //Patch: /api/clientes/editar/1
        [HttpPatch]
        [Route("editar/{id}")]
        public IActionResult Editar([FromRoute]int id, [FromBody] Cliente cliente)
        {
            var customer = _context.Clientes.AsNoTracking().FirstOrDefault(clienteCadastrado => clienteCadastrado.Id == id);
            if(customer == null) return BadRequest("Cliente não encontrado!");

            _context.Clientes.Update(cliente);
            _context.SaveChanges();
            return Ok(cliente);
        }
    }
}
