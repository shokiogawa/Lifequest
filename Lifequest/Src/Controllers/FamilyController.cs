using Microsoft.AspNetCore.Mvc;
using Lifequest.Src.UseCase.Query;
using Lifequest.Src.ViewModel;
using AutoMapper;
using Lifequest.Src.UseCase.Command;
using Lifequest.Src.UseCase.ReadModel;
using Lifequest.Src.ViewModel.ResponseModel;
using Lifequest.Src.Domain.Entity;
namespace Lifequest.Src.Controllers;

[ApiController]
[Route("api/family")]
public class FamilyController : ControllerBase
{
  private readonly CreateFamilyUseCase _createFamilyUseCase;

  private readonly AddFamilyMember _addFamilyMember;

  private readonly AuthUserContext _userContext;

  private readonly IFamilyQueryService _familyQueryService;
  private readonly IMapper _mapper;
  
  public FamilyController(CreateFamilyUseCase createFamilyUseCase, AddFamilyMember addFamilyMember,IFamilyQueryService familyQueryService,AuthUserContext userContext ,IMapper mapper)
  {
    _createFamilyUseCase = createFamilyUseCase;
    _addFamilyMember = addFamilyMember;
    _familyQueryService = familyQueryService;
    _userContext = userContext;
    _mapper = mapper;
  }
  /**
  家族データ詳細取得API
  **/
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

  /**
  家族作成API
  **/
  [HttpPost]
  public async Task<IActionResult> CreateAsync([FromBody] CreateFamilyViewModel vm)
  {
    await _createFamilyUseCase.Invoke(vm);
    return Ok();
  }

  /**
  家族メンバー追加API
  **/
  [HttpPost]
  [Route("add_member")]
  public async Task<IActionResult> AddMemberAsync([FromBody] FamilyMemberViewModel vm)
  {
    await _addFamilyMember.Invoke(vm);
    return Ok();
  }

  /**
  ユーザー編集API
  **/

  /**
  ユーザー削除API
  **/
}