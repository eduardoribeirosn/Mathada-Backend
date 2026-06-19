namespace Marthada.Domain.Entities;

public sealed class User
{
    public int IdUser { get; private set; }
    public string Name { get; private set; } = null!;
    public string Email { get; private set; } = null!;
    public string PasswordHash { get; private set; } = null!;
    public DateTimeOffset CreatedAt { get; private set; }

    private User () { }

    public static User Create(string name, string email, string passwordHash)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentException.ThrowIfNullOrWhiteSpace(email);
        ArgumentException.ThrowIfNullOrWhiteSpace(passwordHash);

        var user = new User
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