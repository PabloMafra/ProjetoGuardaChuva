using projetoGuardaChuva.Data.Map;
using projetoGuardaChuva.Models;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.EntityFrameworkCore;

namespace projetoGuardaChuva.Data
{
    public class SistemaDBContext : DbContext
    {
        public SistemaDBContext(DbContextOptions<SistemaDBContext> options)
            : base(options)
        {
        }

        public DbSet<Setor> Setor { get; set; }
        public DbSet<Estoque> Estoque { get; set; }
        public DbSet<Endereco> Endereco { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SetorMap());
            modelBuilder.ApplyConfiguration(new EstoqueMap());
            modelBuilder.ApplyConfiguration(new EnderecoMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
