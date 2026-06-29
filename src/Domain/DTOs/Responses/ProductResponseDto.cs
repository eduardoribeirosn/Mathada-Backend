namespace Marthada.Domain.DTOs.Products;

public sealed record ProductResponseDto (
    int IdProduct,
    string Name,
    string Description,
    decimal Price,
    decimal PromotionalPrice,
    string Image,
    bool IsActive,
    bool PromotionalIsActive
);