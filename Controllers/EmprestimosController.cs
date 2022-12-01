using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI_biblioteca.Models;
using WebAPI_biblioteca.Handlers;

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
            // return Ok(_context.Emprestimos.AsNoTracking()
            // .Include(l => l.Livro)
            // .Select(b => new
            // {
            //     Id = b.Id,
            //     DataEmprestimo = b.DataEmprestimo,
            //     DataDevolucao = b.DataDevolucao,
            //     FuncionarioId = b.FuncionarioId,
            //     ClienteId = b.ClienteId,
            //     LivroId = b.LivroId,
            //     Finalizado = b.Finalizado,
            //     Cliente = b.Cliente,
            //     clienteNome= b.Cliente.Nome,
            //     livroTitulo = b.Livro.Titulo
            // }));
            return Ok(_context.Emprestimos);
        }


        // GET - Método para listar emprestimos por id
        // Rota - /api/emprestimos/listar/byid?id=1       (Utilização de QueryString)
        [HttpGet()]
        [Route("listar/byId")]
        public IActionResult ListarById(int id)
        {
            var emprestimo = _context.Emprestimos.FirstOrDefault(e => e.Id == id);
            if (emprestimo == null)
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
            var executaEmprestimoHandler = new ExecutaEmprestimoHandler(null, _context);
            var pendenciaClienteHandler = new PendenciaClienteHandler(executaEmprestimoHandler, _context);
            var disponibilidadeHandler = new DisponibilidadeHandler(pendenciaClienteHandler, _context);

            var result = disponibilidadeHandler.Handle(new EmprestimoRequest(emprestimo));

            if (result.Success)
                return Created("", result.Emprestimo);
            else
                return BadRequest(result.Message);
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