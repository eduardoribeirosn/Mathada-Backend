using Marthada.Domain.DTOs.Requests;
using Marthada.Domain.DTOs.Responses;
using Marthada.Domain.Interfaces.Repositories;
using Marthada.Domain.Interfaces.Services.Commands;

namespace Marthada.Api.Services.Users.Commands;

public sealed class UserCommands : IUserCommands
{
    private readonly IUserRepository _userRepository;

    public UserCommands(IUserRepository userRepository) => _userRepository = userRepository;

    public async Task<AuthResponse?> AuthAsync(LoginRequest request, CancellationToken cancellationToken)
    {
        
        var user = await _userRepository.GetByEmailAsync(request.Email, cancellationToken);

        if (user is null)
        {
            return null;
        }

        var passwordValid = BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash);

        if (!passwordValid)
        {
            // Erro - Retornar erro
            Console.WriteLine("Login incorreto.");
            // return false;
            return null;
        } 
        
        // Sucesso - Gerar JWT
        Console.WriteLine("Login correto.");
        return new AuthResponse
        (
            IdUser: user.IdUser,
            Name: user.Name,
            Email: user.Email
        );
    }
}