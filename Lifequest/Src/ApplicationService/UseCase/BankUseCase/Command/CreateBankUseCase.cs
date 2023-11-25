using Lifequest.Src.Domain.IRepository;
using Lifequest.Src.Domain.Models.Banks;
using AutoMapper;
namespace Lifequest.Src.ApplicationService.UseCase.BankUseCase.Command;

public class CreateBankUseCase
{
  private readonly IMapper _mapper;
  private readonly IBankRepository _bankRepository;

  public CreateBankUseCase(IBankRepository bankRepository, IMapper mapper)
  {
    _bankRepository = bankRepository;
    _mapper = mapper;
  }

  public async Task Invoke(CreateBankCommand cm)
  {
    // 銀行情報の値オブジェクト作成
    BankInfo bankInfo = BankInfo.Create(
      cm.Name, 
      cm.Code,
      cm.BranchNumber, 
      cm.BranchName, 
      cm.AccountNumber, 
      cm.TotalAmount,
      cm.CategoryName
    );
    // Bankオブジェクト生成
    Bank bank = Bank.Create(cm.FamilyId, cm.FamilymemberId,cm.OrderNumber, bankInfo);
    // 家族作成
    await _bankRepository.Create(bank);
  }
}