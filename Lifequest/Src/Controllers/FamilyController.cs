using Microsoft.AspNetCore.Mvc;
using Lifequest.Src.UseCase.Query;
using Lifequest.Src.ViewModel;
using AutoMapper;
using Lifequest.Src.UseCase.Command;
namespace Lifequest.Src.Controllers;

[ApiController]
[Route("api/family")]
public class FamilyController : ControllerBase
{
  private readonly CreateFamilyUseCase _createFamilyUseCase;
  private readonly IMapper _mapper;
  
  public FamilyController(CreateFamilyUseCase createFamilyUseCase, IMapper mapper)
  {
    _createFamilyUseCase = createFamilyUseCase;
    _mapper = mapper;
  }
  /**
  家族データ詳細取得API
  **/
  [HttpGet]
  public async Task GetAsync([FromQuery] int id)
  {
    Console.WriteLine("やあ");
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
  ユーザー編集API
  **/

  /**
  ユーザー削除API
  **/
}