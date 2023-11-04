namespace Lifequest.Src.Domain.Models.Families;

public class FamilyMember
{
  public uint UserId {get; set;}

  public uint FamilyId {get; set;}

  public string Position {get; set;}

  public bool IsOwner {get; set;}

  private FamilyMember()
  {
  }

  public static FamilyMember Create(uint userId, uint familyId,string position, bool isOwner)
  {
    return new FamilyMember
    {
      UserId = userId,
      FamilyId = familyId,
      Position = position,
      IsOwner = isOwner
    };
  }

}