using AutoMapper;
using Lifequest.Src.Domain.Entity;
using Lifequest.Src.ApplicationService.IQueryService;
namespace Lifequest.Src.ApplicationService.UseCase.FamilyUseCase;

public class FetchFamilyListUseCase
{
  private readonly IMapper _mapper;
  private readonly IFamilyQueryService _familyQueryService;

  private readonly AuthUserContext _userContext;

  public FetchFamilyListUseCase(IMapper mapper, IFamilyQueryService familyQueryService, AuthUserContext userContext)
  {
    _mapper = mapper;
    _familyQueryService = familyQueryService;
    _userContext = userContext;
  }

  public async Task<List<FetchFamilyListUseCaseDto>> Invoke()
  {
    var uuid = _userContext.Uid;
    var value = await _familyQueryService.GetList(uuid);
    return value;
  }
}