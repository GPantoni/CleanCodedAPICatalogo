using Catalogo.Domain.Validation;

namespace Catalogo.Domain.Entities;

public sealed class Categoria : Entity
{
    public Categoria(string nome, string imagemUrl)
    {
        ValidateDomain(nome, imagemUrl);
    }

    public Categoria(int id, string nome, string imagemUrl)
    {
        DomainExceptionValidation.When(id <= 0, "Valor de Id inválido");
        Id = id;
        ValidateDomain(nome, imagemUrl);
    }

    public string Nome { get; private set; }
    public string ImagemUrl { get; private set; }
    public ICollection<Produto> Produtos { get; set; }

    private void ValidateDomain(string nome, string imagemUrl)
    {
        DomainExceptionValidation.When(string.IsNullOrWhiteSpace(nome), "Nome é obrigatório");
        DomainExceptionValidation.When(nome.Length < 3, "Nome deve ter no mínimo 3 caracteres");
        DomainExceptionValidation.When(string.IsNullOrWhiteSpace(imagemUrl), "ImagemUrl é obrigatória");
        DomainExceptionValidation.When(imagemUrl.Length < 5, "ImagemUrl deve ter no mínimo 5 caracteres");

        Nome = nome;
        ImagemUrl = imagemUrl;
    }
}