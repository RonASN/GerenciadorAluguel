namespace GerenciadorAluguel.Domain.Models;
public class Pedido
{

    public Guid Id { get; protected set; }
    public DateTime DataCriacao { get; protected set; }
    public double ValorCorrida { get; protected set; }
    public SituacoesEnum Situacao { get; protected set; }
    public Usuario Usuario { get; protected set; }
}
