using GerenciadorAluguel.Application.ServicesInterfaces;
using GerenciadorAluguel.Database.PostgreSQL;
using GerenciadorAluguel.Domain.Models;
using GerenciadorAluguel.Domain.Models.Dtos;
using Microsoft.Extensions.Logging;

namespace GerenciadorAluguel.Application.Services;

public class EntregadorService : IEntregadorService
{
    private readonly GerenciadorAluguelDbContext _context;
    private readonly ILogger<EntregadorService> _logger;

    public EntregadorService(GerenciadorAluguelDbContext context, ILogger<EntregadorService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task CadastrarEntregador(Guid idUsuario,EntregadorDto entregadorDto)
    {
        var usuario = _context.Set<Usuario>().FirstOrDefault(x => x.Id == idUsuario);

        var entregador = new Entregador(
            entregadorDto.Cnpj,entregadorDto.DataNascimento,entregadorDto.CategoriaCnh,entregadorDto.NumeroCnh,entregadorDto.ImagemCnh,usuario);

        _context.Set<Entregador>().Add(entregador);
        await _context.SaveChangesAsync();
    }
}
