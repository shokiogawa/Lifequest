namespace Lifequest.Src.Domain.Entity;

public class Bank 
{
  public Bank()
  {

  }
  public uint Id {get; private set;}

  public uint FamilyId {get; private set;}

  public uint FamilymemberId {get; private set;}
  public string Name {get; private set;}
  public string? Code {get; private set;} = "";

  public UInt16? BranchNumber {get ; private set;}

  public string? BranchName {get; private set;} = "";
  public uint? AccountNumber {get; private set;}
  public uint TotalAmount {get; private set;}
  public DateTime DeletedAt {get; private set;}
  public DateTime CreatedAt {get; private set;}
  public DateTime UpdatedAt {get; private set;}

  // 銀行作成時に使用するメソッド
  public static Bank NewCreate (uint familyId, uint familymemberId ,string name, string? code , UInt16? branchNumber, string? branchName, uint? accountNumber, uint totalAmount)
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

  public static Bank Update (uint id, uint familyId, uint familymemberId ,string name, string? code , UInt16? branchNumber, string? branchName, uint? accountNumber, uint totalAmount)
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
    Id = id,
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

  // リポジトリからデータ取得
  public static Bank FromRepository(uint id, uint familyId,uint familymemberId,  string name, string? code ,UInt16? branchNumber, string? branchName, uint? accountNumber, uint totalAmount, DateTime deletedAt, DateTime createdAt, DateTime updatedAt)
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
}