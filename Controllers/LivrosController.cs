using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebAPI_biblioteca.Models;

namespace WebAPI_biblioteca
{
    [ApiController]
    [Route("api/livros")]
    public class LivrosController : ControllerBase
    {
        private List<Livro> livros = new List<Livro>()
        {
            new Livro()
            {
                Id = 1,
                Titulo = "Harry Potter",
                Autor = "JK Rowling",
                Paginas = 314
            },
            new Livro()
            {
                Id = 2,
                Titulo = "Senhor dos Anéis",
                Autor = "JRR Tolkien",
                Paginas = 533
            },
            new Livro()
            {
                Id = 3,
                Titulo = "Percy Jackson",
                Autor = "Rick Riordan",
                Paginas = 489
            }
        }; 
        private readonly DataContext _context;

        // GET - Método para listar todos os livros
        // Rota - /api/listar
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(livros);
        }


        // GET - Método para listar livros por id
        // Rota - /api/listar/byid?id=1       (Utilização de QueryString)
        [HttpGet()]
        [Route("byId")]
        public IActionResult ListarById(int id)
        {
            var livro = livros.FirstOrDefault(a => a.Id == id);
            if( livro == null)
            {
                return BadRequest("Livro não encontrado!");
            }
            return Ok(livro);
        }


        // GET - Método para listar livros por titulo
        // Rota - /api/listar/byname?nome=Harry    (Utilização de QueryString)
        // Fazer - não diferencicao de maiusculas ou minusculas
        [HttpGet("byName")]
        public IActionResult ListarByName(string nome)
        {
            var livro = livros.FirstOrDefault(a => a.Titulo.Contains(nome));
            if( livro == null)
            {
                return BadRequest("Livro não encontrado!");
            }
            return Ok(livro);
        }


        // POST - Método para cadastrar um livro    (JSON)
        // Rota - /api/livros/cadastrar
        [HttpPost]
        [Route("cadastrar")]
        public IActionResult Cadastrar(Livro livro)
        {
            livros.Add(livro);
            return Created("", livros);
        }


        //PATCH - Método para editar parcialmente um registro
        //Rota - /api/livros/editar
        [HttpPatch]
        [Route("editar")]
        public IActionResult Editar(Livro livro)
        {
            //livros.Update(livro);            
            return Ok(livro);
        }

        // DELETE - Método para deletar livros por id
        // Rota - /api/livros/deletar/1
        [HttpDelete]
        [Route("deletar/{id}")]
        public IActionResult Deletar(int id)
        {
            var livro = livros.FirstOrDefault(a => a.Id == id);
            if(livro == null)
            {
                return BadRequest("Livro não encontrado!");
            }
            return Ok(livro);
        }
    }
}