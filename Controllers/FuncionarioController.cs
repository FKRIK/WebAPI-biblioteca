using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebAPI_biblioteca.Controllers
{
    // [ApiController]
    // [Route("api/funcionario")]
    // public class FuncioarioController : ControllerBase
    // {
    //     private readonly DataContext _context;

    //     public FuncionarioController(DataContext context) => _context = context;

    //     //GET: /api/funcionario/listar
    //     [HttpGet]
    //     [Route("listar")]
    //     public IActionResult Listar()
    //     {

    //         return Ok(_context.Funcionarios.ToList());
    //     }

    //     // POST: /api/funcionario/cadastrar
    //     [HttpPost]
    //     [Route("cadastrar")]
    //     public IActionResult Cadastrar([FromBody] Funcionario funcionario)
    //     {

    //         //contexto.propriedade/classe.metodo
    //         _context.Funcionarios.Add(funcionario);

    //         //sempre que tiver um crud - menos listar, deve ter a operação de savechanges
    //         _context.SaveChanges();

    //         // funcionarios.Add(funcionario);
    //         return Created("", funcionario);
    //     }

    //     //GET: /api/funcionario/buscar/{cpf}
    //     [HttpGet]
    //     [Route("buscar/{codFuncionario}")]
    //     public IActionResult Buscar([FromRoute] string codFuncionario)
    //     {
    //         Funcionario funcionario = _context.Funcionarios.FirstOrDefault(funcionarioCadastrado => funcionarioCadastrado.CodFuncionario.Equals(codFuncionario));

    //         return funcionario != null ? Ok(funcionario) : NotFound();
    //     }

    //     //Delete: /api/funcionario/deletar/{cpf}
    //     [HttpDelete]
    //     [Route("deletar/{codFuncionario}")]
    //     public IActionResult Deletar([FromRoute] string codFuncionario)
    //     {
    //         foreach (Funcionario funcionarioCadastrado in funcionarios)
    //         {
    //             string nomeFuncionario = funcionarioCadastrado.Nome;

    //             funcionarios.Remove(funcionarioCadastrado);
    //             return Ok($"Funcionario {nomeFuncionario} deletado com sucesso!");
    //         }
    //         return NotFound();
    //     }


    //     //Patch: /api/funcionario/editar
    //     [HttpPatch]
    //     [Route("editar")]
    //     public IActionResult Editar([FromBody] Funcionario funcionario)
    //     {

    //         Funcionario funcionarioBuscado = funcionarios.FirstOrDefault(funcionarioBuscado => funcionarioBuscado.CodFuncionario.Equals(funcionario.CodFuncionario));

    //         if (funcionarioBuscado != null)
    //         {
    //             funcionarioBuscado.Nome = funcionario.Nome;
    //             return Ok(funcionario);
    //         }
    //         return NotFound();
    //     }
    // }
}
