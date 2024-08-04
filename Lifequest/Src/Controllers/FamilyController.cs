using Microsoft.AspNetCore.Mvc;
using Lifequest.Src.ApplicationService.IQueryService;
using Lifequest.Src.ViewModel;
using AutoMapper;
using Lifequest.Src.ApplicationService.UseCase.FamilyUseCase.Command;
using Lifequest.Src.ViewModel.ResponseModel;
using Lifequest.Src.Domain.Entity;
using Lifequest.Src.ClientModel.RequestModel;
using Lifequest.Src.ApplicationService.UseCase.FamilyUseCase.Query;
namespace Lifequest.Src.Controllers;

[ApiController]
[Route("api/family")]
public class FamilyController : ControllerBase
{
  private readonly CreateFamilyUseCase _createFamilyUseCase;

  private readonly AddFamilyMemberUseCase _addFamilyMemberUseCase;

  private readonly FetchFamilyListUseCase _fetchFamilyListUseCase;

  // private readonly AuthUserContext _userContext;

  private readonly IMapper _mapper;
  
  public FamilyController(
    CreateFamilyUseCase createFamilyUseCase, 
    AddFamilyMemberUseCase addFamilyMemberUseCase,
    FetchFamilyListUseCase fetchFamilyListUseCase,
    // AuthUserContext userContext,
    IMapper mapper)
  {
    _createFamilyUseCase = createFamilyUseCase;
    _addFamilyMemberUseCase = addFamilyMemberUseCase;
    _fetchFamilyListUseCase = fetchFamilyListUseCase;
    // _userContext = userContext;
    _mapper = mapper;
  }

  /// <summary>
  /// 家族データ取得API
  /// </summary>
  /// <returns></returns>
  [HttpGet]
  public async Task<ActionResult<BaseResponseModel<FamilyInfoListResponseModel>>> GetListAsync([FromQuery] uint userId)
  {
    var familyList = await _fetchFamilyListUseCase.Invoke(userId);
    var familyInfoResponseModel = familyList.Select(_ => 
    new FamilyInfoResponseModel
    {
      FamilyId = _.FamilyId,
      FamilyName = _.FamilyName,
      Position = _.Position,
      IsOwner = _.IsOwner
    }).ToList();
    return new BaseResponseModel<FamilyInfoListResponseModel>
    {
      Status = "success",
      Data = new FamilyInfoListResponseModel
      {
        FamilyList = familyInfoResponseModel
      }
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
      Name = request.Name,
      FamilyMembers = request.FamilyMembers.Select(_ => new CreateFamilyMemberCommand
      {
        UserId = _.UserId,
        IsOwner = _.IsOwner,
        Position = _.Position
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