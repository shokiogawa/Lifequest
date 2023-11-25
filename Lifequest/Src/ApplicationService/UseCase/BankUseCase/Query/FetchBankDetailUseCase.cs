using AutoMapper;
using Lifequest.Src.Domain.IRepository;

namespace Lifequest.Src.ApplicationService.UseCase.BankUseCase.Query;

public class FetchBankDetailUseCase
{
  private readonly IMapper _mapper;
  private readonly IBankRepository _bankRepository;

  public FetchBankDetailUseCase(IBankRepository bankRepository, IMapper mapper)
  {
    _bankRepository = bankRepository;
    _mapper = mapper;
  }

  public async Task<FetchBankDetailUseCaseDto> Invoke(uint bankId)
  {
    // データ取得
    var result = await _bankRepository.FetchByIdAsync(bankId);
    if(result == null)
    {
      throw new Exception("銀行データが存在しません。");
    }
    return new FetchBankDetailUseCaseDto(
        result.Id,
        result.FamilyId, 
        result.FamilymemberId, 
        result.BankInfo.CategoryName,
        result.OrderNumber,
        result.BankInfo.Name, 
        result.BankInfo.Code ?? "", 
        result.BankInfo.BranchNumber, 
        result.BankInfo.BranchName ?? "",
        result.BankInfo.AccountNumber, 
        result.BankInfo.TotalAmount, 
        result.DeletedAt, 
        result.CreatedAt, 
        result.UpdatedAt);
  }
}