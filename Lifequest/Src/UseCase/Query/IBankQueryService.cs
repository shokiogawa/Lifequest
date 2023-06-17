using Lifequest.Src.Domain.IRepository;
using Lifequest.Src.Domain.Entity;
namespace Lifequest.Src.UseCase.Query;

public interface IBankQueryService
{
  Task<List<Bank>> GetListByFamilyId(uint familyId);

  // Task GetBankHistories(uint bankId);
}