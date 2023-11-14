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
    public class SetorController : ControllerBase
    {
        private readonly ISetorRepositorio _setorRepositorio;

        public SetorController(ISetorRepositorio setorRepositorio)
        {
            _setorRepositorio = setorRepositorio;
        }

        [HttpPost]
        [Route("cadastro")]
        public async Task<ActionResult<Setor>> CadastrarUsuario([FromBody] Setor nomeSetor)
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "*");

            Setor setor = await _setorRepositorio.CadastrarSetor(nomeSetor);

            return Ok(setor);
        }

        [HttpGet]
        [Route("listar")]
        public async Task<ActionResult<List<Setor>>> ListarSetores([FromQuery] string? nomeSetor)
        {
            List<Setor> setor = await _setorRepositorio.ListarSetores(nomeSetor);

            return Ok(setor);
        }

        [HttpPut("atualizar")]
        public async Task<IActionResult> AtualizarSetor([FromBody] Setor setor)
        {
            try
            {
                var setorAtualizado = await _setorRepositorio.EditarSetor(setor);

                if (setorAtualizado != false)
                {
                    return Ok(setorAtualizado);
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

        [HttpDelete("deletar")]
        public async Task<IActionResult> DeletarSetor([FromQuery] int id)
        {
            try
            {
                var sucesso = await _setorRepositorio.DeletarSetor(id);

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
    }
}
