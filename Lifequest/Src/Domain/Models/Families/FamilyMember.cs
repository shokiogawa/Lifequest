namespace Lifequest.Src.Domain.Models.Families;

public class FamilyMember
{
  public uint UserId {get; set;}

  public uint FamilyId {get; set;}

  public string Position {get; set;}

  public bool IsOwner {get; set;}

  /// <summary>
  /// コンストラクタは内部で行う。
  /// </summary>
  private FamilyMember()
  {
  }

  /// <summary>
  /// 生成メソッド
  /// </summary>
  /// <param name="userId"></param>
  /// <param name="familyId"></param>
  /// <param name="position"></param>
  /// <param name="isOwner"></param>
  /// <returns></returns>
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