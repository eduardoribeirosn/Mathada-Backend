namespace Marthada.Domain.Entities;

public sealed class Users
{
    public int IdUser { get; private set; }
    public string Name { get; private set; } = null!;
    public string Email { get; private set; } = null!;
    public string PasswordHash { get; private set; } = null!;
    public DateTimeOffset CreatedAt { get; private set; }

    private Users () { }

    public static Users Create(string name, string email, string passwordHash)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentException.ThrowIfNullOrWhiteSpace(email);
        ArgumentException.ThrowIfNullOrWhiteSpace(passwordHash);

        var user = new Users
        {
            Name = name,
            Email = email,
            PasswordHash = passwordHash,
            CreatedAt = DateTimeOffset.UtcNow
        };

        return user;
    }

    public void Update(string name, string email, string passwordHash)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentException.ThrowIfNullOrWhiteSpace(email);
        ArgumentException.ThrowIfNullOrWhiteSpace(passwordHash);
        
        Name = name;
        Email = email;
        PasswordHash = passwordHash;
    }
}