using Catalogo.Application.DTOs;
using Catalogo.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Catalogo.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class CategoriasController : ControllerBase
{
    private readonly ICategoriaService _categoriaService;

    public CategoriasController(ICategoriaService categoriaService)
    {
        _categoriaService = categoriaService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoriaDTO>>> Get()
    {
        var categorias = await _categoriaService.GetCategorias();
        return Ok(categorias);
    }

    [HttpGet("{id}", Name = "ObterCategoria")]
    public async Task<ActionResult<CategoriaDTO>> Get(int id)
    {
        var categoria = await _categoriaService.GetCategoriaById(id);

        if (categoria == null)
            return NotFound();

        return categoria;
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] CategoriaDTO categoriaDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        await _categoriaService.Add(categoriaDto);
        
        return new CreatedAtRouteResult("ObterCategoria", new { id = categoriaDto.Id }, categoriaDto);
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, [FromBody] CategoriaDTO categoriaDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        if (id != categoriaDto.Id)
            return BadRequest();

        await _categoriaService.Update(categoriaDto);

        return Ok(categoriaDto);
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult<CategoriaDTO>> Delete(int id)
    {
        var categoriaDto = await _categoriaService.GetCategoriaById(id);

        if (categoriaDto == null)
            return NotFound();

        await _categoriaService.Remove(id);

        return Ok(categoriaDto);
    }
}