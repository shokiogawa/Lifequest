namespace Lifequest.Src.Domain.Models.Banks;

/// <summary>
/// 銀行値オブジェクト
/// </summary>
public class BankInfo
{
  public string Name {get; private set;}
  public string Code {get; private set;} = "";

  public ushort BranchNumber {get ; private set;}

  public string BranchName {get; private set;} = "";
  public uint AccountNumber {get; private set;}
  public uint TotalAmount {get; private set;}

  public string CategoryName {get; private set;}

  public static BankInfo Create(string name, string code, ushort branchNumber, string branchName, uint accountNumber, uint totalAmount, string categoryName)
  {
    if(string.IsNullOrEmpty(name))
    {
      throw new ArgumentException(nameof(name));
    }
    if(totalAmount < 0)
    {
      throw new ArgumentException(nameof(totalAmount));
    }
    return new BankInfo
    {
      Name = name,
      Code = code,
      BranchNumber = branchNumber,
      BranchName = branchName,
      AccountNumber = accountNumber,
      TotalAmount = totalAmount,
      CategoryName = categoryName,
    };
  }

  /// <summary>
  /// 再構築メソッド
  /// </summary>
  /// <param name="name"></param>
  /// <param name="code"></param>
  /// <param name="branchNumber"></param>
  /// <param name="branchName"></param>
  /// <param name="accountNumber"></param>
  /// <param name="totalAmount"></param>
  /// <returns></returns>
  public static BankInfo Reconstruct(
    string name, 
    string code, 
    ushort branchNumber, 
    string branchName, 
    uint accountNumber, 
    uint totalAmount,
    string categoryName
    )
  {
    return new BankInfo{
      Name = name,
      Code = code,
      BranchNumber = branchNumber,
      BranchName = branchName,
      AccountNumber = accountNumber,
      TotalAmount = totalAmount,
      CategoryName = categoryName,
    };
  }

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
  /// コンストラクタは内部で行う。
  /// </summary>
  private BankInfo()
  {

  }
  
}