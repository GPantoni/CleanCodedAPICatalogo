using Catalogo.Application.DTOs;

namespace Catalogo.Application.Interfaces;

public interface ICategoriaService
{
    Task<IEnumerable<CategoriaDTO>> GetCategorias();
    Task<CategoriaDTO> GetCategoriaById(int? id);
    Task Add(CategoriaDTO categoriaDto);
    Task Update(CategoriaDTO categoriaDto);
    Task Remove(int? id);
}