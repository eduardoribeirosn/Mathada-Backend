using Marthada.Domain.DTOs.Requests;
using Marthada.Domain.Entities;
using Marthada.Domain.Interfaces.Repositories;
using Marthada.Domain.Interfaces.Services.Commands;

namespace Marthada.Api.Services.Products.Commands;

public sealed class ProductCommands : IProductCommands
{
    private readonly IProductRepository _product;

    public ProductCommands (IProductRepository product) => _product = product;

    public async Task<Product?> CreateAsync(CreateProductRequest request, CancellationToken cancellationToken) {
        var exists = await _product.GetByNameAsync(request.Name, cancellationToken);

        if (exists != null)
        {
            return null;
        }

        var product = Product.Create(
            request.Name, 
            request.Description, 
            request.Price, 
            request.Image, 
            request.FkCategory, 
            request.PromotionalPrice);
            
        await _product.CreateAsync(product, cancellationToken);

        // var productCreated = await _product.GetByNameAsync(request.Name, cancellationToken);

        return product;
    }

    public async Task<Product?> Update(int id, UpdateProductRequest request, CancellationToken cancellationToken)
    {
        var exists = await _product.GetByIdAsync(id, cancellationToken);

        if (exists == null)
        {
            return null;
        }

        exists.Update(
            request.Name, 
            request.Description, 
            request.Price, 
            request.Image, 
            request.FkCategory,
            request.PromotionalPrice
        );

        await _product.Update(exists, cancellationToken);

        return exists;
    }

    public async Task<bool> Delete(int id, CancellationToken cancellationToken)
    {
        Console.WriteLine("Aquii");
        var exists = await _product.GetByIdAsync(id, cancellationToken);

        if (exists == null)
        {
            return false;
        }

        await _product.Delete(exists, cancellationToken);

        return true;
    }

    
}