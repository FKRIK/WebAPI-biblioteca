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
    [Route("api/funcionarios")]
    public class FuncioariosController : ControllerBase
    {
        // Criação de variável global CONTEXTO, para que CONTEXT receba o contexto passado pelo controller
        private readonly DataContext _context;

        // Construtor do controller
        public FuncioariosController(DataContext context) => _context = context;

        //GET: /api/funcionarios/listar
        [HttpGet]
        [Route("listar")]
        public IActionResult Listar()
        {
            return Ok(_context.Funcionarios.ToList());
        }

        //GET: /api/funcionarios/buscar/{id}
        [HttpGet]
        [Route("listar/{id:int}")]
        public IActionResult BuscarPorId([FromRoute] int id)
        {
            var funcionario = _context.Funcionarios.FirstOrDefault(funcionarioCadastrado => funcionarioCadastrado.Id.Equals(id));
            if (funcionario == null) return NotFound("Funcionário não cadastrado no sistema!");

            return Ok(funcionario);
        }

        // POST: /api/funcionarios/cadastrar
        [HttpPost]
        [Route("cadastrar")]
        public IActionResult Cadastrar([FromBody] Funcionario funcionario)
        {
            _context.Funcionarios.Add(funcionario);
            _context.SaveChanges();
            return Created("", funcionario);
        }

        //Delete: /api/funcionarios/deletar/{id}
        [HttpDelete]
        [Route("deletar/{id}")]
        public IActionResult Deletar([FromRoute] int id)
        {
            Funcionario funcionario = _context.Funcionarios.FirstOrDefault(funcionarioCadastrado => funcionarioCadastrado.Id.Equals(id));

            if (funcionario != null)
            {
                _context.Funcionarios.Remove(funcionario);
                _context.SaveChanges();
                return Ok("Funcionário deletado com sucesso");
            }

            return NotFound("Funcionário não cadastrado no sistema!");
        }


        //Patch: /api/funcionarios/editar
        [HttpPatch]
        [Route("editar/{id}")]
        public IActionResult Editar([FromRoute]int id, [FromBody] Funcionario funcionario)
        {
            var employee = _context.Funcionarios.AsNoTracking().FirstOrDefault(funcionarioCadastrado => funcionarioCadastrado.Id == id);
            if(employee == null) return BadRequest("Funcionario não encontrado!");

            _context.Funcionarios.Update(funcionario);
            _context.SaveChanges();
            return Ok(funcionario);
        }
    }
}
