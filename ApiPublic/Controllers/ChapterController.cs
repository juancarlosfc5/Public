using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
namespace APIPublic.Controllers;

public class ChapterController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork; //<- Se inyecta la unidad de trabajo
    public ChapterController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Chapter>>> Get()
    {
        var Chapters = await _unitOfWork.Chapters.GetAllAsync();
        return Ok(Chapters);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(int id)
    {
        var Chapter = await _unitOfWork.Chapters.GetByIdAsync(id);
        if (Chapter == null)
        {
            return NotFound($"Chapter with id {id} was not found.");
        }
        return Ok(Chapter);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Chapter>> Post(Chapter chapter)
    {
        _unitOfWork.Chapters.Add(chapter);
        await _unitOfWork.SaveAsync();
        if (chapter == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new { id = chapter.Id }, chapter);
    }

    // PUT: api/Productos/4
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put(int id, [FromBody] Chapter chapter)
    {
        // Validación: objeto nulo
        if (chapter == null)
            return BadRequest("El cuerpo de la solicitud está vacío.");

        // Validación: el ID de la URL debe coincidir con el del objeto (si viene con ID)
        if (id != chapter.Id)
            return BadRequest("El ID de la URL no coincide con el ID del objeto enviado.");

        // Verificación: el recurso debe existir antes de actualizar
        var existingChapter = await _unitOfWork.Chapters.GetByIdAsync(id);
        if (existingChapter == null)
            return NotFound($"No se encontró el Chapter con ID {id}.");

        // Actualización controlada de campos específicos
        existingChapter.Chapter_number = chapter.Chapter_number;
        // Puedes agregar más propiedades aquí según el modelo

        _unitOfWork.Chapters.Update(existingChapter);
        await _unitOfWork.SaveAsync();

        return Ok(existingChapter);
    }
    
    //DELETE: api/Productos
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var Chapter = await _unitOfWork.Chapters.GetByIdAsync(id);
        if (Chapter == null)
            return NotFound();

        _unitOfWork.Chapters.Remove(Chapter);
        await _unitOfWork.SaveAsync();

        return NoContent();
    }
}