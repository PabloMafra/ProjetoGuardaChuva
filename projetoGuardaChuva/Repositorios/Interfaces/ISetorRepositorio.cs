using projetoGuardaChuva.Models;

namespace projetoGuardaChuva.Repositorios.Interfaces
{
    public interface ISetorRepositorio
    {
        Task<Setor> CadastrarSetor(Setor nomeSetor);
        Task<List<Setor>> ListarSetores(string? nomesetor);
        Task<bool> EditarSetor(Setor setor);
        Task<bool> DeletarSetor(int id);
    }
}
