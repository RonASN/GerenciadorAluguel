namespace GerenciadorAluguel.Domain.Models;

public class Moto
{
    public Guid Id { get; protected set; }
    public int Ano { get; protected set; }
    public string Modelo { get; protected set; }
    public string Placa { get; protected set; }
    public Usuario Usuario {get; protected set; }
}
