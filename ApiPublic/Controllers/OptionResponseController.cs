using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
namespace APIPublic.Controllers;

public class OptionResponseController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork; //<- Se inyecta la unidad de trabajo
    public OptionResponseController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<OptionResponse>>> Get()
    {
        var OptionResponses = await _unitOfWork.OptionResponses.GetAllAsync();
        return Ok(OptionResponses);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(int id)
    {
        var OptionResponse = await _unitOfWork.OptionResponses.GetByIdAsync(id);
        if (OptionResponse == null)
        {
            return NotFound($"OptionResponse with id {id} was not found.");
        }
        return Ok(OptionResponse);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<OptionResponse>> Post(OptionResponse optionResponse)
    {
        _unitOfWork.OptionResponses.Add(optionResponse);
        await _unitOfWork.SaveAsync();
        if (optionResponse == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new { id = optionResponse.Id }, optionResponse);
    }

    // PUT: api/Productos/4
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put(int id, [FromBody] OptionResponse optionResponse)
    {
        // Validación: objeto nulo
        if (optionResponse == null)
            return BadRequest("El cuerpo de la solicitud está vacío.");

        // Validación: el ID de la URL debe coincidir con el del objeto (si viene con ID)
        if (id != optionResponse.Id)
            return BadRequest("El ID de la URL no coincide con el ID del objeto enviado.");

        // Verificación: el recurso debe existir antes de actualizar
        var existingOptionResponse = await _unitOfWork.OptionResponses.GetByIdAsync(id);
        if (existingOptionResponse == null)
            return NotFound($"No se encontró el OptionResponse con ID {id}.");

        // Actualización controlada de campos específicos
        existingOptionResponse.Option_text = optionResponse.Option_text;
        // Puedes agregar más propiedades aquí según el modelo

        _unitOfWork.OptionResponses.Update(existingOptionResponse);
        await _unitOfWork.SaveAsync();

        return Ok(existingOptionResponse);
    }
    
    //DELETE: api/Productos
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var OptionResponse = await _unitOfWork.OptionResponses.GetByIdAsync(id);
        if (OptionResponse == null)
            return NotFound();

        _unitOfWork.OptionResponses.Remove(OptionResponse);
        await _unitOfWork.SaveAsync();

        return NoContent();
    }
}