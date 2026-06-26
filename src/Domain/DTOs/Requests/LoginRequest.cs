namespace Marthada.Domain.DTOs.Requests;

public sealed record LoginRequest (
    string Email,
    string Password
);