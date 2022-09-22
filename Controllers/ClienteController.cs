using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebAPI_biblioteca.Controllers
{
    [ApiController]
    [Route("api/cliente")]
    public class ClienteController : ControllerBase
    {
        private readonly DataContext _context;

        public ClienteController(DataContext context) => _context = context;

        //GET: /api/cliente/listar
        [HttpGet]
        [Route("listar")]
        public IActionResult Listar()
        {

            return Ok(_context.Cliente.ToList());
        }

        // POST: /api/funcionario/cadastrar
        [HttpPost]
        [Route("cadastrar")]
        public IActionResult Cadastrar([FromBody] Cliente cliente)
        {

            //contexto.propriedade/classe.metodo
            _context.Cliente.Add(cliente);

            //sempre que tiver um crud - menos listar, deve ter a operação de savechanges
            _context.SaveChanges();

            return Created("", cliente);
        }

        //GET: /api/cliente/buscar/{codCliente}
        [HttpGet]
        [Route("buscar/{codCliente}")]
        public IActionResult Buscar([FromRoute] string codCliente)
        {
            Cliente cliente = _context.Cliente.FirstOrDefault(clienteCadastrado => clienteCadastrado.CodCliente.Equals(codCliente));

            return cliente != null ? Ok(cliente) : NotFound();
        }

        //Delete: /api/cliente/deletar/{cpf}
        [HttpDelete]
        [Route("deletar/{codCliente}")]
        public IActionResult Deletar([FromRoute] string codCliente)
        {
            foreach (Cliente clienteCadastrado in clientes)
            {
                string nomeCliente = clienteCadastrado.Nome;

                clientes.Remove(clienteCadastrado);
                return Ok($"Cliente {nomeCliente} deletado com sucesso!");
            }
            return NotFound();
        }


        //Patch: /api/cliente/editar
        [HttpPatch]
        [Route("editar")]
        public IActionResult Editar([FromBody] Cliente cliente)
        {

            Cliente clienteBuscado = cliente.FirstOrDefault(clienteBuscado => clienteBuscado.CodCliente.Equals(cliente.CodCliente));

            if (clienteBuscado != null)
            {
                clienteBuscado.Nome = cliente.Nome;
                return Ok(cliente);
            }
            return NotFound();
        }
    }
}
