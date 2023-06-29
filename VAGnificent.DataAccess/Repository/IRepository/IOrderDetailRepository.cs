using VAGnificent.Models.Models;

namespace VAGnificent.DataAccess.Repository.IRepository;

public interface IOrderDetailRepository : IRepository<OrderDetail>
{
    void Update(OrderDetail orderDetail);
    void Save();
}