using Microsoft.EntityFrameworkCore;
using VAGnificent.Models.Models;

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

        // modelBuilder.Entity<Disposal>().HasData(
        //     new Disposal
        //     {
        //         Id = 1,
        //         BrandId = 5,
        //         Model = "911 922 Turbo",
        //         BrandCountry = "Germany",
        //         Colour = "White",
        //         FuelType = "Gazoline",
        //         Weight = 1300,
        //         HorsePower = 420,
        //         EngineCapacity = 3000,
        //         TransmisionType = "Robo",
        //         Year = new DateTime(2021),
        //         DollarsPrice = 100000,
        //         Accidents = false,
        //         TravelledDistance = 1000,
        //     });
    }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Disposal> Disposals { get; set; }
}