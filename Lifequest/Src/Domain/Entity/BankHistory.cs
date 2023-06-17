namespace Lifequest.Src.Domain.Entity;

enum BankHistoryStatus
{
  Increased,
  Decrease,
  NotChanged
}


public class BankHistory 
{
  public BankHistory()
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

  // 銀行履歴作成時に使用するメソッド
  public static BankHistory NewCreate(uint bankId, uint currentAmount,uint updatedAmount)
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

  // リポジトリからデータ取得
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