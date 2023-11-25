using Microsoft.AspNetCore.Mvc;
using Lifequest.Src.ApplicationService.UseCase.BankUseCase.Command;
using Lifequest.Src.ApplicationService.UseCase.BankUseCase.Query;
using Lifequest.Src.ClientModel.RequestModel;
using Lifequest.Src.ViewModel.ResponseModel;
using AutoMapper;
using System.Net;
namespace Lifequest.Src.Controllers;

[ApiController]
[Route("api/bank")]
public class BankController : ControllerBase
{
  private readonly CreateBankUseCase _createBankUseCase;

  private readonly FetchBankListByFamilyIdUseCase _fetchBankListByFamilyIdUseCase;

  private readonly FetchBankDetailUseCase _fetchBankDetailUseCase;

  private readonly UpdateBankTotalAmountUseCase _updateBankTotalAmountUseCase;

  private readonly UpdateBankUseCase _updateBankUseCase;
  private readonly IMapper _mapper;

  private readonly ILogger<BankController> _logger;

  public BankController(
    CreateBankUseCase createBankUseCase, 
    FetchBankListByFamilyIdUseCase fetchBankListByFamilyIdUseCase,
    FetchBankDetailUseCase fetchBankDetailUseCase,
    UpdateBankTotalAmountUseCase updateBankTotalAmountUseCase,
    UpdateBankUseCase updateBankUseCase,
    IMapper mapper,
    ILogger<BankController> logger
    )
  {
    _createBankUseCase = createBankUseCase;
    _fetchBankListByFamilyIdUseCase = fetchBankListByFamilyIdUseCase;
    _fetchBankDetailUseCase = fetchBankDetailUseCase;
    _updateBankTotalAmountUseCase = updateBankTotalAmountUseCase;
    _updateBankUseCase = updateBankUseCase;
    _mapper = mapper;
    _logger = logger;
  }

  /// <summary>
  /// 銀行作成API
  /// </summary>
  /// <param name="vm"></param>
  /// <returns></returns>
  [HttpPost]
  public async Task<IActionResult> CreateAsync([FromBody] BankRequestModel request)
  {
    Console.WriteLine(request.FamilyId);
    var cm = new CreateBankCommand
    {
      FamilyId = request.FamilyId,
      FamilymemberId = request.FamilymemberId,
      CategoryName = request.CategoryName,
      OrderNumber = request.OrderNumber,
      //銀行名
      Name = request.Name,
      // 金融機関コード
      Code = request.Code,
      // 支店名
      BranchName = request.BranchName,
      // 支店番号
      BranchNumber = request.BranchNumber,
      // 口座番号
      AccountNumber = request.AccountNumber,
      // 総資産学
      TotalAmount = request.TotalAmount
    };
    await _createBankUseCase.Invoke(cm);
    return Ok();
  }

  [HttpPut]
  [Route("edit")]
  public async Task<IActionResult> UpdateBank([FromBody] BankRequestModel request)
  {
    _logger.LogInformation("銀行編集API");
    var cm = new UpdateBankUseCaseCommand
    {
      Id = request.Id,
      FamilyId = request.FamilyId,
      FamilymemberId = request.FamilymemberId,
      CategoryName = request.CategoryName,
      OrderNumber = request.OrderNumber,
      Name = request.Name,
      Code = request.Code,
      BranchName = request.BranchName,
      BranchNumber = request.BranchNumber,
      AccountNumber = request.AccountNumber,
      TotalAmount = request.TotalAmount
    };
    await _updateBankUseCase.Invoke(cm);
    return Ok();
  }

  /// <summary>
  /// 貯金修正API
  /// </summary>
  /// <param name="vm"></param>
  /// <returns></returns>
  [HttpPut]
  [Route("totalAmount")]
  public async Task<IActionResult> UpdateTotalAmountAsync([FromBody] BankRequestModel request)
  {
    var cm = new UpdateBankTotalAmoutntCommand
    {
      Id = request.Id,
      TotalAmount = request.TotalAmount
    };
    await _updateBankTotalAmountUseCase.Invoke(cm);
    return Ok();
  }

  /// <summary>
  /// 家族の銀行データ取得API
  /// </summary>
  /// <param name="familyId"></param>
  /// <returns></returns>
  [HttpGet]
  public async Task<ActionResult<BankTotalResponseModel>> GetByFamilyIdAsync ([FromQuery] uint familyId)
  {
    _logger.LogInformation("BankController開始", familyId);
    // 家族テーブルに紐づいている銀行情報を取得
    var bankList = await _fetchBankListByFamilyIdUseCase.Invoke(familyId);
    // jsonに変換
    var bankListViewModel = bankList.Select(bank => new BankResponseModel
    {
      Id = bank.Id,
      FamilyId = bank.FamilyId,
      FamilymemberId = bank.FamilymemberId,
      CategoryName = bank.CategoryName,
      OrderNumber = bank.OrderNumber,
      Name = bank.Name,
      Code = bank.Code,
      BranchName = bank.BranchName,
      BranchNumber = bank.BranchNumber,
      AccountNumber = bank.AccountNumber,
      TotalAmount = bank.TotalAmount,
      TotalAmountString =  String.Format("{0:#,0}円", bank.TotalAmount),
      DeletedAt = bank.DeletedAt,
      CreatedAt = bank.CreatedAt,
      UpdatedAt = bank.UpdatedAt,
    }).ToList();

    var bankTotalAmount = (uint)bankList.Select(bank => (decimal)bank.TotalAmount).ToList().Sum();
    return new BankTotalResponseModel
    {
      TotalAmount = bankTotalAmount, 
      TotalAmountString = String.Format("{0:#,0}円", bankTotalAmount),
      BankList = bankListViewModel
    };
  }

  /// <summary>
  /// 銀行詳細取得API
  /// </summary>
  /// <param name="bankId"></param>
  /// <returns></returns>
  [HttpGet]
  [Route("detail")]
  public async Task<ActionResult<BankResponseModel>> GetBank([FromQuery] uint bankId)
  {
    _logger.LogInformation("銀行詳細データ取得API", bankId);

    var bank = await _fetchBankDetailUseCase.Invoke(bankId);
    if(bank == null){
      return NotFound();
    }
    return new BankResponseModel
    {
      Id = bank.Id,
      FamilyId = bank.FamilyId,
      FamilymemberId = bank.FamilymemberId,
      CategoryName = bank.CategoryName,
      OrderNumber = bank.OrderNumber,
      Name = bank.Name,
      Code = bank.Code,
      BranchName = bank.BranchName,
      BranchNumber = bank.BranchNumber,
      AccountNumber = bank.AccountNumber,
      TotalAmount = bank.TotalAmount,
      TotalAmountString =  String.Format("{0:#,0}円", bank.TotalAmount),
      DeletedAt = bank.DeletedAt,
      CreatedAt = bank.CreatedAt,
      UpdatedAt = bank.UpdatedAt,
    };
  }
}