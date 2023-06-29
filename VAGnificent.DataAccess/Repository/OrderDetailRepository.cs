using VAGnificent.Models.Models;

namespace VAGnificent.DataAccess.Repository.IRepository;

public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailRepository
{
    private readonly ApplicationDbContext _db;

    public OrderDetailRepository(ApplicationDbContext db) : base(db)
    {
        _db = db;
    }

    public void Update(OrderDetail orderDetail)
    {
        _db.Update(orderDetail);
    }

    public void Save()
    {
        _db.SaveChanges();
    }
}