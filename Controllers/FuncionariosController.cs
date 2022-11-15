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

        // POST: /api/funcionarios/cadastrar
        [HttpPost]
        [Route("cadastrar")]
        public IActionResult Cadastrar([FromBody] Funcionario funcionario)
        {
            _context.Funcionarios.Add(funcionario);
            _context.SaveChanges();
            return Created("", funcionario);
        }

        //GET: /api/funcionarios/buscar/{id}
        [HttpGet]
        [Route("buscar/{id}")]
        public IActionResult Buscar([FromRoute] int id)
        {
            Funcionario funcionario = _context.Funcionarios.FirstOrDefault(funcionarioCadastrado => funcionarioCadastrado.Id.Equals(id));

            return funcionario != null ? Ok(funcionario) : NotFound();
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
                return Ok(funcionario);
            }

            return NotFound();
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
