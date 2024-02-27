using GerenciadorAluguel.Database.PostgreSQL.Mappings;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorAluguel.Database.PostgreSQL;

public class GerenciadorAluguelDbContext : DbContext
{
    public GerenciadorAluguelDbContext(DbContextOptions<GerenciadorAluguelDbContext> options) : base(options)
    {
    }

    public Task FirstOrDefault()
    {
        throw new NotImplementedException();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UsuarioMapping).Assembly);
    }
}
