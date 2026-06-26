using Marthada.Domain.Entities;
using Marthada.Domain.Interfaces.Repositories;
using Marthada.Domain.Interfaces.Services.Queries;

namespace Marthada.Api.Services.Categories.Queries;

public sealed class CategoryQueries : ICategoryQueries
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryQueries(ICategoryRepository categoryRepository) => _categoryRepository = categoryRepository;

    public async Task<List<Category>> GetAllAsync(CancellationToken cancellationToken) =>
        await _categoryRepository.GetAllAsync(cancellationToken);
}