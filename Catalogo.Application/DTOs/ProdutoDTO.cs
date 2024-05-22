using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Catalogo.Application.DTOs;

public class ProdutoDTO
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O nome do produto deve ser informado")]
    [Length(3, 100, ErrorMessage = "O nome do produto deve ter entre {2} e {1} caracteres")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "A descrição do produto deve ser informada")]
    [Length(5, 200, ErrorMessage = "A descrição do produto deve ter entre {2} e {1} caracteres")]
    public string Descricao { get; set; }

    [Required(ErrorMessage = "O preço do produto deve ser informado")]
    [Column(TypeName = "decimal(18,2)")]
    [DisplayFormat(DataFormatString = "{0:C2}")]
    [DataType(DataType.Currency)]
    public decimal Preco { get; set; }

    [MaxLength(250, ErrorMessage = "A URL da imagem deve ter no máximo 250 caracteres")]
    public string ImagemUrl { get; set; }

    [Required(ErrorMessage = "O estoque do produto deve ser informado")]
    [Range(1, 9999)]
    public int Estoque { get; set; }

    [Required(ErrorMessage = "A data de cadastro do produto deve ser informada")]
    public DateTime DataCadastro { get; set; }

    public int CategoriaId { get; set; }
}