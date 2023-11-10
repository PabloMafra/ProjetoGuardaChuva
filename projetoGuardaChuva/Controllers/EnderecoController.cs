using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using projetoGuardaChuva.Models;
using projetoGuardaChuva.Repositorios.Interfaces;
using Microsoft.AspNetCore.Cors;

namespace projetoGuardaChuva.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        private readonly IEnderecoRepositorio _enderecoRepositorio;

        public EnderecoController(IEnderecoRepositorio enderecoRepositorio)
        {
            _enderecoRepositorio = enderecoRepositorio;
        }

        [HttpPost]
        [Route("cadastro")]
        public async Task<ActionResult<Endereco>> CadastrarEndereco([FromBody] Endereco endereco)
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "*");

            Endereco result = await _enderecoRepositorio.CadastrarEndereco(endereco);

            return Ok(result);
        }

    }
}
