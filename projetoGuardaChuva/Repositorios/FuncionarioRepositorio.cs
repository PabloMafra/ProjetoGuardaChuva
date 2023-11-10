using projetoGuardaChuva.Data;
using projetoGuardaChuva.Models;
using projetoGuardaChuva.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace projetoGuardaChuva.Repositorios
{
    public class FuncionarioRepositorio : IFuncionarioRepositorio
    {
        private readonly SistemaDBContext _dbContext;
        public FuncionarioRepositorio(SistemaDBContext sistemaDBContext)
        {
            _dbContext = sistemaDBContext;
        }

        public async Task<List<Funcionario>> BuscarFuncionarios(string nome)
        {
            return await _dbContext.Funcionarios
                .Where(x => x.Nome.Contains(nome))
                .ToListAsync();
        }

        public async Task<List<Funcionario>> ListarFuncionarios()
        {
            return await _dbContext.Funcionarios
                .ToListAsync();
        }

        public async Task<Funcionario> CadastrarFuncionario(Funcionario usuario)
        {
            _dbContext.Funcionarios.Add(usuario);

            await _dbContext.SaveChangesAsync();

            return usuario;
        }

    }
}
