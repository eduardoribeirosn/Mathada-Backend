using Marthada.Domain.Entities;

namespace Marthada.Domain.Interfaces.Repositories;

public interface IProductRepository
{
    Task<List<Product>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Product?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<Product?> GetByNameAsync(string name, CancellationToken cancellationToken = default);
    Task CreateAsync(Product product, CancellationToken cancellationToken = default);
    Task Update(Product product,  CancellationToken cancellationToken = default);
    Task Delete(Product product, CancellationToken cancellationToken = default);
}