using projetoGuardaChuva.Models;

namespace projetoGuardaChuva.Repositorios.Interfaces
{
    public interface IEnderecoRepositorio
    {
        Task<Endereco> CadastrarEndereco(Endereco endereco);
    }
}
