using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI_biblioteca.Models;

namespace WebAPI_biblioteca
{
    [ApiController]
    [Route("api/livros")]
    public class LivrosController : ControllerBase
    {
        private readonly DataContext _context;
        public LivrosController(DataContext context) => _context = context;


        // GET - Método para listar todos os livros
        // Rota - /api/livros
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_context.Livros.AsNoTracking().Include(l => l.Generos).Select(b => new
            {
                Id = b.Id,
                generoLivro = b.Generos.GeneroLivro,
                Titulo = b.Titulo,
                Autor = b.Autor,
                Publicacao = b.Publicacao,
                Paginas = b.Paginas,
                Editora = b.Editora,
                Disponivel = b.Disponivel,
                GeneroId = b.GeneroId
            }));
        }


        // GET - Método para listar livros por id
        // Rota - /api/livros/listar/byid?id=1       (Utilização de QueryString)
        [HttpGet()]
        [Route("listar/byId")]
        public IActionResult ListarById(int id)
        {
            var livro = _context.Livros.FirstOrDefault(a => a.Id == id);
            if (livro == null)
            {
                return BadRequest("Livro não encontrado!");
            }
            return Ok(livro);
        }


        // GET - Método para listar livros por titulo
        // Rota - /api/livros/listar/byname?nome=Harry    (Utilização de QueryString)
        // Fazer - não diferenciacao de maiusculas ou minusculas
        [HttpGet("listar/byName")]
        public IActionResult ListarByName(string nome)
        {
            //Faz a capitalizacao da primeira letra do nome
            string nomeConverted = char.ToUpper(nome[0]) + nome.Substring(1);

            var livro = _context.Livros.FirstOrDefault(a => a.Titulo.Contains(nomeConverted));
            if (livro == null)
            {
                return BadRequest("Livro não encontrado!");
            }
            return Ok(livro);
        }


        // POST - Método para cadastrar um livro    (JSON)
        // Rota - /api/livros/cadastrar
        [HttpPost]
        [Route("cadastrar")]
        public IActionResult Cadastrar([FromBody] Livro livro)
        {
            _context.Add(livro);
            _context.SaveChanges();
            var livroCriado = (_context.Livros.AsNoTracking().Include(l => l.Generos).FirstOrDefault(a => a.Id == livro.Id));
            return Created("", livroCriado);
        }


        //PATCH - Método para editar parcialmente um registro
        //Rota - /api/livros/editar
        [HttpPatch]
        [Route("editar/{id}")]
        public IActionResult Editar(int id, Livro livro)
        {
            var book = _context.Livros.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (book == null)
            {
                return BadRequest("Livro não encontrado!");
            }
            _context.Update(livro);
            _context.SaveChanges();
            return Ok(livro);
        }

        // DELETE - Método para deletar livros por id
        // Rota - /api/livros/deletar/1
        [HttpDelete]
        [Route("deletar/{id}")]
        public IActionResult Deletar(int id)
        {
            var livro = _context.Livros.FirstOrDefault(a => a.Id == id);
            if (livro == null)
            {
                return BadRequest("Livro não encontrado!");
            }
            _context.Remove(livro);
            _context.SaveChanges();
            return Ok();
        }
    }
}
