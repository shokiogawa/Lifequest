namespace Lifequest.Src.ApplicationService.UseCase.BankUseCase.Command;

public class CreateBankCommand
{
  public uint FamilyId {get; set;}

  public uint FamilymemberId {get; set;}

  public string Name {get; set;}

  public string Code {get; set;}

  public ushort BranchNumber {get; set;}

  public string BranchName {get; set;}

  public uint AccountNumber {get; set;}

  public uint TotalAmount {get; set;}
}