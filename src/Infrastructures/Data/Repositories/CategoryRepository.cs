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
}