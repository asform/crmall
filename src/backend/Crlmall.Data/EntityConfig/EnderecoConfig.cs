using Crmall.Domain.Entitities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Crlmall.Data.EntityConfig
{
    public class EnderecoConfig : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("Enderecos");

            builder.HasKey(e => e.Id).HasName("Pk_Enderecos");

            builder.Property(e => e.Id).IsRequired();
            builder.Property(e => e.Cep).HasMaxLength(9);
            builder.Property(e => e.Logradouro).HasMaxLength(300);
            builder.Property(e => e.Numero);
            builder.Property(e => e.Complemento).HasMaxLength(50);
            builder.Property(e => e.Bairro).HasMaxLength(250);
            builder.Property(e => e.Estado).HasMaxLength(2);
            builder.Property(e => e.Cidade).HasMaxLength(250);

            builder.HasOne(e => e.Cliente)
                    .WithOne(c => c.Endereco)
                    .HasForeignKey<Cliente>(c => c.EnderecoId);
        }
    }
}
