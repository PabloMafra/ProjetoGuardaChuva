using projetoGuardaChuva.Data;
using projetoGuardaChuva.Models;
using projetoGuardaChuva.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace projetoGuardaChuva.Repositorios
{
    public class SetorRepositorio : ISetorRepositorio
    {
        private readonly SistemaDBContext _dbContext;
        public SetorRepositorio(SistemaDBContext sistemaDBContext)
        {
            _dbContext = sistemaDBContext;
        }

        public async Task<Setor> CadastrarSetor(Setor nomeSetor)
        {
            _dbContext.Setor.Add(nomeSetor);

            await _dbContext.SaveChangesAsync();

            return nomeSetor;
        }

        public async Task<List<Setor>> ListarSetores()
        {
            return await _dbContext.Setor
                .ToListAsync();
        }
    }
}
