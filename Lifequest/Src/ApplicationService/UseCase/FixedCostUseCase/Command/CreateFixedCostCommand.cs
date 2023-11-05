namespace Lifequest.Src.ApplicationService.UseCase.FixedCostUseCase.Command;

public class CreateFixedCostCommand
{
  public uint FamilyId {get; set;}

  public string Name {get; set;}

  public uint Expose {get; set;} 
}