using Lifequest.Src.Domain.Entity;
using Lifequest.Src.Infrastructure.Db;
namespace Lifequest.Src.Domain.IRepository;

public interface IFixedCostRepository
{
  Task Create(FixedCost fixedCost);
}