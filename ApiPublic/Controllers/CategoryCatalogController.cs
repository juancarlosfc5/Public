using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
namespace APIPublic.Controllers;

public class CategoryCatalogController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork; //<- Se inyecta la unidad de trabajo
    public CategoryCatalogController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<CategoryCatalog>>> Get()
    {
        var CategoryCatalog = await _unitOfWork.CategoryCatalogs.GetAllAsync();
        return Ok(CategoryCatalog);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(int id)
    {
        var CategoryCatalog = await _unitOfWork.CategoryCatalogs.GetByIdAsync(id);
        if (CategoryCatalog == null)
        {
            return NotFound($"CategoryCatalog with id {id} was not found.");
        }
        return Ok(CategoryCatalog);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CategoryCatalog>> Post(CategoryCatalog categoryCatalog)
    {
        _unitOfWork.CategoryCatalogs.Add(categoryCatalog);
        await _unitOfWork.SaveAsync();
        if (categoryCatalog == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new { id = categoryCatalog.Id }, categoryCatalog);
    }

    // PUT: api/Productos/4
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put(int id, [FromBody] CategoryCatalog categoryCatalog)
    {
        // Validación: objeto nulo
        if (categoryCatalog == null)
            return BadRequest("El cuerpo de la solicitud está vacío.");

        // Validación: el ID de la URL debe coincidir con el del objeto (si viene con ID)
        if (id != categoryCatalog.Id)
            return BadRequest("El ID de la URL no coincide con el ID del objeto enviado.");

        // Verificación: el recurso debe existir antes de actualizar
        var existingCategoryCatalog = await _unitOfWork.CategoryCatalogs.GetByIdAsync(id);
        if (existingCategoryCatalog == null)
            return NotFound($"No se encontró el CategoryCatalog con ID {id}.");

        // Actualización controlada de campos específicos
        existingCategoryCatalog.Name = categoryCatalog.Name;
        // Puedes agregar más propiedades aquí según el modelo

        _unitOfWork.CategoryCatalogs.Update(existingCategoryCatalog);
        await _unitOfWork.SaveAsync();

        return Ok(existingCategoryCatalog);
    }
    
    //DELETE: api/Productos
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var country = await _unitOfWork.CategoryCatalogs.GetByIdAsync(id);
        if (country == null)
            return NotFound();

        _unitOfWork.CategoryCatalogs.Remove(country);
        await _unitOfWork.SaveAsync();

        return NoContent();
    }
}