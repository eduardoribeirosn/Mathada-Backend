using Marthada.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Marthada.Infrastructures.Data.Mappings;

public sealed class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");
        builder.HasKey(p => p.IdProduct);
        builder.Property(p => p.IdProduct).ValueGeneratedOnAdd();

        builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
        builder.Property(p => p.Description).IsRequired().HasMaxLength(500);
        builder.Property(p => p.Price).IsRequired().HasPrecision(10, 2);
        builder.Property(p => p.PromotionalPrice).IsRequired().HasPrecision(10, 2);
        builder.Property(p => p.Image).IsRequired().HasMaxLength(255);
        builder.Property(p => p.IsActive).IsRequired();
        builder.Property(p => p.PromotionalIsActive).IsRequired();

        builder.HasOne(p => p.Category).WithMany(c => c.Products).HasForeignKey(p => p.FkCategory).IsRequired();

        builder.HasIndex(p => p.Name).IsUnique();
    }
}