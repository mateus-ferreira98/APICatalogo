using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APICatalogo.Models;

public class Produto
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Nome deve ser informado")]
    [MinLength(3, ErrorMessage = "Nome precisa ter no mínimo 3 caracteres")]
    [MaxLength(100, ErrorMessage = "Nome precisa ter no máximo 100 caracteres")]
    public string Nome { get; set; } = string.Empty;

    [Required(ErrorMessage = "Descrição deve ser informada")]
    [MinLength(3, ErrorMessage = "Descrição precisa ter no mínimo 3 caracteres")]
    [MaxLength(300, ErrorMessage = "Descrição precisa ter no máximo 300 caracteres")]
    public string Descricao { get; set; } = string.Empty;

    [Required(ErrorMessage = "Preço deve ser informada")]
    [Column(TypeName="decimal(10,2)")]
    public decimal Preco { get; set; }

    [Required(ErrorMessage = "Imagem deve ser informada")]
    [StringLength(300)]
    public string ImagemUrl { get; set; } = string.Empty;

    public float Estoque { get; set; }

    public DateTime DataCadastro { get; set; }

    public int CategoriaId { get; set; }

    [JsonIgnore]
    public Categoria Categoria { get; set; } = new();
}
