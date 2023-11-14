using projetoGuardaChuva.Data;
using projetoGuardaChuva.Models;
using projetoGuardaChuva.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace projetoGuardaChuva.Repositorios
{
    public class EnderecoRepositorio : IEnderecoRepositorio
    {
        private readonly SistemaDBContext _dbContext;
        public EnderecoRepositorio(SistemaDBContext sistemaDBContext)
        {
            _dbContext = sistemaDBContext;
        }

        public async Task<Endereco> CadastrarEndereco(Endereco endereco)
        {
            _dbContext.Endereco.Add(endereco);

            await _dbContext.SaveChangesAsync();

            return endereco;
        }

        public async Task<List<Endereco>> Buscar(string? rua, string? setor, string? bairro, string? cidade)
        {
            IQueryable<Endereco> consulta = _dbContext.Endereco;

            if (!string.IsNullOrWhiteSpace(rua))
                consulta = consulta.Where(endereco => endereco.Rua.Contains(rua));

            if (!string.IsNullOrWhiteSpace(bairro))
                consulta = consulta.Where(endereco => endereco.Bairro == bairro);

            if (!string.IsNullOrWhiteSpace(cidade))
                consulta = consulta.Where(endereco => endereco.Cidade == cidade);

            return await consulta.ToListAsync();
        }

        public async Task<List<EnderecoOutput>> BuscarPorNomeSetor(string nome)
        {
            if (string.IsNullOrEmpty(nome))
            {
                return await _dbContext.Endereco
                    .Select(endereco => new EnderecoOutput
                    {
                        Id = endereco.Id,
                        Cep = endereco.Cep,
                        Rua = endereco.Rua,
                        Bairro = endereco.Bairro,
                        Numero = endereco.Numero,
                        Estado = endereco.Estado,
                        Cidade = endereco.Cidade,
                        IdSetor = endereco.IdSetor,
                        Coordenadas = endereco.Coordenadas,
                        VolumeBacia = endereco.VolumeBacia,
                    })
                    .ToListAsync();
            }

            var resultado = await _dbContext.Setor
                .Where(setor => setor.Nome.Contains(nome))
                .Select(setor => new { setor.Id, setor.Nome })
                .FirstOrDefaultAsync();

            if (resultado != null)
            {
                var idSetor = resultado.Id;
                var nomeSetor = resultado.Nome;

                return await _dbContext.Endereco
                    .Where(endereco => endereco.IdSetor == idSetor)
                    .Select(endereco => new EnderecoOutput
                    {
                        Id = endereco.Id,
                        Cep = endereco.Cep,
                        Rua = endereco.Rua,
                        Bairro = endereco.Bairro,
                        Numero = endereco.Numero,
                        Estado = endereco.Estado,
                        Cidade = endereco.Cidade,
                        IdSetor = endereco.IdSetor,
                        NomeSetor = nomeSetor,
                        Coordenadas = endereco.Coordenadas,
                        VolumeBacia = endereco.VolumeBacia,
                    })
                    .ToListAsync();
            }

            return new List<EnderecoOutput>();
        }

        public async Task<bool> DeletarEndereco(int id)
        {
            var endereco = await _dbContext.Endereco
                .Where(e => e.Id == id)
                .FirstOrDefaultAsync();

            if (endereco == null)
            {
                return false;
            }

            _dbContext.Endereco.Remove(endereco);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> EditarDomicilio(Endereco endereco)
        {
            try
            {
                var enderecoAtualizado = await _dbContext.Endereco
                    .Where(e => e.Id == endereco.Id)
                    .FirstOrDefaultAsync();

                if (enderecoAtualizado != null)
                {
                    enderecoAtualizado.IdSetor = endereco.IdSetor;
                    enderecoAtualizado.Rua = endereco.Rua;
                    enderecoAtualizado.Coordenadas = endereco.Coordenadas;

                    await _dbContext.SaveChangesAsync();
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao atualizar o endereço: {ex.Message}");
                throw;
            }
        }
    }
}
