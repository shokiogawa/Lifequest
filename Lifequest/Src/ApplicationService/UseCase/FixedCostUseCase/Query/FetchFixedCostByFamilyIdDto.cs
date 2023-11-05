namespace Lifequest.Src.ApplicationService.UseCase.FixedCostUseCase.Query;

public class FetchFixedCostByFamilyIdDto
{
  public uint Id {get; set;}

  public uint FamilyId {get; set;}
  public string Name {get; set;}
  public uint Expose {get; set;}
  public DateTime DeletedAt {get; set;}
  public DateTime CreatedAt {get; set;}
  public DateTime UpdatedAt {get; set;}
}