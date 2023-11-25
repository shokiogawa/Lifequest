using Lifequest.Src.Domain.IRepository;
using Lifequest.Src.Domain.Models.Banks;
using AutoMapper;
namespace Lifequest.Src.ApplicationService.UseCase.BankUseCase.Command;

public class UpdateBankUseCase
{
  private readonly IMapper _mapper;
  private readonly IBankRepository _bankRepository;

  private readonly ILogger<UpdateBankUseCase> _logger;

  public UpdateBankUseCase(IBankRepository bankRepository, IMapper mapper, ILogger<UpdateBankUseCase> logger)
  {
    _bankRepository = bankRepository;
    _mapper = mapper;
    _logger = logger;
  }

  public async Task Invoke(UpdateBankUseCaseCommand cm)
  {
    // 更新対象のデータを一度取得(エンティティを作成するため)
    var targetBank = await _bankRepository.FetchByIdAsync(cm.Id);
    if(targetBank == null)
    {
      _logger.LogWarning("銀行の対象IDが見つかりません。", cm.Id);
      throw new Exception("対象データが存在しません。");
    }
    // TODO: 排他エラー
    // 更新情報を作成。
    var newBankInfo = BankInfo.Create(cm.Name, cm.Code, cm.BranchNumber, cm.BranchName, cm.AccountNumber, cm.TotalAmount, cm.CategoryName);
    // 銀行データの情報をメモリ上で更新。
    targetBank.UpdateBankInfo(newBankInfo);

    // 銀行データの情報をDB上で更新
    await _bankRepository.UpdateInfo(targetBank);
  }
}