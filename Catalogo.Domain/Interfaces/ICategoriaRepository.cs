using Catalogo.Domain.Entities;

namespace Catalogo.Domain.Interfaces;

public interface ICategoriaRepository
{
    Task<IEnumerable<Categoria>> GetCategoriasAsync();
    Task<Categoria> GetCategoriaByIdAsync(int? id);
    Task<Categoria> CreateAsync(Categoria categoria);
    Task<Categoria> UpdateAsync(Categoria categoria);
    Task<Categoria> RemoveAsync(Categoria categoria);
}