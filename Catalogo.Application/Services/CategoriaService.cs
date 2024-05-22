using AutoMapper;
using Catalogo.Application.DTOs;
using Catalogo.Application.Interfaces;
using Catalogo.Domain.Entities;
using Catalogo.Domain.Interfaces;

namespace Catalogo.Application.Services;

public class CategoriaService : ICategoriaService
{
    private ICategoriaRepository _categoriaRepository;
    private readonly IMapper _mapper;

    public CategoriaService(ICategoriaRepository categoriaRepository, IMapper mapper)
    {
        _categoriaRepository = categoriaRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CategoriaDTO>> GetCategorias()
    {
        try
        {
            var categorias = await _categoriaRepository.GetCategoriasAsync();
            var categoriasDto = _mapper.Map<IEnumerable<CategoriaDTO>>(categorias);
            return categoriasDto;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<CategoriaDTO> GetCategoriaById(int? id)
    {
        var categoria = await _categoriaRepository.GetCategoriaByIdAsync(id);
        return _mapper.Map<CategoriaDTO>(categoria);
    }

    public async Task Add(CategoriaDTO categoriaDto)
    {
        var categoria = _mapper.Map<Categoria>(categoriaDto);
        await _categoriaRepository.CreateAsync(categoria);
    }

    public async Task Update(CategoriaDTO categoriaDto)
    {
        var categoria = _mapper.Map<Categoria>(categoriaDto);
        await _categoriaRepository.UpdateAsync(categoria);
    }

    public async Task Remove(int? id)
    {
        var categoria = await _categoriaRepository.GetCategoriaByIdAsync(id);
        await _categoriaRepository.RemoveAsync(categoria);
    }
}