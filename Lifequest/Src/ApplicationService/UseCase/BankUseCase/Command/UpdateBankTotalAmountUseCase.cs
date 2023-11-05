using Lifequest.Src.Domain.IRepository;
using Lifequest.Src.Domain.Models.BankHistory;
using AutoMapper;
namespace Lifequest.Src.ApplicationService.UseCase.BankUseCase.Command;

public class UpdateBankTotalAmountUseCase
{
  private readonly IMapper _mapper;
  private readonly IBankRepository _bankRepository;

  public UpdateBankTotalAmountUseCase(IBankRepository bankRepository, IMapper mapper)
  {
    _bankRepository = bankRepository;
    _mapper = mapper;
  }

  public async Task Invoke(UpdateBankTotalAmoutntCommand cm)
  {
    // 現在の銀行情報を取得
    var targetBank = await _bankRepository.GetByIdAsync(cm.Id);
    if(targetBank == null)
    {
      throw new Exception("対象データが存在しません");
    }
    var newBankHistory = BankHistory.Create(targetBank.Id, targetBank.TotalAmount, cm.TotalAmount);
    // 銀行合計額を修正
    targetBank.ChangeTotalAmount(cm.TotalAmount);
    await _bankRepository.UpdateTotalAmount(targetBank, newBankHistory);
  }
}