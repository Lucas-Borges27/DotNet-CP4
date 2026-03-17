using Microsoft.AspNetCore.Mvc;
using ToyAPI.DTOs;
using ToyAPI.Services;

namespace ToyAPI.Controllers;

[ApiController]
[Route("brinquedos")]
public class BrinquedosController : ControllerBase
{
    private readonly IBrinquedoService _service;

    public BrinquedosController(IBrinquedoService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<List<BrinquedoReadDto>>> GetAll()
    {
        var items = await _service.GetAllAsync();
        return Ok(items);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<BrinquedoReadDto>> GetById(int id)
    {
        var item = await _service.GetByIdAsync(id);
        if (item is null)
        {
            return NotFound();
        }

        return Ok(item);
    }

    [HttpPost]
    public async Task<ActionResult<BrinquedoReadDto>> Create([FromBody] BrinquedoCreateDto dto)
    {
        var created = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.IdBrinquedo }, created);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] BrinquedoUpdateDto dto)
    {
        var updated = await _service.UpdateAsync(id, dto);
        if (!updated)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _service.DeleteAsync(id);
        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}
