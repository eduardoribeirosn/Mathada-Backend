using Marthada.Domain.Entities;
using Marthada.Domain.Interfaces.Repositories;
using Marthada.Domain.Interfaces.Services.Queries;

namespace Marthada.Api.Services.Products.Queries;

public sealed class ProductQueries : IProductQueries
{
    private readonly IProductRepository _product;

    public ProductQueries (IProductRepository product) => _product = product;

    public async Task<List<Product>> GetAllAsync(CancellationToken cancellationToken) => 
        await _product.GetAllAsync(cancellationToken);

    public async Task<Product?> GetByIdAsync(int id, CancellationToken cancellationToken) =>
        await _product.GetByIdAsync(id, cancellationToken);

    public async Task<Product?> GetByNameAsync(string name, CancellationToken cancellationToken) =>
        await _product.GetByNameAsync(name, cancellationToken);

    
}