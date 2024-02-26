using GerenciadorAluguel.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorAluguel.Database.PostgreSQL.Mappings;

public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .IsRequired()
            .HasDefaultValueSql("gen_random_uuid()");

        builder.Property(x => x.Nome)
                .IsRequired();

        builder.Property(x => x.Senha)
            .IsRequired();

        builder.Property(x => x.Email)
            .IsRequired();

        builder.HasOne(x => x.DadosEntregador)
                .WithOne(y => y.Usuario)
                .HasForeignKey<Entregador>("idUsuario")
                .IsRequired(false);

        builder.HasOne(x => x.Moto)
                .WithOne(y => y.Usuario)
                .HasForeignKey<Moto>("idUsuario")
                .IsRequired(false);

        builder.HasOne(x => x.Aluguel)
                .WithOne(y => y.Usuario)
                .HasForeignKey<Aluguel>("idUsuario")
                .IsRequired(false);

        builder.HasMany(x => x.Pedidos)
                .WithOne(y => y.Usuario)
                .IsRequired(false);

    }
}
