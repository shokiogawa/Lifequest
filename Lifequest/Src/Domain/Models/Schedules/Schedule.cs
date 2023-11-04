namespace Lifequest.Src.Domain.Models.Schedules;

public class Schedule
{
  public uint Id {get; private set;}
  public uint FamilyId {get; private set;}
  public string Title {get; private set;}
  public string Content {get; private set;}
  public DateTime StartDateTime {get; private set;}
  public DateTime EndDateTime {get; private set;}
  public bool IsAllDayFlag {get; private set;}
  public uint CreatedUserId {get; private set;}
  public DateTime DeletedAt {get; private set;}
  public DateTime CreatedAt {get; private set;}
  public DateTime UpdatedAt {get; private set;}
  
  /// <summary>
  /// 初回作成コンストラクタ
  /// </summary>
  /// <param name="familyId"></param>
  /// <param name="title"></param>
  /// <param name="content"></param>
  /// <param name="startDateTime"></param>
  /// <param name="endDateTime"></param>
  /// <param name="isAllDayFlag"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  public static Schedule Create(uint familyId, string title, string content, DateTime startDateTime, DateTime endDateTime, bool isAllDayFlag)
  {
    if(string.IsNullOrEmpty(title))
    {
      throw new ArgumentNullException(nameof(title));
    }
    if(string.IsNullOrEmpty(content))
    {
      throw new ArgumentNullException(nameof(content));
    }
    if(string.IsNullOrEmpty(nameof(startDateTime)) && string.IsNullOrEmpty(nameof(endDateTime)) && isAllDayFlag == false)
    {
      throw new ArgumentException($"{nameof(startDateTime)}と、{nameof(endDateTime)}が未指定にかかわらず、{nameof(isAllDayFlag)}がfalseです。",nameof(isAllDayFlag));
    }
    return new Schedule
    {
      FamilyId = familyId,
      Title = title,
      Content = content,
      StartDateTime = startDateTime,
      EndDateTime = endDateTime,
      IsAllDayFlag = isAllDayFlag
    };
  }

  /// <summary>
  /// 再構成コンストラクタ
  /// </summary>
  /// <param name="id"></param>
  /// <param name="familyId"></param>
  /// <param name="title"></param>
  /// <param name="content"></param>
  /// <param name="startDateTime"></param>
  /// <param name="endDateTime"></param>
  /// <param name="isAllDayFlag"></param>
  /// <param name="createdUserId"></param>
  /// <param name="deletedAt"></param>
  /// <param name="createdAt"></param>
  /// <param name="updatedAt"></param>
  /// <returns></returns>
  public static Schedule FromRepository(uint id,uint familyId, string title, string content, DateTime startDateTime, DateTime endDateTime, bool isAllDayFlag, uint createdUserId, DateTime deletedAt, DateTime createdAt, DateTime updatedAt)
  {
    return new Schedule
    {
      Id = id,
      FamilyId = familyId,
      Title = title,
      Content = content,
      StartDateTime = startDateTime,
      EndDateTime = endDateTime,
      IsAllDayFlag = isAllDayFlag,
      CreatedUserId = createdUserId,
      DeletedAt = deletedAt,
      UpdatedAt = updatedAt,
      CreatedAt = createdAt
    };
  }

  /// <summary>
  /// 内部使用にとどめる
  /// </summary>
  private Schedule()
  {
  }
}