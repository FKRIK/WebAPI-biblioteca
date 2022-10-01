using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebAPI_biblioteca.Models;

namespace WebAPI_biblioteca
{
    [ApiController]
    [Route("api/generos")]
    public class GenerosController : ControllerBase
    {
        private List<Genero> generos = new List<Genero>()
        {
            new Genero()
            {
                Id = 1,
                GeneroLivro = "Aventura"
            },
            new Genero()
            {
                Id = 2,
                GeneroLivro = "Terror"
            },
            new Genero()
            {
                Id = 3,
                GeneroLivro = "Romance"
            }
        }; 
        private readonly DataContext _context;

        // GET - Método para listar todos os generos
        // Rota - /api/generos
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(generos);
        }


        // GET - Método para listar generos por id
        // Rota - /api/generos/listar/byid?id=1       (Utilização de QueryString)
        [HttpGet()]
        [Route("listar/byId")]
        public IActionResult ListarById(int id)
        {
            var genero = generos.FirstOrDefault(g => g.Id == id);
            if( genero == null)
            {
                return BadRequest("Gênero não encontrado!");
            }
            return Ok(genero);
        }


        // GET - Método para listar generos por nome
        // Rota - /api/generos/listar/byname?nome=Aventura   (Utilização de QueryString)
        // Fazer - não diferenciacao de maiusculas ou minusculas
        [HttpGet("listar/byName")]
        public IActionResult ListarByName(string nome)
        {
            var genero = generos.FirstOrDefault(g => g.GeneroLivro.Contains(nome));
            if( genero == null)
            {
                return BadRequest("Gênero não encontrado!");
            }
            return Ok(genero);
        }


        // POST - Método para cadastrar um genero    (JSON)
        // Rota - /api/generos/cadastrar
        [HttpPost]
        [Route("cadastrar")]
        public IActionResult Cadastrar(Genero genero)
        {
            generos.Add(genero);
            return Created("", genero);
        }


        //PATCH - Método para editar parcialmente um registro
        //Rota - /api/generos/editar
        [HttpPatch]
        [Route("editar")]
        public IActionResult Editar(Genero genero)
        {
            //livros.Update(livro);            
            return Ok(genero);
        }

        // DELETE - Método para deletar um genero por id
        // Rota - /api/generos/deletar/1
        [HttpDelete]
        [Route("deletar/{id}")]
        public IActionResult Deletar(int id)
        {
            var genero = generos.FirstOrDefault(g => g.Id == id);
            if(genero == null)
            {
                return BadRequest("Gênero não encontrado!");
            }
            return Ok(genero);
        }
    }
}