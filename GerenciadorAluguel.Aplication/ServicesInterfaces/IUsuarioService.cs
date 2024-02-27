using GerenciadorAluguel.Domain.Models;

namespace GerenciadorAluguel.Application.ServicesInterfaces;

public interface IUsuarioService
{
    Task AdicionarUsuario(Usuario usuario);
}
