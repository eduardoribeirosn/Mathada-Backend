using Marthada.Domain.DTOs.Requests;
using Marthada.Domain.Entities;
using Marthada.Domain.Interfaces.Services.Commands;
using Marthada.Domain.Interfaces.Services.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Marthada.Api.Controllers;

[ApiController]
[Route("api/v1/products")]
[Produces("application/json")]

public sealed class ProductController : ControllerBase
{
    private IProductQueries _productQueries;
    private IProductCommands _productCommands;

    public ProductController(
        IProductQueries productQueries,
        IProductCommands productCommands
        )
    {
        _productQueries = productQueries;
        _productCommands = productCommands;
    } 

    [HttpGet]
    [ProducesResponseType(typeof(List<Product>), 200)]
    // [ProducesResponseType(404)]
    public async Task<IActionResult> GetAll(CancellationToken ct)
    {
        var result = await _productQueries.GetAllAsync(ct);

        return Ok(result);
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(Product), 200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetById([FromRoute] int id, CancellationToken ct)
    {
        var result = await _productQueries.GetByIdAsync(id, ct);

        if (result is null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpGet("{name}")]
    [ProducesResponseType(typeof(Product), 200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetByName([FromRoute] string name, CancellationToken ct)
    {
        var result = await _productQueries.GetByNameAsync(name, ct);

        if (result is null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(Product), 201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(409)]
    public async Task<IActionResult> Create([FromBody] CreateProductRequest request, CancellationToken ct)
    {
        var result = await _productCommands.CreateAsync(request, ct);

        if (result is null)
        {
            return Conflict($"Produto com este nome '{request.Name}', já existe!");
        }

        return CreatedAtAction(
            nameof(GetByName),
            new { name = result.Name},
            result
        );
    }

    [HttpPut("{id:int}")]
    [ProducesResponseType(typeof(Product), 200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateProductRequest request, CancellationToken ct)
    {
        var result = await _productCommands.Update(id, request, ct);
        
        if (result is null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Delete(int id, CancellationToken ct)
    {
        var result = await _productCommands.Delete(id, ct);

        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpPut("IsActive/{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> ToggleActive(int id, CancellationToken ct)
    {
        var result = await _productCommands.ToggleActive(id, ct);

        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpPut("PromotionalIsActive/{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> TogglePromotinalActive(int id, CancellationToken ct)
    {
        var result = await _productCommands.TogglePromotinalActive(id, ct);

        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }
}