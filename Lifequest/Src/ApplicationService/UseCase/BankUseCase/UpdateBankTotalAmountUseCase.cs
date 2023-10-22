using Lifequest.Src.Domain.IRepository;
using Lifequest.Src.Domain.Entity;
using Lifequest.Src.ViewModel;
using AutoMapper;
namespace Lifequest.Src.ApplicationService.UseCase.BankUseCase;

public class UpdateBankTotalAmountUseCase
{
  private readonly IMapper _mapper;
  private readonly IBankRepository _bankRepository;

  public UpdateBankTotalAmountUseCase(IBankRepository bankRepository, IMapper mapper)
  {
    _bankRepository = bankRepository;
    _mapper = mapper;
  }

  public async Task Invoke(BankViewModel vm)
  {
    // 現在の銀行情報を取得
    var currentBank = await _bankRepository.GetByIdAsync(vm.Id);
    if(currentBank == null)
    {
      throw new Exception("対象データが存在しません");
    }
    var updatedBank = Bank.Update(currentBank.Id, currentBank.FamilyId, currentBank.FamilymemberId, currentBank.Name, currentBank.Code, currentBank.BranchNumber, currentBank.BranchName, currentBank.AccountNumber, vm.TotalAmount);
    var newBankHistory = BankHistory.NewCreate(currentBank.Id, currentBank.TotalAmount, updatedBank.TotalAmount);
    await _bankRepository.UpdateTotalAmount(updatedBank, newBankHistory);
  }
}