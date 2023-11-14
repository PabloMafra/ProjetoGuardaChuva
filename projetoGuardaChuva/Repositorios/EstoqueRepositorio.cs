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

        public async Task<bool> DeletarEstoque(int id)
        {
            var estoque = await _dbContext.Estoque
                .Where(e => e.Id == id)
                .FirstOrDefaultAsync();

            if (estoque == null)
            {
                return false;
            }

            _dbContext.Estoque.Remove(estoque);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> EditarEstoque(Estoque estoque)
        {
            try
            {
                var estoqueAtualizado = await _dbContext.Estoque
                    .Where(e => e.Id == estoque.Id)
                    .FirstOrDefaultAsync();

                if (estoqueAtualizado != null)
                {
                    estoqueAtualizado.Id = estoque.Id;
                    estoqueAtualizado.Litragem = estoque.Litragem;

                    await _dbContext.SaveChangesAsync();
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao atualizar o estoque: {ex.Message}");
                throw;
            }
        }

    }
}
