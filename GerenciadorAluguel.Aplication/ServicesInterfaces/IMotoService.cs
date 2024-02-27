using GerenciadorAluguel.Domain.Models;
using GerenciadorAluguel.Domain.Models.Dtos;

namespace GerenciadorAluguel.Application.ServicesInterfaces;

public interface IMotoService
{
    Task AdicionarMoto(MotoDto dto, Guid idUsuario);
    Task<IEnumerable<MotoDto>> BuscarMoto(string? placa);
    Task<MotoDto> EditarMoto(Guid idUsuario, Guid idMoto, string? placa);
    Task ApagarMoto(Guid idUsuario, Guid idMoto);
}
