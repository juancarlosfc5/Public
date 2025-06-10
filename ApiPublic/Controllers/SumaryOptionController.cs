using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
namespace APIPublic.Controllers;
using Application.DTOs;
using AutoMapper;

public class SumaryOptionController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork; //<- Se inyecta la unidad de trabajo
    private readonly IMapper _mapper; //<- Se inyecta el mapeador de AutoMapper
    public SumaryOptionController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<SumaryOptionDto>>> Get()
    {
        var SumaryOption = await _unitOfWork.SumaryOptions.GetAllAsync();
        return _mapper.Map<List<SumaryOptionDto>>(SumaryOption);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<SumaryOptionDto>> Get(int id)
    {
        var SumaryOption = await _unitOfWork.SumaryOptions.GetByIdAsync(id);
        if (SumaryOption == null)
        {
            return NotFound($"SumaryOption with id {id} was not found.");
        }
        return _mapper.Map<SumaryOptionDto>(SumaryOption);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<SumaryOption>> Post(SumaryOptionDto sumaryOptionDto)
    {
        var sumaryOption = _mapper.Map<SumaryOption>(sumaryOptionDto);
        _unitOfWork.SumaryOptions.Add(sumaryOption);
        await _unitOfWork.SaveAsync();
        if (sumaryOptionDto == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new { id = sumaryOptionDto.Id }, sumaryOptionDto);
    }

    // PUT: api/Productos/4
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put(int id, [FromBody] SumaryOptionDto sumaryOptionDto)
    {
        if (sumaryOptionDto == null)
            return NotFound();
        var sumaryOption = _mapper.Map<SumaryOption>(sumaryOptionDto);
        _unitOfWork.SumaryOptions.Update(sumaryOption);
        await _unitOfWork.SaveAsync();
        return Ok(sumaryOptionDto);
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