using Catalogo.Domain.Entities;
using Catalogo.Domain.Interfaces;
using Catalogo.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Catalogo.Infrastructure.Repositories;

public class ProdutoRepository : IProdutoRepository
{
    private ApplicationDbContext _produtoContext;

    public ProdutoRepository(ApplicationDbContext context)
    {
        _produtoContext = context;
    }

    public async Task<IEnumerable<Produto>> GetProdutosAsync()
    {
        return await _produtoContext.Produtos.ToListAsync();
    }

    public async Task<Produto> GetProdutoByIdAsync(int? id)
    {
        // return await _produtoContext.Produtos.FindAsync(id);
        return await _produtoContext.Produtos.Include(p => p.Categoria).FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Produto> CreateAsync(Produto produto)
    {
        _produtoContext.Produtos.Add(produto);
        await _produtoContext.SaveChangesAsync();
        return produto;
    }

    public async Task<Produto> UpdateAsync(Produto produto)
    {
        _produtoContext.Update(produto);
        await _produtoContext.SaveChangesAsync();
        return produto;
    }

    public async Task<Produto> RemoveAsync(Produto produto)
    {
        _produtoContext.Remove(produto);
        await _produtoContext.SaveChangesAsync();
        return produto;
    }
}