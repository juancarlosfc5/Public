using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
namespace APIPublic.Controllers;

public class SubQuestionController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork; //<- Se inyecta la unidad de trabajo
    public SubQuestionController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<SubQuestion>>> Get()
    {
        var SubQuestions = await _unitOfWork.SubQuestions.GetAllAsync();
        return Ok(SubQuestions);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(int id)
    {
        var SubQuestion = await _unitOfWork.SubQuestions.GetByIdAsync(id);
        if (SubQuestion == null)
        {
            return NotFound($"SubQuestion with id {id} was not found.");
        }
        return Ok(SubQuestion);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<SubQuestion>> Post(SubQuestion subQuestion)
    {
        _unitOfWork.SubQuestions.Add(subQuestion);
        await _unitOfWork.SaveAsync();
        if (subQuestion == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new { id = subQuestion.Id }, subQuestion);
    }

    // PUT: api/Productos/4
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put(int id, [FromBody] SubQuestion subQuestion)
    {
        // Validación: objeto nulo
        if (subQuestion == null)
            return BadRequest("El cuerpo de la solicitud está vacío.");

        // Validación: el ID de la URL debe coincidir con el del objeto (si viene con ID)
        if (id != subQuestion.Id)
            return BadRequest("El ID de la URL no coincide con el ID del objeto enviado.");

        // Verificación: el recurso debe existir antes de actualizar
        var existingSubQuestion = await _unitOfWork.SubQuestions.GetByIdAsync(id);
        if (existingSubQuestion == null)
            return NotFound($"No se encontró el SubQuestion con ID {id}.");

        // Actualización controlada de campos específicos
        existingSubQuestion.Subquestion_number = subQuestion.Subquestion_number;
        // Puedes agregar más propiedades aquí según el modelo

        _unitOfWork.SubQuestions.Update(existingSubQuestion);
        await _unitOfWork.SaveAsync();

        return Ok(existingSubQuestion);
    }
    
    //DELETE: api/Productos
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var SubQuestion = await _unitOfWork.SubQuestions.GetByIdAsync(id);
        if (SubQuestion == null)
            return NotFound();

        _unitOfWork.SubQuestions.Remove(SubQuestion);
        await _unitOfWork.SaveAsync();

        return NoContent();
    }
}