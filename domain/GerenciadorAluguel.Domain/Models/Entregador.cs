namespace GerenciadorAluguel.Domain.Models;

public class Entregador
{
    public Entregador(string cnpj, string dataNascimento, CategoriasCnhEnum categoriaCnh, string numeroCnh, string imagemCnh, Usuario usuario)
    {
        Cnpj = cnpj;
        DataNascimento = dataNascimento;
        CategoriaCnh = categoriaCnh;
        NumeroCnh = numeroCnh;
        ImagemCnh = imagemCnh;
        Usuario = usuario;
    }

    public Guid Id { get; protected set; }
    public string Cnpj { get; protected set; }
    public string DataNascimento { get; protected set; }
    public CategoriasCnhEnum CategoriaCnh { get; protected set; }
    public string NumeroCnh { get; protected set; }
    public string ImagemCnh { get; protected set; }
    public Usuario Usuario { get; protected set; }

    public Entregador()
    {
    }
}
