using Marthada.Domain.Entities;

namespace Marthada.Domain.Interfaces.Repositories;

public interface ICategoryRepository
{
    Task<List<Category>> GetAllAsync(CancellationToken cancellationToken = default);
}