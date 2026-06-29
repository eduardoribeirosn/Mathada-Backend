using Marthada.Domain.DTOs.Requests;
using Marthada.Domain.Entities;

namespace Marthada.Domain.Interfaces.Services.Commands;

public interface ICategoryCommands
{
    Task<Category?> CreateAsync(CreateCategoryRequest request, CancellationToken cancellationToken);
    Task<Category?> Update(int id, UpdateCategoryRequest request, CancellationToken cancellationToken);
    Task<bool> Delete(int id, CancellationToken cancellationToken);
}