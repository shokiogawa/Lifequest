namespace Lifequest.Src.Domain.Entity;

public class FixedCost
{
  public FixedCost()
  {
  }
  public uint Id {get; private set;}

  public uint FamilyId {get; private set;}
  public string Name {get; private set;}
  public uint Expose {get; private set;}
  public DateTime DeletedAt {get; private set;}
  public DateTime CreatedAt {get; private set;}
  public DateTime UpdatedAt {get; private set;}


  public static FixedCost New (uint familyId,string name, uint expose)
  {
    if(familyId < 0)
    {
      throw new ArgumentNullException(nameof(familyId));
    }
    // 家族名が空の場合は例外
    if(string.IsNullOrEmpty(name))
    {
      throw new ArgumentNullException(nameof(name));
    }
    if(expose < 0)
    {
      throw new ArgumentNullException(nameof(expose));
    }
    return new FixedCost
    {
      FamilyId = familyId,
      Name = name,
      Expose = expose
    };
  }

  //リポジトリからのデータ取得
  public static FixedCost FromRepository(uint id, uint familyId ,string name, uint expose,DateTime deletedAt, DateTime createdAt, DateTime updatedAt)
  {
    return new FixedCost
    {
      Id = id,
      FamilyId = familyId,
      Name = name,
      Expose = expose,
      DeletedAt = deletedAt,
      CreatedAt = createdAt,
      UpdatedAt = updatedAt,
    };
  }
}