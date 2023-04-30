using VAGnificent.Models.Models;

namespace VAGnificent.DataAccess.Repository.IRepository;

public interface IDisposalRepository : IRepository<Disposal>
{
    void Update(Disposal disposal);
    void Save();
}