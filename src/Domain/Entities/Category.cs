namespace Marthada.Domain.Entities;

public sealed class Category
{
    public int IdCategory { get; private set; }
    public string Name { get; private set; } = null!;
    public ICollection<Product> Products { get; private set; } = null!;

    public static Category Create(string name)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);

        var category = new Category
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