using Marthada.Domain.DTOs.Requests;
using Marthada.Domain.Entities;
using Marthada.Domain.Interfaces.Repositories;
using Marthada.Domain.Interfaces.Services.Commands;

namespace Marthada.Api.Services.Categories.Commands;

public sealed class CategoryCommands : ICategoryCommands
{
    private readonly ICategoryRepository _category;

    public CategoryCommands(ICategoryRepository category) => _category = category;

    public async Task<Category?> CreateAsync(CreateCategoryRequest request, CancellationToken cancellationToken) {
        var exists = await _category.GetByNameAsync(request.Name, cancellationToken);

        if (exists != null)
        {
            return null;
        }

        var category = Category.Create(
            request.Name
        );
            
        await _category.CreateAsync(category, cancellationToken);

        // var categoryCreated = await _category.GetByNameAsync(request.Name, cancellationToken);

        return category;
    }

    public async Task<Category?> Update(int id, UpdateCategoryRequest request, CancellationToken cancellationToken)
    {
        var exists = await _category.GetByIdAsync(id, cancellationToken);

        if (exists == null)
        {
            return null;
        }

        exists.Update(
            request.Name
        );

        await _category.Update(exists, cancellationToken);

        return exists;
    }

    public async Task<bool> Delete(int id, CancellationToken cancellationToken)
    {
        var exists = await _category.GetByIdAsync(id, cancellationToken);

        if (exists == null)
        {
            return false;
        }

        await _category.Delete(exists, cancellationToken);

        return true;
    }
}