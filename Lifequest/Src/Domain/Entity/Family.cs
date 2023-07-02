namespace Lifequest.Src.Domain.Entity;

public class Family
{
  public Family()
  {
  }
  public uint Id {get; private set;}
  public string Name {get; private set;}
  public DateTime DeletedAt {get; private set;}
  public DateTime CreatedAt {get; private set;}
  public DateTime UpdatedAt {get; private set;}

  public List<FamilyMember> FamilyMembers {get; private set;} = new List<FamilyMember>();

  public static Family Create (string name, List<FamilyMember> familyMenber)
  {
    // 家族名が空の場合は例外
    if(string.IsNullOrEmpty(name))
    {
      throw new ArgumentNullException(nameof(name));
    }
    // 家族メンバーがからの場合は例外
    if(familyMenber?.Count <= 0)
    {
      throw new ArgumentException(nameof(familyMenber));
    }
    return new Family
    {
      Name = name,
      FamilyMembers = familyMenber
    };
  }

  //リポジトリからのデータ取得
  public static Family FromRepository(uint id, string name, DateTime deletedAt, DateTime createdAt, DateTime updatedAt)
  {
    return new Family
    {
      Id = id,
      Name = name,
      DeletedAt = deletedAt,
      CreatedAt = createdAt,
      UpdatedAt = updatedAt,
    };
  }
}

//値オブジェクト
public class FamilyMember
{
  public uint UserId {get; set;}

  public uint FamilyId {get; set;}

  public string Position {get; set;}

  public bool IsOwner {get; set;}

  public FamilyMember()
  {
  }

  public static FamilyMember New(uint userId, string position, bool isOwner)
  {
    return new FamilyMember
    {
      UserId = userId,
      Position = position,
      IsOwner = isOwner
    };
  }

  public void AddFamilyId(uint familyId)
  {
    this.FamilyId = familyId;
  }

}