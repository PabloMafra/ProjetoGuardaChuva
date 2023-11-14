using projetoGuardaChuva.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace projetoGuardaChuva.Data.Map
{
    public class EnderecoMap : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Cep).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Rua).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Bairro).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Numero).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Estado).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Cidade).IsRequired().HasMaxLength(255);
            builder.Property(x => x.IdSetor).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Coordenadas).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Altura).IsRequired();
            builder.Property(x => x.Base).IsRequired();
            builder.Property(x => x.AnguloInclinacao).IsRequired();
            builder.Property(x => x.VolumeBacia).IsRequired();

            builder.Property(x => x.Id).UseIdentityColumn();
        }
    }
}
