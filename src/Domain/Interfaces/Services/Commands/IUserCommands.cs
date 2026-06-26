using Marthada.Domain.DTOs.Requests;
using Marthada.Domain.DTOs.Responses;

namespace Marthada.Domain.Interfaces.Services.Commands;

public interface IUserCommands {
    Task<AuthResponse?> AuthAsync(LoginRequest request, CancellationToken cancellationToken);
}