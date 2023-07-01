namespace Lifequest.Src.Domain.Entity;

public class Schedule
{
  public Schedule()
  {
  }

  public static Schedule New(uint familyId, string title, string content, DateTime startDateTime, DateTime endDateTime, bool isAllDayFlag)
  {
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
}