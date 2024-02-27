namespace GerenciadorAluguel.Domain.Models.Dtos;

public class EntregadorDto
{
    public string Cnpj { get; set; }
    public string DataNascimento { get; set; }
    public CategoriasCnhEnum CategoriaCnh { get; set; }
    public string NumeroCnh { get; set; }
    public string ImagemCnh { get; set; }
}
