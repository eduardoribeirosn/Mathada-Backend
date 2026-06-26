namespace Marthada.Domain.DTOs.Responses;

public sealed record AuthResponse (
    int IdUser,
    string Name,
    string Email
);  