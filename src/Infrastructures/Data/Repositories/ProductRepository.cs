using Marthada.Domain.Entities;
using Marthada.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Marthada.Infrastructures.Data.Repositories;

public sealed class ProductRepository : IProductRepository
{
    private readonly MarthadaDbContext _context;

    public ProductRepository(MarthadaDbContext context) => _context = context;

    public async Task<List<Product>> GetAllAsync(CancellationToken cancellationToken = default) => 
        await _context.Products.ToListAsync(cancellationToken);

    public async Task<Product?> GetByIdAsync(int id, CancellationToken cancellationToken = default) =>
        await _context.Products.FirstOrDefaultAsync(p => p.IdProduct == id, cancellationToken);

    public async Task<Product?> GetByNameAsync(string name, CancellationToken cancellationToken = default) =>
        await _context.Products.FirstOrDefaultAsync(p => p.Name == name, cancellationToken);

    public async Task CreateAsync(Product product, CancellationToken cancellationToken = default)
    {
        await _context.Products.AddAsync(product, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        // await _unitOfWork.SaveChangesAsync(); Esse é para salvar mais de uma alteração por vez
    }

    public async Task Update(Product product, CancellationToken cancellationToken = default)
    {
        _context.Products.Update(product);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task Delete(Product product, CancellationToken cancellationToken = default)
    {
        _context.Products.Remove(product);
        await _context.SaveChangesAsync(cancellationToken);
    }
}