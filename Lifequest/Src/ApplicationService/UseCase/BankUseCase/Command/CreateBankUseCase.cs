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

  public async Task Invoke(CreateBankCommand vm)
  {
    // Bankオブジェクト生成
    Bank bank = Bank.Create(vm.FamilyId, vm.FamilymemberId, vm.Name, vm.Code, vm.BranchNumber, vm.BranchName, vm.AccountNumber, vm.TotalAmount);
    // 家族作成
    await _bankRepository.Create(bank);
  }
}