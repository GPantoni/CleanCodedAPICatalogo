using Catalogo.Domain.Entities;
using Catalogo.Domain.Interfaces;
using Catalogo.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Catalogo.Infrastructure.Repositories;

public class CategoriaRepository : ICategoriaRepository
{
    private ApplicationDbContext _categoriaContext;

    public CategoriaRepository(ApplicationDbContext context)
    {
        _categoriaContext = context;
    }

    public async Task<IEnumerable<Categoria>> GetCategoriasAsync()
    {
        var categorias = await _categoriaContext.Categorias.ToListAsync();
        return categorias;
    }

    public async Task<Categoria> GetCategoriaByIdAsync(int? id)
    {
        var categoria = await _categoriaContext.Categorias.FindAsync(id);
        return categoria;
    }

    public async Task<Categoria> CreateAsync(Categoria categoria)
    {
        _categoriaContext.Categorias.Add(categoria);
        await _categoriaContext.SaveChangesAsync();
        return categoria;
    }

    public async Task<Categoria> UpdateAsync(Categoria categoria)
    {
        _categoriaContext.Categorias.Update(categoria);
        await _categoriaContext.SaveChangesAsync();
        return categoria;
    }

    public async Task<Categoria> RemoveAsync(Categoria categoria)
    {
        _categoriaContext.Categorias.Remove(categoria);
        await _categoriaContext.SaveChangesAsync();
        return categoria;
    }
}