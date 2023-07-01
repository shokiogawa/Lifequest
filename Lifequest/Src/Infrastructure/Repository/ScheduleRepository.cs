using Lifequest.Src.Domain.Entity;
using Lifequest.Src.Infrastructure.Db;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Lifequest.Src.Infrastructure.Db.Tables;
using Lifequest.Src.Domain.IRepository;
namespace Lifequest.Src.Infrastructure.Repository;

public class ScheduleRepository : IScheduleRepository
{
  private readonly LifequestDbContext _dbContext;
  private readonly IMapper _mapper;

  public ScheduleRepository(LifequestDbContext dbContext, IMapper mapper)
  {
    _dbContext = dbContext;
    _mapper = mapper;
  }

  /**
  Scheduleデータを作成する
  **/
  public async Task Create(Schedule schedule)
  {
    var scheduleData = _mapper.Map<ScheduleTable>(schedule);
    await _dbContext.ScheduleTable.AddAsync(scheduleData);
    var result = await _dbContext.SaveChangesAsync();
    if(result <= 0)
    {
      throw new Exception("unable to create schedule");
    }
  }

  /**
  Scheduleデータを更新する。
  **/
  public async Task Update (Schedule updateSchedule)
  {
    try
    {
      var currentScheduleData = await _getById(updateSchedule.Id);
      currentScheduleData.Title = updateSchedule.Title;
      currentScheduleData.Content = updateSchedule.Content;
      currentScheduleData.StartDateTime = updateSchedule.StartDateTime;
      currentScheduleData.EndDateTime = updateSchedule.EndDateTime;
      currentScheduleData.IsAllDayFlag = updateSchedule.IsAllDayFlag;
      var resultRow = await _dbContext.SaveChangesAsync();
      if(resultRow <= 0)
      {
        throw new Exception("schedule can not updated");
      }
    } catch(Exception e)
    {
      throw e;
    }
  }

  /**
  Scheduleデータを削除
  **/
  public async Task Delete(uint scheduleId)
  {
    var targetSchedule = await _getById(scheduleId);
    targetSchedule.DeletedAt = Constant.DeletedAt;
    await _dbContext.SaveChangesAsync();
  }

  /**
  ScheduleTabデータを取得 (repository内でしか使用しないこと)
  **/
  private async Task<ScheduleTable> _getById(uint scheduleId)
  {
    var targetSchedule = await _dbContext.ScheduleTable.Where(_ => _.Id == scheduleId).FirstOrDefaultAsync();
    if(targetSchedule == null)
    {
      throw new Exception("delete target schedule is not exist");
    }
    return targetSchedule;
  }
}