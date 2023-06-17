using Lifequest.Src.Domain.Entity;
using Lifequest.Src.Infrastructure.Db;
namespace Lifequest.Src.Domain.IRepository;

public interface IUserRepository
{
  // string Test(string name, int id);

  Task Create(User user);
}