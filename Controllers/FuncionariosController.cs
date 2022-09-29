using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebAPI_biblioteca.Controllers
{
    [ApiController]
    [Route("api/funcionarios")]
    public class FuncioariosController : ControllerBase
    {


        //GET: /api/funcionario/listar
        [HttpGet]
        [Route("listar")]
        public IActionResult Listar()
        {

        }

        // POST: /api/funcionario/cadastrar
        [HttpPost]
        [Route("cadastrar")]
        public IActionResult Cadastrar([FromBody] Funcionario funcionario)
        {


        }

        //GET: /api/funcionario/buscar/{cpf}
        [HttpGet]
        [Route("buscar/{codFuncionario}")]
        public IActionResult Buscar([FromRoute] )
        {

        }

        //Delete: /api/funcionario/deletar/{cpf}
        [HttpDelete]
        [Route("deletar/{codFuncionario}")]
        public IActionResult Deletar([FromRoute])
        {

        }


        //Patch: /api/funcionario/editar
        [HttpPatch]
        [Route("editar")]
        public IActionResult Editar([FromBody] )
        {


        }
    }
}
