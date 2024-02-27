namespace GerenciadorAluguel.Domain.Models;

public class Moto
{
    public Moto(int ano, string modelo, string placa)
    {
        Ano = ano;
        Modelo = modelo;
        Placa = placa;
    }

    public Guid Id { get; protected set; }
    public int Ano { get; protected set; }
    public string Modelo { get; protected set; }
    public string Placa { get; protected set; }
    public Usuario Usuario {get; protected set; }

    public void AlterarPlaca(string placa)
    {
        Placa = placa;
    }

    public Moto() { }
}
