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

  /// <summary>
  /// スケジュールデータ作成
  /// </summary>
  /// <param name="schedule"></param>
  /// <returns></returns>
  /// <exception cref="Exception"></exception>
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

  /// <summary>
  /// スケジュールデータ更新
  /// </summary>
  /// <param name="updateSchedule"></param>
  /// <returns></returns>
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

  /// <summary>
  /// スケジュールデータ削除
  /// </summary>
  /// <param name="scheduleId"></param>
  /// <returns></returns>
  public async Task Delete(uint scheduleId)
  {
    var targetSchedule = await _getById(scheduleId);
    targetSchedule.DeletedAt = Constant.DeletedAt;
    await _dbContext.SaveChangesAsync();
  }

  /// <summary>
  /// 家族のスケジュール情報の一覧を取得
  /// </summary>
  /// <param name="familyId"></param>
  /// <returns></returns>
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

  /// <summary>
  /// スケジュールデータ取得(トラッキングあり)
  /// </summary>
  /// <param name="scheduleId"></param>
  /// <returns></returns>
  /// <exception cref="Exception"></exception>
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