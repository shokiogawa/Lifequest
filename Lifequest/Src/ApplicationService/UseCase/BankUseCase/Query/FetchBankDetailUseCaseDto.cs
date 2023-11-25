using System.Globalization;

namespace Lifequest.Src.ApplicationService.UseCase.BankUseCase.Query;

//単体
public class FetchBankDetailUseCaseDto
{
  public uint Id {get; private set;}
  public uint FamilyId {get; private set;}

  public uint FamilymemberId {get; private set;}

  public string CategoryName {get; private set;}

  public uint OrderNumber {get; set;}
  public string Name {get; private set;}
  public string? Code {get; private set;} = "";

  public UInt16? BranchNumber {get ; private set;}

  public string? BranchName {get; private set;} = "";
  public uint? AccountNumber {get; private set;}
  public uint TotalAmount {get; private set;}
  public DateTime DeletedAt {get; private set;}
  public DateTime CreatedAt {get; private set;}
  public DateTime UpdatedAt {get; private set;}

  public FetchBankDetailUseCaseDto(
    uint id, 
    uint familyId, 
    uint familyMemberId,
    string categoryName,
    uint orderNumber,
    string name, 
    string code ,
    UInt16? branchNumber, 
    string branchName, 
    uint? accountNumber, 
    uint totalAmount, 
    DateTime deletedAt, 
    DateTime createdAt, 
    DateTime updatedAt)
  {
    Id = id;
    FamilyId = familyId;
    FamilymemberId = familyMemberId;
    CategoryName = categoryName;
    OrderNumber = orderNumber;
    Name = name;
    Code = code;
    BranchNumber = branchNumber;
    BranchName = branchName;
    AccountNumber = accountNumber;
    TotalAmount = totalAmount;
    DeletedAt = deletedAt;
    CreatedAt = createdAt;
    UpdatedAt = updatedAt;
  }

}