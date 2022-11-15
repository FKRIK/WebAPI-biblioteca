using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        [Route("listar/{id}")]
        public IActionResult Buscar([FromRoute] int id)
        {
            var cliente = _context.Clientes.FirstOrDefault(clienteCadastrado => clienteCadastrado.Id.Equals(id));
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
                return Ok(cliente);
            }

            return NotFound();
        }

        //Patch: /api/clientes/editar
        [HttpPatch]
        [Route("editar")]
        public IActionResult Editar([FromBody] Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            _context.SaveChanges();
            return Ok(cliente);
        }
    }
}
