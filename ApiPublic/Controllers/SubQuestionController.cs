using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
namespace APIPublic.Controllers;
using Application.DTOs;
using AutoMapper;

public class SubQuestionController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork; //<- Se inyecta la unidad de trabajo
    private readonly IMapper _mapper; //<- Se inyecta el mapeador de AutoMapper
    public SubQuestionController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<SubQuestionDto>>> Get()
    {
        var SubQuestion = await _unitOfWork.SubQuestions.GetAllAsync();
        return _mapper.Map<List<SubQuestionDto>>(SubQuestion);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<SubQuestionDto>> Get(int id)
    {
        var SubQuestion = await _unitOfWork.SubQuestions.GetByIdAsync(id);
        if (SubQuestion == null)
        {
            return NotFound($"Question with id {id} was not found.");
        }
        return _mapper.Map<SubQuestionDto>(SubQuestion);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<SubQuestion>> Post(SubQuestionDto subQuestionDto)
    {
        var subQuestion = _mapper.Map<SubQuestion>(subQuestionDto);
        _unitOfWork.SubQuestions.Add(subQuestion);
        await _unitOfWork.SaveAsync();
        if (subQuestionDto == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new { id = subQuestionDto.Id }, subQuestionDto);
    }

    // PUT: api/Productos/4
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put(int id, [FromBody] SubQuestionDto subQuestionDto)
    {
        // Validación: objeto nulo
        if (subQuestionDto == null)
            return NotFound();
        var subQuestion = _mapper.Map<SubQuestion>(subQuestionDto);
        _unitOfWork.SubQuestions.Update(subQuestion);
        await _unitOfWork.SaveAsync();
        return Ok(subQuestionDto);
    }
    
    //DELETE: api/Productos
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var subQuestion = await _unitOfWork.SubQuestions.GetByIdAsync(id);
        if (subQuestion == null)
            return NotFound();
        _unitOfWork.SubQuestions.Remove(subQuestion);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}