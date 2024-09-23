using Microsoft.EntityFrameworkCore;


namespace pmd_be.Models;

public class PmdDbContext : DbContext
{
    public PmdDbContext(DbContextOptions<PmdDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

    public virtual DbSet<Product> Products { get; set; } = null!;
}


