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

        public async Task<List<Setor>> ListarSetores(string? nomeSetor)
        {
            if (nomeSetor != null && !string.IsNullOrEmpty(nomeSetor))
            {
                return await _dbContext.Setor
                    .Where(s => s.Nome.Contains(nomeSetor))
                    .ToListAsync();
            }
            else
            {
                return await _dbContext.Setor.ToListAsync();
            }
        }
        public async Task<bool> EditarSetor(Setor setor)
        {
            try
            {
                var setorAtualizado = await _dbContext.Setor
                    .Where(e => e.Id == setor.Id)
                    .FirstOrDefaultAsync();

                if (setorAtualizado != null)
                {
                    setorAtualizado.Id = setor.Id;
                    setorAtualizado.Nome = setor.Nome;

                    await _dbContext.SaveChangesAsync();
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao atualizar o setor: {ex.Message}");
                throw;
            }
        }
        public async Task<bool> DeletarSetor(int id)
        {
            var setor = await _dbContext.Setor
                .Where(e => e.Id == id)
                .FirstOrDefaultAsync();

            if (setor == null)
            {
                return false;
            }

            _dbContext.Setor.Remove(setor);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
