using Microsoft.AspNetCore.Mvc;
using Lifequest.Src.UseCase.Query;
using Lifequest.Src.ViewModel;
using Lifequest.Src.ViewModel.ResponseModel;
using AutoMapper;
using Lifequest.Src.UseCase.Command;
namespace Lifequest.Src.Controllers;

[ApiController]
[Route("api/bank")]
public class BankController : ControllerBase
{
  private readonly CreateBankUseCase _createBankUseCase;

  private readonly IBankQueryService _bankQueryService;

  private readonly UpdateBankTotalAmountUseCase _updateBankTotalAmountUseCase;
  private readonly IMapper _mapper;

  public BankController(CreateBankUseCase createBankUseCase, IBankQueryService bankQueryService,UpdateBankTotalAmountUseCase updateBankTotalAmountUseCase,IMapper mapper)
  {
    _createBankUseCase = createBankUseCase;
    _bankQueryService = bankQueryService;
    _updateBankTotalAmountUseCase = updateBankTotalAmountUseCase;
    _mapper = mapper;
  }
  
  /**
  銀行作成API
  **/

  [HttpPost]
  public async Task<IActionResult> CreateAsync([FromBody] BankViewModel vm)
  {
    await _createBankUseCase.Invoke(vm);
    return Ok();
  }

  /**
  銀行の合計貯蓄金額更新API
  **/
  [HttpPost]
  [Route("totalAmount")]
  public async Task<IActionResult> UpdateTotalAmountAsync([FromBody] BankViewModel vm)
  {
    await _updateBankTotalAmountUseCase.Invoke(vm);
    return Ok();
  }

  /**
  家族に紐づく銀行取得API
  **/
  [HttpGet]
  public async Task<ActionResult<BankTotalResponseModel>> GetByFamilyIdAsync ([FromQuery] uint familyId)
  {
    // 家族テーブルに紐づいている銀行情報を取得
    var bankList = await _bankQueryService.GetListByFamilyId(familyId);
    // jsonに変換
    var bankListViewModel = bankList.Select(bank => new BankResponseModel
    {
      Id = bank.Id,
      FamilyId = bank.FamilyId,
      FamilymemberId = bank.FamilymemberId,
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

    var bankTotalAmount = (uint)((bankList.Select(bank => (decimal)bank.TotalAmount)).ToList()).Sum();
    return new BankTotalResponseModel
    {
      TotalAmount = bankTotalAmount, 
      TotalAmountString = String.Format("{0:#,0}円", bankTotalAmount),
      BankList = bankListViewModel
    };
  }
}