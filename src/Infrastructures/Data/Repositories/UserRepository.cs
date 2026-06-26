using Marthada.Domain.DTOs.Requests;
using Marthada.Domain.Entities;
using Marthada.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Marthada.Infrastructures.Data.Repositories;

public sealed class UserRepository : IUserRepository
{
    private readonly MarthadaDbContext _context;

    public UserRepository(MarthadaDbContext context) => _context = context;

    public async Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default) =>
        await _context.Users.FirstOrDefaultAsync(u => u.Email == email, cancellationToken);
}