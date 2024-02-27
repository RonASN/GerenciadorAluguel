namespace GerenciadorAluguel.Domain.Models;

public class Aluguel
{
    public Guid Id { get; protected set; }
    public DateTime Inicio { get; protected set; }
    public DateTime Termino { get; protected set; }
    public DateTime PrevisaoTermino { get; protected set; }
    public Usuario Usuario { get; protected set; }
}
