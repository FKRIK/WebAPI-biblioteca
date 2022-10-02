using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI_biblioteca.Models;

namespace WebAPI_biblioteca.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmprestimosController : ControllerBase
    {
        private readonly DataContext _context;
        public EmprestimosController(DataContext context) => _context = context;
        

        // GET - Método para listar todos os emprestimos
        // Rota - /api/emprestimos
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_context.Emprestimos);
        }


        // GET - Método para listar emprestimos por id
        // Rota - /api/emprestimos/listar/byid?id=1       (Utilização de QueryString)
        [HttpGet()]
        [Route("listar/byId")]
        public IActionResult ListarById(int id)
        {
            var emprestimo = _context.Emprestimos.FirstOrDefault(e => e.Id == id);
            if( emprestimo == null)
            {
                return BadRequest("Empréstimo não encontrado!");
            }
            return Ok(emprestimo);
        }


        // POST - Método para cadastrar um emprestimo    (JSON)
        // Rota - /api/emprestimos/cadastrar
        [HttpPost]
        [Route("cadastrar")]
        public IActionResult Cadastrar([FromBody] Emprestimo emprestimo)
        {
            _context.Add(emprestimo);
            _context.SaveChanges();
            return Created("", emprestimo);
        }


        //PATCH - Método para editar parcialmente um registro
        //Rota - /api/emprestimos/editar
        [HttpPatch]
        [Route("editar/{id}")]
        public IActionResult Editar(int id, Emprestimo emprestimo)
        {
            var emp = _context.Emprestimos.AsNoTracking().FirstOrDefault(e => e.Id == id);
            if (emp == null)
            {
                return BadRequest("Empréstimo não encontrado!");
            }
            _context.Update(emprestimo);
            _context.SaveChanges();
            return Ok(emprestimo);
        }
    }
}