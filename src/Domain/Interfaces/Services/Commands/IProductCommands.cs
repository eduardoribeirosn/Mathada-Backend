using Marthada.Domain.DTOs.Requests;
using Marthada.Domain.Entities;

namespace Marthada.Domain.Interfaces.Services.Commands;

public interface IProductCommands
{
    Task<Product?> CreateAsync(CreateProductRequest request, CancellationToken cancellationToken);
    Task<Product?> Update(int id, UpdateProductRequest request, CancellationToken cancellationToken);
    Task<bool> Delete(int id, CancellationToken cancellationToken);
}