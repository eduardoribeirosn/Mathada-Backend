using Marthada.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Marthada.Infrastructures.Data.Mappings;

public sealed class UserConfiguration : IEntityTypeConfiguration<Users>
{
    public void Configure (EntityTypeBuilder<Users> builder)
    {
        builder.ToTable("Users");
        builder.HasKey(u => u.IdUser);
        builder.Property(u => u.IdUser).ValueGeneratedOnAdd();

        builder.Property(u => u.Name).IsRequired().HasMaxLength(100);
        builder.Property(u => u.Email).IsRequired().HasMaxLength(255);
        builder.Property(u => u.PasswordHash).IsRequired().HasMaxLength(255);

        builder.Property(u => u.CreatedAt).IsRequired().HasColumnType("datetime");
    }
}