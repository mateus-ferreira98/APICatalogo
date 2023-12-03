using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace APICatalogo.Models;

public class Categoria
{
    public Categoria()
    {
        Produtos = new Collection<Produto>();
    }

    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage="Nome deve ser informado")]
    [MinLength(3, ErrorMessage = "Nome precisa ter no mínimo 3 caracteres")]
    [MaxLength(100, ErrorMessage = "Nome precisa ter no máximo 100 caracteres")]
    public string Nome { get; set; } = string.Empty;

    [Required(ErrorMessage = "Imagem deve ser informada")]
    [StringLength(300)]
    public string ImagemUrl { get; set; } = string.Empty;

    public ICollection<Produto>? Produtos { get; set; }
}
