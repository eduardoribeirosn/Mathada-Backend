using Marthada.Domain.DTOs.Requests;
using Marthada.Domain.Entities;
using Marthada.Domain.Interfaces.Services.Commands;
using Marthada.Domain.Interfaces.Services.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Marthada.Api.Controllers;

[ApiController]
[Route("api/v1/category")]
public sealed class CategoryController : ControllerBase
{
    private readonly ICategoryQueries _categoryQueries;
    private readonly ICategoryCommands _categoryCommands;

    public CategoryController(ICategoryQueries categoryQueries, ICategoryCommands categoryCommands)
    {
      _categoryQueries = categoryQueries;
      _categoryCommands = categoryCommands;  
    } 

    [HttpGet]
    [ProducesResponseType(typeof(List<Category>), 200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetAll(CancellationToken ct)
    {
        var result = await _categoryQueries.GetAllAsync(ct);

        return Ok(result);
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(Product), 200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetById([FromRoute] int id, CancellationToken ct)
    {
        var result = await _categoryQueries.GetByIdAsync(id, ct);

        if (result is null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(409)]
    public async Task<IActionResult> Create([FromBody] CreateCategoryRequest request, CancellationToken ct)
    {
        var result = await _categoryCommands.CreateAsync(request, ct);

        if (result is null)
        {
            return Conflict($"Categoria com este nome '{request.Name}', já existe!");
        }

        return NoContent();
    }

    [HttpPut("{id:int}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateCategoryRequest request, CancellationToken ct)
    {
        var result = await _categoryCommands.Update(id, request, ct);
        
        if (result is null)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Delete(int id, CancellationToken ct)
    {
        var result = await _categoryCommands.Delete(id, ct);

        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }
}