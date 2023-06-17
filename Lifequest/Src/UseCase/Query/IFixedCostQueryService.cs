using Lifequest.Src.Domain.IRepository;
using Lifequest.Src.Domain.Entity;
namespace Lifequest.Src.UseCase.Query;

public interface IFixedCostQueryService
{
  Task<List<FixedCost>> GetByFamilyId(int familyId);

  // Task GetBankHistories(uint bankId);
}