using projetoGuardaChuva.Data;
using projetoGuardaChuva.Models;
using projetoGuardaChuva.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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

        public async Task<List<Estoque>> ListarEstoque(double estoque)
        {
            if (estoque != null )
            {
                return await _dbContext.Estoque
                    .Where(s => s.Litragem == estoque)
                    .ToListAsync();
            }
            else
            {
                return await _dbContext.Estoque.ToListAsync();
            }
        }

    }
}
