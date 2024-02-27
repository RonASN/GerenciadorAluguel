namespace GerenciadorAluguel.Domain.Models.Dtos;

public class UsuarioDto
{
    public string Nome { get; set; }
    public string Senha { get; set; }
    public string Email { get; set; }
    public UserRole Role { get; set; }
}
