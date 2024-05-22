using AutoMapper;
using Catalogo.Application.DTOs;
using Catalogo.Application.Interfaces;
using Catalogo.Domain.Entities;
using Catalogo.Domain.Interfaces;

namespace Catalogo.Application.Services;

public class ProdutoService : IProdutoService
{
    private IProdutoRepository _produtoRepository;
    private readonly IMapper _mapper;

    public ProdutoService(IMapper mapper, IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository ?? throw new ArgumentNullException(nameof(produtoRepository));
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProdutoDTO>> GetProdutos()
    {
        var produtos = await _produtoRepository.GetProdutosAsync();
        return _mapper.Map<IEnumerable<ProdutoDTO>>(produtos);
    }

    public async Task<ProdutoDTO> GetProdutoById(int? id)
    {
        var produto = await _produtoRepository.GetProdutoByIdAsync(id);
        return _mapper.Map<ProdutoDTO>(produto);
    }

    public async Task Add(ProdutoDTO produtoDto)
    {
        var produto = _mapper.Map<Produto>(produtoDto);
        await _produtoRepository.CreateAsync(produto);
    }

    public async Task Update(ProdutoDTO produtoDto)
    {
        var produto = _mapper.Map<Produto>(produtoDto);
        await _produtoRepository.UpdateAsync(produto);
    }

    public async Task Remove(int? id)
    {
        var produto = await _produtoRepository.GetProdutoByIdAsync(id);
        await _produtoRepository.RemoveAsync(produto);
    }
}