using Microsoft.AspNetCore.Mvc;
using Lifequest.Src.ClientModel.RequestModel;
using Lifequest.Src.ApplicationService.UseCase.ExpenseAndIncomeUseCase.Command;
namespace Lifequest.Src.Controllers;

[ApiController]
[Route("api/expose-and-income")]

public class ExpenseAndIncomeController : ControllerBase
{
  private readonly ILogger<ExpenseAndIncomeController> _logger;
  private readonly CreatexpenseAndIncomeUsecase _createUsecase;

  public ExpenseAndIncomeController(
    ILogger<ExpenseAndIncomeController> logger,
    CreatexpenseAndIncomeUsecase createUsecase
    )
  {
    _logger = logger;
    _createUsecase = createUsecase;
  }

  /// <summary>
  /// 前後5年の支出、収入データを取得する
  /// </summary>
  /// <typeparam name="ActionResult"></typeparam>
  [HttpGet]
  [Route("/period")]
  public async Task<ActionResult> GetListBetweentargetPeriod([FromQuery] ulong familyId, ulong familymemberId)
  {
    _logger.LogInformation("Start:GetListBetweentargetPeriod",nameof(GetListBetweentargetPeriod));
    return Ok();
  }

  /// <summary>
  /// 1ヶ月データ取得
  /// </summary>
  /// <param name="familyId"></param>
  /// <param name="familyMemberId"></param>
  /// <returns></returns>
  [HttpGet]
  [Route("/current")]
  public async Task<ActionResult> GetListForCurrentMonth([FromQuery] ulong familyId, ulong familyMemberId)
  {
    _logger.LogInformation("Start:GetListForCurrentMonth}", nameof(GetListForCurrentMonth));
    return Ok();
  }

  /// <summary>
  /// 支出・収入作成
  /// </summary>
  /// <param name="body"></param>
  /// <returns></returns>
  [HttpPost]
  public async Task<ActionResult> Create([FromBody] ExpenseAndIncomePostRequestModel request)
  {
    _logger.LogInformation("Start: ExpenseAndIncomePostRequestModel");
    Console.WriteLine(request.IsExpense);
    var cmd = new CreateExpenseAndIncomeUseCaseCommand
    {
      FamilyId = request.FamilyId,
      FamilymemberId = request.FamilymemberId,
      ExpenseAndIncomeLargeCategoryId = request.ExpenseAndIncomeLargeCategoryId,
      ExpenseAndIncomeSmallCategoryId = request.ExpenseAndIncomeSmallCategoryId,
      LargeCategoryName = request.LargeCategoryName,
      SmallCategoryName = request.SmallCategoryName,
      Amount = request.Amount,
      TargetDate = request.TargetDate,
      IsExpense = request.IsExpense
    };
   await  _createUsecase.Invoke(cmd);
    _logger.LogInformation("End: ExpenseAndIncomePostRequestModel");
    return Ok();
  }
}