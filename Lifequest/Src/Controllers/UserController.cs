using Microsoft.AspNetCore.Mvc;
using Lifequest.Src.ViewModel;
using AutoMapper;
using Lifequest.Src.ApplicationService.UseCase.UserUseCase;
namespace Lifequest.Src.Controllers;

[ApiController]
[Route("api/user")]
public class UserController : ControllerBase
{
  private readonly FetchUserDetailUseCase _fertchUserDetailUseCase;
  private readonly CreateUserUseCase _createUserUseCase;
  private readonly IMapper _mapper;
  
  public UserController(FetchUserDetailUseCase fertchUserDetailUseCase, CreateUserUseCase createUserUseCase , IMapper mapper)
  {
    _fertchUserDetailUseCase = fertchUserDetailUseCase;
    _createUserUseCase = createUserUseCase;
    _mapper = mapper;
  }

  /// <summary>
  /// ユーザー情報取得API
  /// </summary>
  /// <param name="id"></param>
  /// <returns></returns>
  [HttpGet]
  public async Task<ActionResult<UserViewModel>> GetAsync([FromQuery] uint id)
  {
    var user = await _fertchUserDetailUseCase.Invoke(id);
    return _mapper.Map<UserViewModel>(user);
  }

  /// <summary>
  /// ユーザー作成API
  /// </summary>
  /// <param name="vm"></param>
  /// <returns></returns>
  [HttpPost]
  public async Task<IActionResult> CreateAsync([FromBody] UserViewModel vm)
  {
    await _createUserUseCase.Invoke(vm);
    // CreatedAtActionメソッドを使用予定。
    return Ok();
  }
}