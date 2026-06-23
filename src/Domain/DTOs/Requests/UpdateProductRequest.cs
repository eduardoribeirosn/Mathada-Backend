namespace Marthada.Domain.DTOs.Requests;

public sealed record UpdateProductRequest (
    string Name,
    string Description,
    decimal Price,
    string Image,
    decimal PromotionalPrice,
    int FkCategory
);