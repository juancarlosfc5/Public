using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
namespace APIPublic.Controllers;
using Application.DTOs;
using AutoMapper;

public class OptionQuestionController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork; //<- Se inyecta la unidad de trabajo
    private readonly IMapper _mapper; //<- Se inyecta el mapeador de AutoMapper
    public OptionQuestionController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<OptionQuestionDto>>> Get()
    {
        var OptionQuestion = await _unitOfWork.OptionQuestions.GetAllAsync();
        return _mapper.Map<List<OptionQuestionDto>>(OptionQuestion);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<OptionQuestionDto>> Get(int id)
    {
        var OptionQuestion = await _unitOfWork.OptionQuestions.GetByIdAsync(id);
        if (OptionQuestion == null)
        {
            return NotFound($"OptionQuestion with id {id} was not found.");
        }
        return _mapper.Map<OptionQuestionDto>(OptionQuestion);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<OptionQuestion>> Post(OptionQuestionDto optionQuestionDto)
    {
        var optionQuestion = _mapper.Map<OptionQuestion>(optionQuestionDto);
        _unitOfWork.OptionQuestions.Add(optionQuestion);
        await _unitOfWork.SaveAsync();
        if (optionQuestionDto == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new { id = optionQuestionDto.Id }, optionQuestionDto);
    }

    // PUT: api/Productos/4
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put(int id, [FromBody] OptionQuestionDto optionQuestionDto)
    {
        // Validación: objeto nulo
        if (optionQuestionDto == null)
            return NotFound();
        var optionQuestion = _mapper.Map<OptionQuestion>(optionQuestionDto);
        _unitOfWork.OptionQuestions.Update(optionQuestion);
        await _unitOfWork.SaveAsync();
        return Ok(optionQuestionDto);
    }
    
    //DELETE: api/Productos
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var OptionQuestion = await _unitOfWork.OptionQuestions.GetByIdAsync(id);
        if (OptionQuestion == null)
            return NotFound();
        _unitOfWork.OptionQuestions.Remove(OptionQuestion);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}