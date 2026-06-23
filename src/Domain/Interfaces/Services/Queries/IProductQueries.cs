using Marthada.Domain.DTOs.Requests;
using Marthada.Domain.Entities;

namespace Marthada.Domain.Interfaces.Services.Queries;

public interface IProductQueries
{
    Task<List<Product>> GetAllAsync(CancellationToken cancellationToken);
    Task<Product?> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<Product?> GetByNameAsync(string name, CancellationToken cancellationToken);
}