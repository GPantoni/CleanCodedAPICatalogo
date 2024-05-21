using Catalogo.Domain.Validation;

namespace Catalogo.Domain.Entities;

public sealed class Produto : Entity
{
    public Produto(string nome, string descricao, decimal preco, string? imagemUrl, int estoque, DateTime dataCadastro)
    {
        ValidateDomain(nome, descricao, preco, imagemUrl, estoque, dataCadastro);
    }

    public int CategoriaId { get; set; }
    public required Categoria Categoria { get; set; }

    public string Nome { get; private set; }
    public string Descricao { get; private set; }
    public decimal Preco { get; private set; }
    public string? ImagemUrl { get; private set; }
    public int Estoque { get; private set; }
    public DateTime DataCadastro { get; private set; }

    public void Update(string nome, string descricao, decimal preco, string? imagemUrl, int estoque,
        DateTime dataCadastro, int categoriaId)
    {
        ValidateDomain(nome, descricao, preco, imagemUrl, estoque, dataCadastro);
        CategoriaId = categoriaId;
    }

    private void ValidateDomain(string nome, string descricao, decimal preco, string? imagemUrl, int estoque,
        DateTime dataCadastro)
    {
        DomainExceptionValidation.When(string.IsNullOrWhiteSpace(nome), "Nome é obrigatório");
        DomainExceptionValidation.When(nome.Length < 3, "Nome deve ter no mínimo 3 caracteres");
        DomainExceptionValidation.When(string.IsNullOrWhiteSpace(descricao), "Descrição é obrigatória");
        DomainExceptionValidation.When(descricao.Length < 5, "Descrição deve ter no mínimo 5 caracteres");
        DomainExceptionValidation.When(preco < 0, "Valor de preço inválido. Preço deve ser maior ou igual a zero");
        DomainExceptionValidation.When(imagemUrl?.Length > 250, "A url da imagem deve ter no máximo 250 caracteres");
        DomainExceptionValidation.When(estoque < 0,
            "Valor de estoque inválido. Estoque deve ser maior ou igual a zero");
        DomainExceptionValidation.When(dataCadastro < DateTime.Now, "Data de cadastro inválida");

        Nome = nome;
        Descricao = descricao;
        Preco = preco;
        ImagemUrl = imagemUrl;
        Estoque = estoque;
        DataCadastro = dataCadastro;
    }
}