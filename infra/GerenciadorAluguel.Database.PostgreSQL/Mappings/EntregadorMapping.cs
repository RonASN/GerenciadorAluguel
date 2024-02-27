using GerenciadorAluguel.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorAluguel.Database.PostgreSQL.Mappings;

public class EntregadorMapping : IEntityTypeConfiguration<Entregador>
{
    public void Configure(EntityTypeBuilder<Entregador> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(e => e.Id)
            .ValueGeneratedOnAdd()
            .IsRequired()
            .HasDefaultValueSql("gen_random_uuid()");

        builder.Property(x => x.Cnpj)
            .HasMaxLength(14)
            .IsRequired();

        builder.HasIndex(x => x.Cnpj)
            .IsUnique();

        builder.Property(x => x.DataNascimento)
            .IsRequired();

        builder.Property(x => x.CategoriaCnh)
            .IsRequired();

        builder.Property(x => x.NumeroCnh)
            .HasMaxLength(9)
            .IsRequired();

        builder.HasIndex(x => x.NumeroCnh)
            .IsUnique();

        builder.Property(x => x.ImagemCnh)
            .IsRequired();

        builder.HasOne(x => x.Usuario)
            .WithOne(y => y.DadosEntregador)
            .HasForeignKey<Entregador>("idUsuario")
            .IsRequired(false);
    }
}
