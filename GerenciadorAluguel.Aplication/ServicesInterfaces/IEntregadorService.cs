using GerenciadorAluguel.Domain.Models.Dtos;

namespace GerenciadorAluguel.Application.ServicesInterfaces;

public interface IEntregadorService
{
    Task CadastrarEntregador(Guid idUsuario, EntregadorDto entregadorDto);
}
