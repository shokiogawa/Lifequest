using Lifequest.Src.Domain.Entity;
using Lifequest.Src.Infrastructure.Db;
namespace Lifequest.Src.Domain.IRepository;

public interface IScheduleRepository
{

  /// <summary>
  /// スケジュールデータ作成
  /// </summary>
  /// <param name="schedule"></param>
  /// <returns></returns>
  Task Create(Schedule schedule);

  /// <summary>
  /// スケジュールデータ更新
  /// </summary>
  /// <param name="updateSchedule"></param>
  /// <returns></returns>
  Task Update (Schedule updateSchedule);

  /// <summary>
  /// スケジュールデータ削除
  /// </summary>
  /// <param name="scheduleId"></param>
  /// <returns></returns>
  Task Delete(uint scheduleId);

  /// <summary>
  /// 家族のスケジュール情報の一覧を取得
  /// </summary>
  /// <param name="familyId"></param>
  /// <returns></returns>
  Task<List<Schedule>> GetListByFamilyId(uint familyId);
}