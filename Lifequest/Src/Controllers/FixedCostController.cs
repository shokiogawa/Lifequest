using Microsoft.AspNetCore.Mvc;
using Lifequest.Src.ViewModel;
using AutoMapper;
using Lifequest.Src.ApplicationService.UseCase.FixedCostUseCase;
using Microsoft.AspNetCore.Authorization;
using Lifequest.Src.Domain.Entity;

namespace Lifequest.Src.Controllers;

[Authorize]
[ApiController]
[Route("api/fixed_costs")]
public class FixedCostController : ControllerBase
{
  private readonly IMapper _mapper;

  private readonly CreateFixedCostUseCase _createFixedCostUseCase;

  private readonly FetchFixedCostByFamilyIdUseCase _fetchFixedCostByFamilyIdUseCase;

  private readonly AuthUserContext _userContext;
  
  public FixedCostController(
    IMapper mapper, 
    CreateFixedCostUseCase createFixedCostUseCase,
    FetchFixedCostByFamilyIdUseCase fetchFixedCostByFamilyIdUseCase,
    AuthUserContext userContext)
  {
    _createFixedCostUseCase = createFixedCostUseCase;
    _fetchFixedCostByFamilyIdUseCase = fetchFixedCostByFamilyIdUseCase;
    _mapper = mapper;
    _userContext = userContext;
  }

  /// <summary>
  /// 家族固定費取得API
  /// </summary>
  /// <param name="familyId"></param>
  /// <returns></returns>
  [HttpGet]
  public async Task<ActionResult<List<FixedCostViewModel>>> GetAsync([FromQuery] uint familyId)
  {
    var fixedCostList = await _fetchFixedCostByFamilyIdUseCase.Invoke(familyId);
    var fixedCostVmList = fixedCostList.Select(fixedCost => _mapper.Map<FixedCostViewModel>(fixedCost)).ToList();
    return fixedCostVmList;
  }

  /// <summary>
  /// 固定費作成API
  /// </summary>
  /// <param name="vm"></param>
  /// <returns></returns>
  [HttpPost]
  public async Task<IActionResult> CreateAsync([FromBody] FixedCostViewModel vm)
  {
    await _createFixedCostUseCase.Invoke(vm);
    return Ok();
  }
}