using Microsoft.AspNetCore.Mvc;
using Lifequest.Src.UseCase.Query;
using Lifequest.Src.ViewModel;
using AutoMapper;
using Lifequest.Src.UseCase.Command;
namespace Lifequest.Src.Controllers;

[ApiController]
[Route("api/user")]
public class UserController : ControllerBase
{
  private readonly IUserQueryService _userQueryService;
  private readonly CreateUserUseCase _createUserUseCase;
  private readonly IMapper _mapper;
  
  public UserController(IUserQueryService userQueryService, CreateUserUseCase createUserUseCase , IMapper mapper)
  {
    _userQueryService = userQueryService;
    _createUserUseCase = createUserUseCase;
    _mapper = mapper;
  }
  /**
  ユーザー取得API
  **/
  [HttpGet]
  public async Task<ActionResult<UserViewModel>> GetAsync([FromQuery] int id)
  {
    var user = await _userQueryService.Get(id);
    return user == null ? NotFound() : _mapper.Map<UserViewModel>(user);
  }

  /**
  ユーザー作成API
  **/
  [HttpPost]
  public async Task<IActionResult> CreateAsync([FromBody] UserViewModel vm)
  {
    await _createUserUseCase.Invoke(vm);
    // CreatedAtActionメソッドを使用予定。
    return Ok();
  }

  /**
  ユーザー編集API
  **/

  /**
  ユーザー削除API
  **/
}