using Microsoft.AspNetCore.Mvc;
using Lifequest.Src.UseCase.Query;
using Lifequest.Src.ViewModel;
using AutoMapper;
using Lifequest.Src.UseCase.Command;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Lifequest.Src.Domain.Entity;

namespace Lifequest.Src.Controllers;

[Authorize]
[ApiController]
[Route("api/fixed_costs")]
public class FixedCostController : ControllerBase
{
  private readonly IMapper _mapper;
  private readonly IFixedCostQueryService _fixedCostQueryService;

  private readonly CreateFixedCostUseCase _createFixedCostUseCase;

  private readonly AuthUserContext _userContext;
  
  public FixedCostController(IMapper mapper, IFixedCostQueryService fixedCostQueryService, CreateFixedCostUseCase createFixedCostUseCase, AuthUserContext userContext)
  {
    _fixedCostQueryService = fixedCostQueryService;
    _createFixedCostUseCase = createFixedCostUseCase;
    _mapper = mapper;
    _userContext = userContext;
  }
  /**
  固定費取得API
  **/
  [HttpGet]
  public async Task<ActionResult<List<FixedCostViewModel>>> GetAsync([FromQuery] int familyId)
  {
    var fixedCostList = await _fixedCostQueryService.GetByFamilyId(familyId);
    var fixedCostVmList = fixedCostList.Select(fixedCost => _mapper.Map<FixedCostViewModel>(fixedCost)).ToList();
    return fixedCostVmList;
  }

  /**
  固定費作成API
  **/
  [HttpPost]
  public async Task<IActionResult> CreateAsync([FromBody] FixedCostViewModel vm)
  {
    await _createFixedCostUseCase.Invoke(vm);
    return Ok();
  }

  /**
  ユーザー編集API
  **/

  /**
  ユーザー削除API
  **/
}