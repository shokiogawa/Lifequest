namespace Lifequest.Src.ApplicationService.UseCase.FamilyUseCase.Command;

public class CreateFamilyCommand
{
  public uint Id {get; set;}

  public string Name {get; set;} = default!;

  public List<CreateFamilyMemberCommand> FamilyMembers {get; set;} = new List<CreateFamilyMemberCommand>();
}

public class CreateFamilyMemberCommand
{
  public uint UserId {get; set;}

  public uint FamilyId {get; set;}

  public bool IsOwner {get; set;}

  public string Position {get; set;} = default!;
  public DateTime DeletedAt {get; set;}
  public DateTime CreatedAt {get; set;}
  public DateTime UpdatedAt {get; set;}
}