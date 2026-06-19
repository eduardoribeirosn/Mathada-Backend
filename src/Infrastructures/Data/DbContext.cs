using Marthada.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Marthada.Infrastructures.Data;

public class MarthadaDbContext : DbContext
{
    public MarthadaDbContext(DbContextOptions<MarthadaDbContext> options) : base(options)
    {
        
    }

    public DbSet<User> Users { get; private set; }
    public DbSet<Product> Products { get; private set; }
    public DbSet<Category> Categories { get; private set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MarthadaDbContext).Assembly);
        
        base.OnModelCreating(modelBuilder);
    }
}