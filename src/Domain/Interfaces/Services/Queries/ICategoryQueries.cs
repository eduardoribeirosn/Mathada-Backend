using Marthada.Domain.Entities;

namespace Marthada.Domain.Interfaces.Services.Queries;

public interface ICategoryQueries
{
    Task<List<Category>> GetAllAsync(CancellationToken cancellationToken);
}