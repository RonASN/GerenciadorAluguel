using GerenciadorAluguel.Application.ServicesInterfaces;
using GerenciadorAluguel.Database.PostgreSQL;
using GerenciadorAluguel.Domain.Models;

namespace GerenciadorAluguel.Application.Services;

public class UsuarioService : IUsuarioService
{
    private readonly GerenciadorAluguelDbContext _context;

    public UsuarioService(GerenciadorAluguelDbContext context)
    {
        _context = context;
    }

    public async Task AdicionarUsuario(Usuario usuario)
    {
        _context.Set<Usuario>().Add(usuario);
        await _context.SaveChangesAsync();
    }

}
