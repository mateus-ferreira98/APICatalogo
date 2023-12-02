namespace APICatalogo.Models;

public class Produto
{
    public int Id { get; set; }

    public string Nome { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;

    public decimal Preco { get; set; }

    public string ImagemUrl { get; set; } = string.Empty;

    public float Estoque { get; set; }

    public DateTime DataCadastro { get; set; }
}
