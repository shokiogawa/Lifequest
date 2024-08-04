using AutoMapper;
using Lifequest.Src.Domain.Entity;
using Lifequest.Src.ApplicationService.IQueryService;
namespace Lifequest.Src.ApplicationService.UseCase.FamilyUseCase.Query;

public class FetchFamilyListUseCase
{
  private readonly IMapper _mapper;
  private readonly IFamilyQueryService _familyQueryService;


  public FetchFamilyListUseCase(IMapper mapper, IFamilyQueryService familyQueryService)
  {
    _mapper = mapper;
    _familyQueryService = familyQueryService;
  }

  public async Task<List<FetchFamilyListUseCaseDto>> Invoke(uint userId)
  {
    // var uuid = _userContext.Uid;
    var value = await _familyQueryService.FetchListByUserId(userId);
    return value;
  }
}