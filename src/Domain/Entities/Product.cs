using System.Dynamic;

namespace Marthada.Domain.Entities;

public sealed class Product
{
    public int IdProduct { get; private set; }
    public string Name { get; private set; } = null!;
    public string Description { get; private set; } = null!;
    public decimal Price { get; private set; }
    public decimal PromotionalPrice { get; private set; }
    public string Image { get; private set; } = null!;
    public bool IsActive { get; private set; }
    public bool PromotionalIsActive { get; private set; }
    public Category Category { get; private set; } = null!;
    public int FkCategory { get; private set; }

    public static Product Create(string name, string description, decimal price, string image, int fkCategory, decimal promotionalPrice = 0)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentException.ThrowIfNullOrWhiteSpace(description);
        ArgumentException.ThrowIfNullOrWhiteSpace(image);

        var product = new Product
        {
            Name = name,
            Description = description,
            Price = price,
            PromotionalPrice = promotionalPrice,
            Image = image,
            IsActive = true,
            PromotionalIsActive = promotionalPrice != 0,
            FkCategory = fkCategory
        };

        return product;
    }

    public void Update(string name, string description, decimal price, string image, bool isActive, int fkCategory, decimal promotionalPrice = 0)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentException.ThrowIfNullOrWhiteSpace(description);
        ArgumentException.ThrowIfNullOrWhiteSpace(image);

        Name = name;
        Description = description;
        Price = price;
        PromotionalPrice = promotionalPrice;
        Image = image;
        IsActive = isActive;
        PromotionalIsActive = promotionalPrice != 0;
        FkCategory = fkCategory;
    }
}