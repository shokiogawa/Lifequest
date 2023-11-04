namespace Lifequest.Src.Domain.Models.BankHistory;

enum BankHistoryStatus
{
  Increased,
  Decrease,
  NotChanged
}


public class BankHistory 
{
  private BankHistory()
  {

  }
  public uint Id {get; private set;}

  public uint BankId {get; private set;}

  public uint TotalAmountSnapshot {get ;private set;}
  public int DifferencesAmount {get; private set;}
  public string Status {get; private set;}
  public DateTime DeletedAt {get; private set;}
  public DateTime CreatedAt {get; private set;}
  public DateTime UpdatedAt {get; private set;}

  /// <summary>
  /// 生成用コンストラクタ
  /// </summary>
  /// <param name="bankId"></param>
  /// <param name="currentAmount"></param>
  /// <param name="updatedAmount"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentException"></exception>
  /// <exception cref="Exception"></exception>
  public static BankHistory Create(uint bankId, uint currentAmount,uint updatedAmount)
  {
    if(bankId <= 0)
    {
      throw new ArgumentException(nameof(bankId)); 
    }
    if(currentAmount < 0)
    {
      throw new ArgumentException(nameof(currentAmount));
    }
    var differencesAmount = (int)updatedAmount - (int)currentAmount;
    if(differencesAmount == 0)
    {
      throw new Exception("差分がありません");
    }
    return new BankHistory
    {
      BankId = bankId,
      TotalAmountSnapshot = currentAmount,
      DifferencesAmount = differencesAmount,
      Status = differencesAmount > 0 ? BankHistoryStatus.Increased.ToString() : BankHistoryStatus.Decrease.ToString()
    };
  }

  /// <summary>
  /// 再構成用コンストラクタ
  /// </summary>
  /// <param name="id"></param>
  /// <param name="bankId"></param>
  /// <param name="totalAmountSnaoshot"></param>
  /// <param name="differencesAmount"></param>
  /// <param name="status"></param>
  /// <param name="deletedAt"></param>
  /// <param name="createdAt"></param>
  /// <param name="updatedAt"></param>
  /// <returns></returns>
  public static BankHistory FromRepository(uint id,uint bankId, uint totalAmountSnaoshot, int differencesAmount, string status, DateTime deletedAt, DateTime createdAt, DateTime updatedAt)
  {
    return new BankHistory
    {
      Id = id,
      BankId = bankId,
      TotalAmountSnapshot = totalAmountSnaoshot,
      DifferencesAmount = differencesAmount,
      Status = status,
      DeletedAt = deletedAt,
      UpdatedAt = updatedAt,
      CreatedAt = createdAt
    };
  }
}