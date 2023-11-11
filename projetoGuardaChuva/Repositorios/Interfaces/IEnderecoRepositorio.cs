using Microsoft.AspNetCore.Mvc;
using projetoGuardaChuva.Models;

namespace projetoGuardaChuva.Repositorios.Interfaces
{
    public interface IEnderecoRepositorio
    {
        Task<Endereco> CadastrarEndereco(Endereco endereco);
        Task<List<EnderecoOutput>> BuscarPorNomeSetor(string nomeSetor);
    }
}
