using Lifequest.Src.Domain.IRepository;
using Lifequest.Src.Domain.Models.Users;
using AutoMapper;
namespace Lifequest.Src.ApplicationService.UseCase.UserUseCase;

public class FetchUserDetailUseCase
{
  private readonly IUserRepository _userRepository;
  private readonly IMapper _mapper;
  public FetchUserDetailUseCase(IUserRepository userRepository, IMapper mapper)
  {
    _userRepository = userRepository;
    _mapper = mapper;
  }

  /// <summary>
  /// ユーザー詳細情報を取得
  /// </summary>
  /// <param name="userId"></param>
  /// <returns></returns>
  public async Task<User> Invoke(uint userId)
  {
    return await _userRepository.Get(userId);
  }
}