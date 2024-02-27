using GerenciadorAluguel.Application.ServicesInterfaces;
using GerenciadorAluguel.Database.PostgreSQL;
using GerenciadorAluguel.Domain.Models;
using GerenciadorAluguel.Domain.Models.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace GerenciadorAluguel.Application.Services;

public class MotoService : IMotoService
{
    private readonly GerenciadorAluguelDbContext _context;
    private readonly ILogger<MotoService> _logger;

    public MotoService(GerenciadorAluguelDbContext context, ILogger<MotoService> logger)
    {
        _context = context;
        _logger = logger;
    }


    public async Task AdicionarMoto(MotoDto dto, Guid idUsuario)
    {
        var usuario = _context.Set<Usuario>().FirstOrDefault(x => x.Id == idUsuario);
        if (usuario.Role != UserRole.Admin)
        {
            var mensagem = "Acesso negado. Somente administradores podem acessar este recurso.";
            _logger.LogWarning($"Usuário '{usuario.Nome}' não tem permissão de administrador.");
            throw new Exception(mensagem);
        }
        var moto = new Moto(dto.Ano, dto.Modelo, dto.Placa, usuario!);
        _context.Set<Moto>().Add(moto);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<MotoDto>> BuscarMoto(string? placa)
    {
        IEnumerable<Moto> motos = _context.Set<Moto>();

        if (!string.IsNullOrEmpty(placa))
        {
            motos = motos.Where(x => x.Placa == placa);
        }

        return motos.Select(x => new MotoDto
        {
            Ano = x.Ano,
            Modelo = x.Modelo,
            Placa = x.Placa,
        });
    }

    public async Task<MotoDto> EditarMoto(Guid idUsuario, Guid idMoto, string? placa)
    {
        var usuario = _context.Set<Usuario>().FirstOrDefault(x => x.Id == idUsuario);
        if (usuario.Role != UserRole.Admin)
        {
            var mensagem = "Acesso negado. Somente administradores podem editar dados das motos.";
            _logger.LogWarning($"Usuário '{usuario.Nome}' não tem permissão de administrador.");
            throw new Exception(mensagem);
        }

        var moto = _context.Set<Moto>().FirstOrDefault(x => x.Id == idMoto);

        moto.AlterarPlaca(placa);

        _context.Update(moto);
        await _context.SaveChangesAsync();

        return new MotoDto
        {
            Ano = moto.Ano,
            Modelo = moto.Modelo,
            Placa = moto.Placa,
        };
    }

    public async Task ApagarMoto(Guid idUsuario, Guid idMoto)
    {
        var usuario = _context.Set<Usuario>().FirstOrDefault(x => x.Id == idUsuario);
        if (usuario.Role != UserRole.Admin)
        {
            var mensagem = "Acesso negado. Somente administradores podem editar dados das motos.";
            _logger.LogWarning($"Usuário '{usuario.Nome}' não tem permissão de administrador.");
            throw new Exception(mensagem);
        }

        var moto = _context.Set<Moto>().FirstOrDefault(x => x.Id == idMoto);

        _context.Remove(moto);
        await _context.SaveChangesAsync();
    }

}
