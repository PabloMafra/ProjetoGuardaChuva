using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using projetoGuardaChuva.Models;
using projetoGuardaChuva.Repositorios.Interfaces;
using Microsoft.AspNetCore.Cors;
using projetoGuardaChuva.Utils;

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

        [HttpGet("calcular-volume")]
        public ActionResult<double> CalcularVolume(double altura, double @base, double anguloInclinacao)
        {
            try
            {
                var volumeCalculator = new VolumeDaMicrobacia(altura, @base, anguloInclinacao);
                var volumeCalculado = volumeCalculator.CalculoVolumeDaMicrobacia();
                var volumeEmLitros = volumeCalculator.ConverteParaLitros(volumeCalculado);

                return Ok(volumeEmLitros.ToString("F2"));
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao calcular o volume: {ex.Message}");
            }
        }

        [HttpGet("buscar/nomeSetor")]
        public async Task<IActionResult> BuscarPorNomeSetor([FromQuery] string nomeSetor)
        {
            var enderecos = await _enderecoRepositorio.BuscarPorNomeSetor(nomeSetor);

            return Ok(enderecos);
        }

        [HttpDelete("deletar")]
        public async Task<IActionResult> DeletarEndereco([FromQuery] int id)
        {
            try
            {
                var sucesso = await _enderecoRepositorio.DeletarEndereco(id);

                if (sucesso)
                {
                    return NoContent();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

        [HttpPut("atualizar")]
        public async Task<IActionResult> AtualizarEndereco([FromBody] Endereco endereco)
        {
            try
            {
                var enderecoAtualizado = await _enderecoRepositorio.EditarDomicilio(endereco);

                if (enderecoAtualizado != false)
                {
                    return Ok(enderecoAtualizado);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }


    }
}
