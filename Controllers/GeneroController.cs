using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebAPI_biblioteca.Models;

namespace WebAPI_biblioteca.Controllers
{
    [ApiController]
    [Route("genero")]
    public class FuncionarioController : ControllerBase
    {
        public static List<Genero> generos = new List<Genero>();
        // GET: /genero/listar
        [Route("listar")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(generos);
        }

        // POST: /genero/cadastrar
        [Route("cadastrar")]
        [HttpPost]
        public IActionResult Cadastrar([FromBody] Genero genero)
        {
            generos.Add(genero);
            return Created("", new { msg = "", genero} );
            //return Ok("Deu certo");
        }

        // GET: /genero/buscar/{genero}
        [HttpGet]
        [Route("buscar/{genero}")]
        public IActionResult Buscar()
        {
            return null;
        }

        // DELETE: /genero/deletar/{genero}
        [HttpDelete]
        [Route("deletar/{genero}")]
        public IActionResult Deletar()
        {
            return null;
        }
    }
}