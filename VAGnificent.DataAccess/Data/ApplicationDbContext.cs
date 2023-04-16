using Microsoft.EntityFrameworkCore;
using VAGnificent.Models;

namespace VAGnificent.DataAccess;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Brand>().HasData(
            new Brand { Id = 1, BrandName = "Lamborghini", CEO = "Stefan Vinkelman"});
    }
    public DbSet<Brand> Brands { get; set; }
}