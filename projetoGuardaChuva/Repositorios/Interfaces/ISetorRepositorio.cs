using projetoGuardaChuva.Models;

namespace projetoGuardaChuva.Repositorios.Interfaces
{
    public interface ISetorRepositorio
    {
        Task<Setor> CadastrarSetor(Setor nomeSetor);
        Task<List<Setor>> ListarSetores();
    }
}
