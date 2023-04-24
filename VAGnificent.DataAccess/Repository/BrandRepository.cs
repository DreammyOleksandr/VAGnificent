using VAGnificent.Models.Models;

namespace VAGnificent.DataAccess.Repository.IRepository;

public class BrandRepository : Repository<Brand>, IBrandRepository
{
    private readonly ApplicationDbContext _db;

    public BrandRepository(ApplicationDbContext db) : base(db)
    {
        _db = db;
    }

    public void Update(Brand brand)
    {
        _db.Update(brand);
    }

    public void Save()
    {
        _db.SaveChanges();
    }
}