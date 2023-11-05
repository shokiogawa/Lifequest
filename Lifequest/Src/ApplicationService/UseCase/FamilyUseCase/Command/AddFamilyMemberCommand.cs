namespace Lifequest.Src.ApplicationService.UseCase.FamilyUseCase.Command;

public class AddFamilyMemberCommand
{
  public uint UserId {get; set;}

  public uint FamilyId {get; set;}

  public string Position {get; set;}

  public bool IsOwner {get; set;}
}