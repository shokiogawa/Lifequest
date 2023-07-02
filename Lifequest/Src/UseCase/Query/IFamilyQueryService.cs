using Lifequest.Src.Domain.IRepository;
using Lifequest.Src.Domain.Entity;
using Lifequest.Src.UseCase.ReadModel;
namespace Lifequest.Src.UseCase.Query;

public interface IFamilyQueryService
{
  Task<List<FamilyInfoReadModel>> GetList(string uuid);

  // Task GetBankHistories(uint bankId);
}