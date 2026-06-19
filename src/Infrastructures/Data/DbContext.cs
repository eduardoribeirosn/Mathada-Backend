using Marthada.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Marthada.Infrastructures.Data;

public class MarthadaDbContext : DbContext
{
    public MarthadaDbContext(DbContextOptions<MarthadaDbContext> options) : base(options)
    {
        
    }

    public DbSet<Users> Users { get; private set; }
    public DbSet<Products> Products { get; private set; }
    public DbSet<Categories> Categories { get; private set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MarthadaDbContext).Assembly);
        
        base.OnModelCreating(modelBuilder);
    }
}