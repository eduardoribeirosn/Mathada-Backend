using Marthada.Domain.DTOs.Requests;
using Marthada.Domain.Entities;

namespace Marthada.Domain.Interfaces.Repositories;

public interface IUserRepository
{
    Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default);
}