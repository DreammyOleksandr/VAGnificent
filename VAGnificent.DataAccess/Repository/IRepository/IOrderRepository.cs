using VAGnificent.Models.Models;

namespace VAGnificent.DataAccess.Repository.IRepository;

public interface IOrderRepository : IRepository<Order>{
    void Update(Order order);
    void Save();
}