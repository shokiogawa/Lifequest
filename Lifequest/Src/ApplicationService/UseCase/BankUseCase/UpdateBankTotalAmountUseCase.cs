using Lifequest.Src.Domain.IRepository;
using Lifequest.Src.Domain.Models.BankHistory;
using Lifequest.Src.Domain.Models.Banks;
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
    var targetBank = await _bankRepository.GetByIdAsync(vm.Id);
    if(targetBank == null)
    {
      throw new Exception("対象データが存在しません");
    }
    var newBankHistory = BankHistory.Create(targetBank.Id, targetBank.TotalAmount, vm.TotalAmount);
    // 銀行合計額を修正
    targetBank.ChangeTotalAmount(vm.TotalAmount);
    await _bankRepository.UpdateTotalAmount(targetBank, newBankHistory);
  }
}