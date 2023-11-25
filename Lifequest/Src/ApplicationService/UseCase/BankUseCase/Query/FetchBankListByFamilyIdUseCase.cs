using AutoMapper;
using Lifequest.Src.Domain.IRepository;

namespace Lifequest.Src.ApplicationService.UseCase.BankUseCase.Query;

public class FetchBankListByFamilyIdUseCase
{
  private readonly IMapper _mapper;
  private readonly IBankRepository _bankRepository;

  public FetchBankListByFamilyIdUseCase(IBankRepository bankRepository, IMapper mapper)
  {
    _bankRepository = bankRepository;
    _mapper = mapper;
  }

  public async Task<List<FetchBankListByFamilyIdUseCaseDto>> Invoke(uint familyId)
  {
    // データ取得
    var result = await _bankRepository.FetchListByFamilyId(familyId);
    return result.Select(_ => {
      return new FetchBankListByFamilyIdUseCaseDto(
        _.Id,
        _.FamilyId, 
        _.FamilymemberId, 
        _.BankInfo.CategoryName,
        _.OrderNumber,
        _.BankInfo.Name, 
        _.BankInfo.Code ?? "", 
        _.BankInfo.BranchNumber, 
        _.BankInfo.BranchName ?? "",
        _.BankInfo.AccountNumber, 
        _.BankInfo.TotalAmount, 
        _.DeletedAt, 
        _.CreatedAt, 
        _.UpdatedAt);
    }).ToList();
  }
}