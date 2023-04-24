using VAGnificent.Models.Models;

namespace VAGnificent.DataAccess.Repository.IRepository;

public interface IBrandRepository : IRepository<Brand>
{
    void Update(Brand brand);
    void Save();
}