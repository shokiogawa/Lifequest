namespace Lifequest.Src.ApplicationService.Query;
public interface IFamilyQueryService
{
  Task<List<FamilyInfoDto>> GetList(string uuid);
}

// 参照用モデル
public class FamilyInfoDto
{
  public uint FamilyId {get; set;}
  public string FamilyName {get ;set;} = default!;
  public string Position {get; set;} = default!;

  public bool IsOwner {get; set;}

  public List<FamilyMemberDto> FamilyMambers {get; set;} = default!;
}

public class FamilyMemberDto
{
  public uint UserId {get;set;}
  public uint FamilymemberId {get; set;}
  public string Name {get; set;} = default!;
  public string Position {get; set;} = default!;
  public bool IsOwner {get; set;}

}