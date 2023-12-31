using Microsoft.AspNetCore.Mvc;
using Lifequest.Src.ApplicationService.IQueryService;
using Lifequest.Src.ViewModel;
using AutoMapper;
using Lifequest.Src.ApplicationService.UseCase.FamilyUseCase.Command;
using Lifequest.Src.ViewModel.ResponseModel;
using Lifequest.Src.Domain.Entity;
using Lifequest.Src.ClientModel.RequestModel;
namespace Lifequest.Src.Controllers;

[ApiController]
[Route("api/family")]
public class FamilyController : ControllerBase
{
  private readonly CreateFamilyUseCase _createFamilyUseCase;

  private readonly AddFamilyMemberUseCase _addFamilyMemberUseCase;

  private readonly AuthUserContext _userContext;

  private readonly IFamilyQueryService _familyQueryService;
  private readonly IMapper _mapper;
  
  public FamilyController(CreateFamilyUseCase createFamilyUseCase, AddFamilyMemberUseCase addFamilyMemberUseCase,IFamilyQueryService familyQueryService,AuthUserContext userContext ,IMapper mapper)
  {
    _createFamilyUseCase = createFamilyUseCase;
    _addFamilyMemberUseCase = addFamilyMemberUseCase;
    _familyQueryService = familyQueryService;
    _userContext = userContext;
    _mapper = mapper;
  }

  /// <summary>
  /// 家族データ取得API
  /// </summary>
  /// <returns></returns>
  [HttpGet]
  public async Task<ActionResult<FamilyInfoListResponseModel>> GetListAsync()
  {
    var uuid = _userContext.Uid;
    Console.WriteLine(uuid);
    var familyList = await _familyQueryService.GetList(uuid);
    var familyInfoResponseModel = familyList.Select(familyInfo => _mapper.Map<FamilyInfoResponseModel>(familyInfo)).ToList();
    return new FamilyInfoListResponseModel
    {
      FamilyList = familyInfoResponseModel
    };
  }

  /// <summary>
  /// 家族作成API
  /// </summary>
  /// <param name="vm"></param>
  /// <returns></returns>
  [HttpPost]
  public async Task<IActionResult> CreateAsync([FromBody] FamilyPostRequestModel request)
  {
    var cm = new CreateFamilyCommand
    {
      Id = request.Id,
      Name = request.Name,
      FamilyMembers = request.FamilyMembers.Select(_ => new CreateFamilyMemberCommand
      {
        UserId = _.UserId,
        FamilyId = _.FamilyId,
        IsOwner = _.IsOwner,
        Position = _.Position,
        CreatedAt = _.CreatedAt,
        UpdatedAt = _.UpdatedAt,
        DeletedAt = _.DeletedAt
      }).ToList()
    };
    await _createFamilyUseCase.Invoke(cm);
    return Ok();
  }

  /// <summary>
  /// 家族メンバー追加API
  /// </summary>
  /// <param name="vm"></param>
  /// <returns></returns>
  [HttpPost]
  [Route("add_member")]
  public async Task<IActionResult> AddMemberAsync([FromBody] FamilyMemberPostRequestModel request)
  {
    var cm = new AddFamilyMemberCommand{};
    await _addFamilyMemberUseCase.Invoke(cm);
    return Ok();
  }
}