using Marthada.Domain.Entities;
using Marthada.Domain.Interfaces.Services.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Marthada.Api.Controllers;

[ApiController]
[Route("api/v1/category")]
public sealed class CategoryController : ControllerBase
{
    private readonly ICategoryQueries _categoryQueries;

    public CategoryController(ICategoryQueries category) => _categoryQueries = category;

    [HttpGet]
    [ProducesResponseType(typeof(List<Category>), 200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetAll(CancellationToken ct)
    {
        var result = await _categoryQueries.GetAllAsync(ct);

        return Ok(result);
    }
}