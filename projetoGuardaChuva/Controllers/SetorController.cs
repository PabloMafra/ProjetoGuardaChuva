using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using projetoGuardaChuva.Models;
using projetoGuardaChuva.Repositorios.Interfaces;
using Microsoft.AspNetCore.Cors;

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
            Setor setor = await _setorRepositorio.CadastrarSetor(nomeSetor);

            return Ok(setor);
        }
    }
}
