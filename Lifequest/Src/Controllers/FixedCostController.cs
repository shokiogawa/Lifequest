using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Lifequest.Src.ApplicationService.UseCase.FixedCostUseCase.Query;
using Microsoft.AspNetCore.Authorization;
using Lifequest.Src.Domain.Entity;
using Lifequest.Src.ClientModel.ResponseModel;
using Lifequest.Src.ClientModel.RequestModel;
using Lifequest.Src.ApplicationService.UseCase.FixedCostUseCase.Command;

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
  public async Task<ActionResult<List<FixedCostResponseModel>>> GetAsync([FromQuery] uint familyId)
  {
    var fixedCostList = await _fetchFixedCostByFamilyIdUseCase.Invoke(familyId);
    var response = fixedCostList.Select(fixedCost => _mapper.Map<FixedCostResponseModel>(fixedCost)).ToList();
    return response;
  }

  /// <summary>
  /// 固定費作成API
  /// </summary>
  /// <param name="vm"></param>
  /// <returns></returns>
  [HttpPost]
  public async Task<IActionResult> CreateAsync([FromBody] FixedCostRequestModel request)
  {
    var cm = new CreateFixedCostCommand
    {
      FamilyId = request.FamilyId,
      Name = request.Name,
      Expose = request.Expose,
    };
    await _createFixedCostUseCase.Invoke(cm);
    return Ok();
  }
}