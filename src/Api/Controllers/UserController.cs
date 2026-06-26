using Marthada.Domain.DTOs.Requests;
using Marthada.Domain.DTOs.Responses;
using Marthada.Domain.Interfaces.Services.Commands;
using Microsoft.AspNetCore.Mvc;

namespace Marthada.Api.Controllers;

[ApiController]
[Route("auth")]
public sealed class UserController : ControllerBase
{
    private readonly IUserCommands _auth;

    public UserController(IUserCommands auth) => _auth = auth;

    [HttpPost("login")]
    [ProducesResponseType(typeof(AuthResponse), 200)]
    [ProducesResponseType(401)]
    public async Task<IActionResult> Login(
        [FromBody] LoginRequest request,
        CancellationToken ct
    )
    {
        var result = await _auth.AuthAsync(request, ct);

        if (result is null)
        {
            return Unauthorized("Usuário ou senha inválidos.");
        }

        return Ok(result);
    }

    [HttpPost("users")]
    [ProducesResponseType(typeof(AuthResponse), 200)]
    [ProducesResponseType(401)]
    public async Task<IActionResult> CreateUser(
        CancellationToken ct
    )
    {
        var newPass = BCrypt.Net.BCrypt.HashPassword("Testando#1234");
        Console.WriteLine(newPass);
        return Ok();
    }
}