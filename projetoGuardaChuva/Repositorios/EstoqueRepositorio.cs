using projetoGuardaChuva.Data;
using projetoGuardaChuva.Models;
using projetoGuardaChuva.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace projetoGuardaChuva.Repositorios
{
    public class EstoqueRepositorio : IEstoqueRepositorio
    {
        private readonly SistemaDBContext _dbContext;
        public EstoqueRepositorio(SistemaDBContext sistemaDBContext)
        {
            _dbContext = sistemaDBContext;
        }

        public async Task<Estoque> CadastrarEstoque(Estoque litragem)
        {
            _dbContext.Estoque.Add(litragem);

            await _dbContext.SaveChangesAsync();

            return litragem;
        }

    }
}
