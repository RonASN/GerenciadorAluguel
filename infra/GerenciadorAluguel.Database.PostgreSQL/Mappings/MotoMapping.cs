using GerenciadorAluguel.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciadorAluguel.Database.PostgreSQL.Mappings;

public class MotoMapping : IEntityTypeConfiguration<Moto>
{
    public void Configure(EntityTypeBuilder<Moto> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .IsRequired()
            .HasDefaultValueSql("gen_random_uuid()");

        builder.Property(x => x.Ano)
            .IsRequired();

        builder.Property(x => x.Modelo)
            .IsRequired();

        builder.Property(x => x.Placa)
            .IsRequired();

        builder.HasIndex(x => x.Placa)  
            .IsUnique();

        builder.HasOne(x => x.Usuario)
            .WithMany(y => y.Moto)
            .HasForeignKey("idUsuario")
            .IsRequired();
    }
}
