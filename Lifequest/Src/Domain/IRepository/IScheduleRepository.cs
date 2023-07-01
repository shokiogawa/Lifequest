using Lifequest.Src.Domain.Entity;
using Lifequest.Src.Infrastructure.Db;
namespace Lifequest.Src.Domain.IRepository;

public interface IScheduleRepository
{
  Task Create(Schedule schedule);
  Task Update (Schedule updateSchedule);
  Task Delete(uint scheduleId);
}