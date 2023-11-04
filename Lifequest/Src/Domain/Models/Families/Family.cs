namespace Lifequest.Src.Domain.Models.Families;

public class Family
{
  private Family()
  {
  }
  public uint Id {get; private set;}
  public string Name {get; private set;}
  public DateTime DeletedAt {get; private set;}
  public DateTime CreatedAt {get; private set;}
  public DateTime UpdatedAt {get; private set;}

  public List<FamilyMember> FamilyMembers {get; private set;} = new List<FamilyMember>();

  public static Family Create (string name)
  {
    // 家族名が空の場合は例外
    if(string.IsNullOrEmpty(name))
    {
      throw new ArgumentNullException(nameof(name));
    }
    return new Family
    {
      Name = name,
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