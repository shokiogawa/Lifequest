namespace Lifequest.Src.ApplicationService.UseCase.ScheduleUseCase.Query;

public class FetchScheduleByFamilyIdDto
{
  public uint Id {get; set;}
  public uint FamilyId {get; set;}
  public string Title {get; set;} = default!;
  public string Content {get; set;} = default!;
  public DateTime StartDateTime {get; set;} = default!;
  public DateTime EndDateTime {get; set;} = default!;
  public bool IsAllDayFlag {get; set;}
  public uint CreatedUserId {get; set;}
  public DateTime DeletedAt {get; set;}
  public DateTime CreatedAt {get; set;}
  public DateTime UpdatedAt {get; set;}
}