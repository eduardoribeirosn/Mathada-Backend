using Marthada.Domain.Entities;

namespace Marthada.Domain.Interfaces.Repositories;

public interface ICategoryRepository
{
    Task<List<Category>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Category?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<Category?> GetByNameAsync(string name, CancellationToken cancellationToken = default);
    Task CreateAsync(Category category, CancellationToken cancellationToken = default);
    Task Update(Category category,  CancellationToken cancellationToken = default);
    Task Delete(Category category, CancellationToken cancellationToken = default);
}