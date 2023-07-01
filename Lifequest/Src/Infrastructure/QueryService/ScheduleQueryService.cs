using Lifequest.Src.Domain.Entity;
using Lifequest.Src.Infrastructure.Db;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Lifequest.Src.Domain.IRepository;
using Lifequest.Src.Infrastructure.Db.Tables;
using Lifequest.Src;
using Lifequest.Src.UseCase.Query;
namespace Lifequest.Src.Infrastructure.Repository;

public class ScheduleQueryService : IScheduleQueryService
{
  private readonly LifequestDbContext _dbContext;
  private readonly IMapper _mapper;
  public ScheduleQueryService(LifequestDbContext dbContext, IMapper mapper)
  {
    _dbContext = dbContext;
    _mapper = mapper;
  }

  public async Task<List<Schedule>> GetListByFamilyId(uint familyId)
  {
    var query = from schedule in _dbContext.ScheduleTable 
    where schedule.FamilyId == familyId && 
          schedule.DeletedAt == Constant.DeletedAt 
    orderby schedule.CreatedAt descending
    select schedule;
    var scheduleDataList = await query.ToListAsync();
    var scheduleList = scheduleDataList.Select(_ => 
    Schedule.FromRepository(
      _.Id, 
      _.FamilyId, 
      _.Title, 
      _.Content, 
      _.StartDateTime, 
      _.EndDateTime, 
      _.IsAllDayFlag, 
      _.CreatedUserId, 
      _.DeletedAt, 
      _.CreatedAt, 
      _.UpdatedAt)
    ).ToList();
    return scheduleList;
  }
}