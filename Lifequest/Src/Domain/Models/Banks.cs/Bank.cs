namespace Lifequest.Src.Domain.Models.Banks;

public class Bank 
{
  public uint Id {get; private set;}

  public uint FamilyId {get; private set;}

  public uint FamilymemberId {get; private set;}
  public string Name {get; private set;}
  public string Code {get; private set;} = "";

  public ushort BranchNumber {get ; private set;}

  public string BranchName {get; private set;} = "";
  public uint AccountNumber {get; private set;}
  public uint TotalAmount {get; private set;}
  public DateTime DeletedAt {get; private set;}
  public DateTime CreatedAt {get; private set;}
  public DateTime UpdatedAt {get; private set;}

  /// <summary>
  /// 合計貯金額を変更
  /// </summary>
  /// <param name="totalAmount"></param>
  /// <exception cref="ArgumentException"></exception>
  public void ChangeTotalAmount (uint totalAmount)
  {
    if(totalAmount < 0)
    {
      throw new ArgumentException(nameof(totalAmount));
    };
   TotalAmount = totalAmount;
  }

  /// <summary>
  /// 生成用コンストラクタ
  /// </summary>
  /// <param name="familyId"></param>
  /// <param name="familymemberId"></param>
  /// <param name="name"></param>
  /// <param name="code"></param>
  /// <param name="branchNumber"></param>
  /// <param name="branchName"></param>
  /// <param name="accountNumber"></param>
  /// <param name="totalAmount"></param>
  /// <exception cref="ArgumentException"></exception>
  /// <exception cref="ArgumentNullException"></exception>
  public static Bank Create (uint familyId, uint familymemberId ,string name, string code , ushort branchNumber, string branchName, uint accountNumber, uint totalAmount)
  {
    if(familyId <= 0)
    {
      throw new ArgumentException(nameof(familyId)); 
    }
    if(familymemberId <= 0)
    {
      throw new ArgumentException(nameof(familymemberId));
    }
    if(string.IsNullOrEmpty(name))
    {
      throw new ArgumentNullException(nameof(name));
    }
    if(totalAmount < 0)
    {
      throw new ArgumentException(nameof(totalAmount));
    }
    return new Bank
    {
    FamilyId = familyId,
    FamilymemberId = familymemberId,
    Name = name,
    Code = code,
    BranchNumber = branchNumber,
    BranchName = branchName,
    AccountNumber = accountNumber,
    TotalAmount = totalAmount
    };
  }

  /// <summary>
  /// 再構成用コンストラクタ
  /// </summary>
  /// <param name="id"></param>
  /// <param name="familyId"></param>
  /// <param name="familymemberId"></param>
  /// <param name="name"></param>
  /// <param name="code"></param>
  /// <param name="branchNumber"></param>
  /// <param name="branchName"></param>
  /// <param name="accountNumber"></param>
  /// <param name="totalAmount"></param>
  /// <param name="deletedAt"></param>
  /// <param name="createdAt"></param>
  /// <param name="updatedAt"></param>
  /// <returns></returns>
  public static Bank FromRepository(
    uint id,
    uint familyId,
    uint familymemberId, 
    string name, 
    string code,
    ushort branchNumber, 
    string branchName, 
    uint accountNumber, 
    uint totalAmount, 
    DateTime deletedAt, 
    DateTime createdAt, 
    DateTime updatedAt)
  {
    return new Bank
    {
      Id = id,
      FamilyId = familyId,
      FamilymemberId = familymemberId,
      Name = name,
      Code = code,
      BranchName = branchName,
      BranchNumber = branchNumber,
      AccountNumber = accountNumber,
      TotalAmount = totalAmount,
      DeletedAt = deletedAt,
      UpdatedAt = updatedAt,
      CreatedAt = createdAt
    };
  }
  /// <summary>
  /// インスタンス生成を内部で制御
  /// </summary>
  private Bank()
  {

  }
}