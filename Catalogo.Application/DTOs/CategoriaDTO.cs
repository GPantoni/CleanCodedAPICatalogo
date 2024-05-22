using System.ComponentModel.DataAnnotations;

namespace Catalogo.Application.DTOs;

public class CategoriaDTO
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Informe o nome da categoria")]
    // [MinLength(3, ErrorMessage = "O nome da categoria deve ter no mínimo 3 caracteres")]
    // [MaxLength(100, ErrorMessage = "O nome da categoria deve ter no máximo 100 caracteres")]
    [Length(3, 100, ErrorMessage = "O nome da categoria deve ter entre {2} e {1} caracteres")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "Informe o nome da imagem")]
    [Length(5, 250, ErrorMessage = "O nome da imagem deve ter entre {2} e {1} caracteres")]
    public string ImagemUrl { get; set; }
}