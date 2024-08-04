namespace Lifequest.Src.Domain.Models.Banks;

public class Bank 
{
  /// <summary>
  /// 銀行ID
  /// </summary>
  public uint Id {get; private set;}

  /// <summary>
  /// 家族ID
  /// </summary>
  public uint FamilyId {get; private set;}

  /// <summary>
  /// 家族メンバーID
  /// </summary>
  public uint FamilymemberId {get; private set;}
  /// <summary>
  /// 表示順番
  /// </summary>
  public uint OrderNumber {get; set;}

  /// <summary>
  /// 銀行情報
  /// </summary>
  public BankInfo BankInfo {get; private set;}
  public DateTime DeletedAt {get; private set;}
  public DateTime CreatedAt {get; private set;}
  public DateTime UpdatedAt {get; private set;}

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
  public static Bank Create (
    uint familyId, 
    uint familymemberId,
    uint orderNumber,
    BankInfo bankInfo)
  {
    if(familyId <= 0)
    {
      throw new ArgumentException(nameof(familyId)); 
    }
    if(familymemberId <= 0)
    {
      throw new ArgumentException(nameof(familymemberId));
    }
    return new Bank
    {
    FamilyId = familyId,
    FamilymemberId = familymemberId,
    OrderNumber = orderNumber,
    BankInfo = bankInfo 
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
  public static Bank Reconstructor(
    uint id,
    uint familyId,
    uint familymemberId, 
    uint orderNumber,
    BankInfo bankInfo,
    DateTime deletedAt, 
    DateTime createdAt, 
    DateTime updatedAt)
  {
    return new Bank
    {
      Id = id,
      FamilyId = familyId,
      FamilymemberId = familymemberId,
      OrderNumber = orderNumber,
      BankInfo = bankInfo,
      DeletedAt = deletedAt,
      UpdatedAt = updatedAt,
      CreatedAt = createdAt
    };
  }

  /// <summary>
  /// 合計貯金額を変更
  /// </summary>
  /// <param name="totalAmount"></param>
  /// <exception cref="ArgumentException"></exception>
  public void UpdateTotalAmount (uint totalAmount)
  {
    if(totalAmount < 0)
    {
      throw new ArgumentException(nameof(totalAmount));
    };
    BankInfo.ChangeTotalAmount(totalAmount);
  }

  /// <summary>
  /// 銀行情報編集
  /// </summary>
  /// <param name="newBankInfo"></param>
  public void UpdateBankInfo(BankInfo newBankInfo)
  {
    BankInfo = newBankInfo;
  }
  /// <summary>
  /// インスタンス生成を内部で制御
  /// </summary>
  private Bank()
  {

  }
}