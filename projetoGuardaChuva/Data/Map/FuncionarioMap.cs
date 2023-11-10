using projetoGuardaChuva.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace projetoGuardaChuva.Data.Map
{
    public class FuncionarioMap : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Idade).HasColumnName("Idade");
            builder.Property(x => x.Cargo).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Genero).HasColumnName("Genero");
        }
    }
}
