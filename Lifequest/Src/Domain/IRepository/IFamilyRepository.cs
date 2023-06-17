using Lifequest.Src.Domain.Entity;
using Lifequest.Src.Infrastructure.Db;
namespace Lifequest.Src.Domain.IRepository;

public interface IFamilyRepository
{
  Task<Family?> Get(int id);

  Task Create(Family family);
}