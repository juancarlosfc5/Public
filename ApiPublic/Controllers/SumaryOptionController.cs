using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
namespace APIPublic.Controllers;

public class SumaryOptionController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork; //<- Se inyecta la unidad de trabajo
    public SumaryOptionController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<SumaryOption>>> Get()
    {
        var SumaryOptions = await _unitOfWork.SumaryOptions.GetAllAsync();
        return Ok(SumaryOptions);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(int id)
    {
        var SumaryOption = await _unitOfWork.SumaryOptions.GetByIdAsync(id);
        if (SumaryOption == null)
        {
            return NotFound($"SumaryOption with id {id} was not found.");
        }
        return Ok(SumaryOption);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<SumaryOption>> Post(SumaryOption sumaryOption)
    {
        _unitOfWork.SumaryOptions.Add(sumaryOption);
        await _unitOfWork.SaveAsync();
        if (sumaryOption == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new { id = sumaryOption.Id }, sumaryOption);
    }

    // PUT: api/Productos/4
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put(int id, [FromBody] SumaryOption sumaryOption)
    {
        // Validación: objeto nulo
        if (sumaryOption == null)
            return BadRequest("El cuerpo de la solicitud está vacío.");

        // Validación: el ID de la URL debe coincidir con el del objeto (si viene con ID)
        if (id != sumaryOption.Id)
            return BadRequest("El ID de la URL no coincide con el ID del objeto enviado.");

        // Verificación: el recurso debe existir antes de actualizar
        var existingSumaryOption = await _unitOfWork.SumaryOptions.GetByIdAsync(id);
        if (existingSumaryOption == null)
            return NotFound($"No se encontró el SumaryOption con ID {id}.");

        // Actualización controlada de campos específicos
        existingSumaryOption.Valuerta = sumaryOption.Valuerta;
        // Puedes agregar más propiedades aquí según el modelo

        _unitOfWork.SumaryOptions.Update(existingSumaryOption);
        await _unitOfWork.SaveAsync();

        return Ok(existingSumaryOption);
    }
    
    //DELETE: api/Productos
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var SumaryOption = await _unitOfWork.SumaryOptions.GetByIdAsync(id);
        if (SumaryOption == null)
            return NotFound();

        _unitOfWork.SumaryOptions.Remove(SumaryOption);
        await _unitOfWork.SaveAsync();

        return NoContent();
    }
}