using Lifequest.Src.Domain.IRepository;
using Lifequest.Src.Domain.Entity;
namespace Lifequest.Src.UseCase.Query;

public interface IScheduleQueryService
{
  Task<List<Schedule>> GetListByFamilyId(uint familyId);
}
