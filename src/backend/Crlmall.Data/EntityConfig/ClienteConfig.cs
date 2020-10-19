using Crmall.Domain.Entitities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Crlmall.Data.EntityConfig
{
    public class ClienteConfig : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Clientes");

            builder.HasKey(c => c.Id).HasName("Pk_Clientes");

            builder.Property(e => e.Id).IsRequired();
            builder.Property(c => c.Nome).HasMaxLength(250).IsRequired();
            builder.Property(c => c.DataNascimento).IsRequired();
            builder.Property(c => c.Sexo).HasMaxLength(10).IsRequired();
        }
    }
}
