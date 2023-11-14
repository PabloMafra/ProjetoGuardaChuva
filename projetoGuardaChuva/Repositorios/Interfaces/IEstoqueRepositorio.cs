using projetoGuardaChuva.Models;

namespace projetoGuardaChuva.Repositorios.Interfaces
{
    public interface IEstoqueRepositorio
    {
        Task<Estoque> CadastrarEstoque(Estoque litragem);

        Task<List<Estoque>> ListarEstoque(double litragem);
    }
}

