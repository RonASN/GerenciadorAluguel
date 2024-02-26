using GerenciadorAluguel.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciadorAluguel.Database.PostgreSQL.Mappings;

public class PedidoMapping : IEntityTypeConfiguration<Pedido>
{
    public void Configure(EntityTypeBuilder<Pedido> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .IsRequired()
            .HasDefaultValueSql("gen_random_uuid()");

        builder.Property(x => x.DataCriacao)
            .IsRequired();

        builder.Property(x => x.ValorCorrida)
            .IsRequired();

        builder.Property(x => x.Situacao)
            .IsRequired();

        builder.HasOne(x => x.Usuario)
            .WithMany(y => y.Pedidos)
            .HasForeignKey("idUsuario")
            .IsRequired();
    }
}
