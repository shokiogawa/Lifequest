using Lifequest.Src.Domain.IRepository;
using Lifequest.Src.Domain.Entity;
namespace Lifequest.Src.UseCase.ReadModel;

public class FamilyInfoReadModel
{
  public uint FamilyId {get; set;}
  public string FamilyName {get ;set;} = default!;
  public string Position {get; set;} = default!;

  public bool IsOwner {get; set;}

  public List<FamilyMemberReadModel> FamilyMambers {get; set;} = default!;
}

public class FamilyMemberReadModel 
{
  public uint UserId {get;set;}
  public uint FamilymemberId {get; set;}
  public string Name {get; set;} = default!;
  public string Position {get; set;} = default!;
  public bool IsOwner {get; set;}

}