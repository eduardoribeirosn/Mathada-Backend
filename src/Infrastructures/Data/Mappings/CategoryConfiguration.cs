using Marthada.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Marthada.Infrastructures.Data.Mappings;

public sealed class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Categories");
        builder.HasKey(c => c.IdCategory);
        builder.Property(c => c.IdCategory).ValueGeneratedOnAdd();

        builder.Property(c => c.Name).IsRequired().HasMaxLength(100);

        builder.HasIndex(c => c.Name).IsUnique();
    }
}