using Microsoft.AspNetCore.Mvc;
using Lifequest.Src.UseCase.Query;
using Lifequest.Src.ViewModel;
using AutoMapper;
using Lifequest.Src.UseCase.Command;
namespace Lifequest.Src.Controllers;

[ApiController]
[Route("api/fixed_costs")]
public class FixedCostController : ControllerBase
{
  private readonly IMapper _mapper;
  private readonly IFixedCostQueryService _fixedCostQueryService;

  private readonly CreateFixedCostUseCase _createFixedCostUseCase;
  
  public FixedCostController(IMapper mapper, IFixedCostQueryService fixedCostQueryService, CreateFixedCostUseCase createFixedCostUseCase)
  {
    _fixedCostQueryService = fixedCostQueryService;
    _createFixedCostUseCase = createFixedCostUseCase;
    _mapper = mapper;
  }
  /**
  固定費取得API
  **/
  [HttpGet]
  public async Task<ActionResult<List<FixedCostViewModel>>> GetAsync([FromQuery] int familyId)
  {
    // テスト空間⇩⇩⇩
    // await HttpContext.Session.LoadAsync();
    // var storeValue = HttpContext.Session.GetString("test");
    // Console.WriteLine(storeValue);
    // if (storeValue == null)
    // {
    //   Console.WriteLine("保存しにいってるよ");
    //   HttpContext.Session.SetString("test", "テストだよーーーー");

    //   // Redisにデータを保存する
    //   await HttpContext.Session.CommitAsync();
    // }
    // テスト空間⇧⇧⇧

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