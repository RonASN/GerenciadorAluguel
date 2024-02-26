using GerenciadorAluguel.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciadorAluguel.Database.PostgreSQL.Mappings;

public class AluguelMapping : IEntityTypeConfiguration<Aluguel>
{
    public void Configure(EntityTypeBuilder<Aluguel> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .IsRequired()
            .HasDefaultValueSql("gen_random_uuid()");

        builder.Property(x => x.Inicio)
            .IsRequired();

        builder.Property(x => x.Termino)
            .IsRequired();

        builder.Property(x => x.PrevisaoTermino)
            .IsRequired();

        builder.HasOne(x => x.Usuario)
            .WithOne(y => y.Aluguel)
            .HasForeignKey<Aluguel>("idUsuario")
            .IsRequired(false);
    }
}
