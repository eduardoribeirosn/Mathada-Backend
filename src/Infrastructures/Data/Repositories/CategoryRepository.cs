using Marthada.Domain.Entities;
using Marthada.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Marthada.Infrastructures.Data.Repositories;

public sealed class CategoryRepository : ICategoryRepository
{
    private readonly MarthadaDbContext _context;

    public CategoryRepository(MarthadaDbContext context) => _context = context;

    public async Task<List<Category>> GetAllAsync(CancellationToken cancellationToken = default) =>
        await _context.Categories.ToListAsync(cancellationToken);

    public async Task<Category?> GetByIdAsync(int id, CancellationToken cancellationToken = default) =>
        await _context.Categories.FirstOrDefaultAsync(c => c.IdCategory == id ,cancellationToken);
    public async Task<Category?> GetByNameAsync(string name, CancellationToken cancellationToken = default) =>
        await _context.Categories.FirstOrDefaultAsync(c => c.Name == name ,cancellationToken);
        
    public async Task CreateAsync(Category category, CancellationToken cancellationToken = default)
    {
        await _context.Categories.AddAsync(category, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        // await _unitOfWork.SaveChangesAsync(); Esse é para salvar mais de uma alteração por vez
    }

    public async Task Update(Category category, CancellationToken cancellationToken = default)
    {
        _context.Categories.Update(category);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task Delete(Category category, CancellationToken cancellationToken = default)
    {
        _context.Categories.Remove(category);
        await _context.SaveChangesAsync(cancellationToken);
    }
}