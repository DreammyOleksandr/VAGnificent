using VAGnificent.Models.Models;

namespace VAGnificent.DataAccess.Repository.IRepository;

public class DisposalRepository : Repository<Disposal>, IDisposalRepository
{
    private ApplicationDbContext _db;
    
    public DisposalRepository(ApplicationDbContext db) : base(db)
    {
        _db = db;
    }

    public void Update(Disposal disposal)
    {
        _db.Disposals.Update(disposal);
    }

    public void Save()
    {
        _db.SaveChanges();
    }
}