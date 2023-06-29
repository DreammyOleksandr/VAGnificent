using VAGnificent.Models.Models;

namespace VAGnificent.DataAccess.Repository.IRepository;

public class OrderRepository : Repository<Order>, IOrderRepository
{
    private readonly ApplicationDbContext _db;

    public OrderRepository(ApplicationDbContext db) : base(db)
    {
        _db = db;
    }

    public void Update(Order order)
    {
        _db.Update(order);
    }

    public void Save()
    {
        _db.SaveChanges();
    }
}