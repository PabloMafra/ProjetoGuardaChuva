using projetoGuardaChuva.Models;

namespace projetoGuardaChuva.Repositorios.Interfaces
{
    public interface IFuncionarioRepositorio
    {
        Task<List<Funcionario>> BuscarFuncionarios(string nome);
        Task<List<Funcionario>> ListarFuncionarios();
        Task<Funcionario> CadastrarFuncionario(Funcionario nome);
    }
}
