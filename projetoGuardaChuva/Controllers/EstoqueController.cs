using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using projetoGuardaChuva.Models;
using projetoGuardaChuva.Repositorios.Interfaces;
using Microsoft.AspNetCore.Cors;
using projetoGuardaChuva.Repositorios;

namespace projetoGuardaChuva.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstoqueController : ControllerBase
    {
        private readonly IEstoqueRepositorio _estoqueRepositorio;

        public EstoqueController(IEstoqueRepositorio estoqueRepositorio)
        {
            _estoqueRepositorio = estoqueRepositorio;
        }

        [HttpPost]
        [Route("cadastro")]
        public async Task<ActionResult<Estoque>> CadastrarEstoque([FromBody] Estoque litragem)
        {
            Estoque estoque = await _estoqueRepositorio.CadastrarEstoque(litragem);

            return Ok(estoque);
        }

        [HttpGet]
        [Route("listar")]
        public async Task<ActionResult<List<Estoque>>> ListarEstoque([FromQuery] double litragem)
        {
            List<Estoque> estoque = await _estoqueRepositorio.ListarEstoque(litragem);

            return Ok(estoque);
        }

        [HttpDelete("deletar")]
        public async Task<IActionResult> DeletarEstoque([FromQuery] int id)
        {
            try
            {
                var sucesso = await _estoqueRepositorio.DeletarEstoque(id);

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
        public async Task<IActionResult> AtualizarEstoque([FromBody] Estoque estoque)
        {
            try
            {
                var estoqueAtualizado = await _estoqueRepositorio.EditarEstoque(estoque);

                if (estoqueAtualizado != false)
                {
                    return Ok(estoqueAtualizado);
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
