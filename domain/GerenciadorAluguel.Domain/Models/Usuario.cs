namespace GerenciadorAluguel.Domain.Models;

public class Usuario
{
    public Usuario(string nome, string senha, string email, UserRole role)
    {
        Nome = nome;
        Senha = senha;
        Email = email;
        Role = role;
    }

    public Guid Id { get; protected set; }
    public string Nome { get; protected set; }
    public string Senha { get; protected set; }
    public string Email { get; protected set; }
    public UserRole Role { get; protected set; }
    public Entregador? DadosEntregador { get; protected set; }
    public Moto? Moto { get; protected set; }
    public Aluguel? Aluguel { get; protected set; }
    public IEnumerable<Pedido>? Pedidos { get; protected set; }

    public Usuario(){}
}
