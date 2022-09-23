using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebAPI_biblioteca.Controllers
{
    [ApiController]
    [Route("api/cliente")]
    public class ClienteController : ControllerBase
    {

        //GET: /api/cliente/listar
        [HttpGet]
        [Route("listar")]
        public IActionResult Listar()
        {

            return Ok(_context.Cliente.ToList());
        }

        // POST: /api/funcionario/cadastrar
        [HttpPost]
        [Route("cadastrar")]
        public IActionResult Cadastrar([FromBody] )
        {

        }

        //GET: /api/cliente/buscar/{codCliente}
        [HttpGet]
        [Route("buscar/{codCliente}")]
        public IActionResult Buscar([FromRoute] )
        {

        }

        //Delete: /api/cliente/deletar/{cpf}
        [HttpDelete]
        [Route("deletar/{codCliente}")]
        public IActionResult Deletar([FromRoute])
        {

        }

        //Patch: /api/cliente/editar
        [HttpPatch]
        [Route("editar")]
        public IActionResult Editar([FromBody] )
        {


        }
    }
}
