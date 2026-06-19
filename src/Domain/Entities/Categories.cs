namespace Marthada.Domain.Entities;

public sealed class Categories
{
    public int IdCategory { get; private set; }
    public string Name { get; private set; } = null!;
    public ICollection<Products> Products { get; private set; } = null!;

    public static Categories Create(string name)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);

        var category = new Categories
        {
            Name = name
        };

        return category;
    }

    public void Update(string name)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);

        Name = name;
    }
}