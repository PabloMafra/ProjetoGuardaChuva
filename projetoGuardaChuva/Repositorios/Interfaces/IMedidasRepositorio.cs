using projetoGuardaChuva.Models;

namespace projetoGuardaChuva.Repositorios.Interfaces
{
    public interface IMedidasRepositorio
    {
        Task<Setor> CadastroMedidas(Setor nomeSetor);
    }
}
