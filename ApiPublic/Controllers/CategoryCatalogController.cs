using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
namespace APIPublic.Controllers;
using Application.DTOs;
using AutoMapper;

public class CategoryCatalogController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork; //<- Se inyecta la unidad de trabajo
    private readonly IMapper _mapper; //<- Se inyecta el mapeador de AutoMapper
    public CategoryCatalogController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<CategoryCatalogDto>>> Get()
    {
        var CategoryCatalog = await _unitOfWork.CategoryCatalogs.GetAllAsync();
        return _mapper.Map<List<CategoryCatalogDto>>(CategoryCatalog);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CategoryCatalogDto>> Get(int id)
    {
        var CategoryCatalog = await _unitOfWork.CategoryCatalogs.GetByIdAsync(id);
        if (CategoryCatalog == null)
        {
            return NotFound($"CategoryCatalog with id {id} was not found.");
        }
        return _mapper.Map<CategoryCatalogDto>(CategoryCatalog);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CategoryCatalog>> Post(CategoryCatalogDto categoryCatalogDto)
    {
        var categoryCatalog = _mapper.Map<CategoryCatalog>(categoryCatalogDto);
        _unitOfWork.CategoryCatalogs.Add(categoryCatalog);
        await _unitOfWork.SaveAsync();
        if (categoryCatalogDto == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new { id = categoryCatalogDto.Id }, categoryCatalogDto);
    }

    // PUT: api/Productos/4
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put(int id, [FromBody] CategoryCatalogDto categoryCatalogDto)
    {
        // Validación: objeto nulo
        if (categoryCatalogDto == null)
            return NotFound();
        var categoryCatalog = _mapper.Map<CategoryCatalog>(categoryCatalogDto);
        _unitOfWork.CategoryCatalogs.Update(categoryCatalog);
        await _unitOfWork.SaveAsync();
        return Ok(categoryCatalogDto);
    }
    
    //DELETE: api/Productos
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var CategoryCatalog = await _unitOfWork.CategoryCatalogs.GetByIdAsync(id);
        if (CategoryCatalog == null)
            return NotFound();
        _unitOfWork.CategoryCatalogs.Remove(CategoryCatalog);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}