using Lifequest.Src.Domain.IRepository;
using Lifequest.Src.Domain.Models.Users;
using AutoMapper;
namespace Lifequest.Src.ApplicationService.UseCase.UserUseCase.Query;

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
  public async Task<FetchUserDetailUseCaseDto> Invoke(uint userId)
  {
    var result = await _userRepository.Get(userId);
    return new FetchUserDetailUseCaseDto
    {
      Id = result.Id,
      Uid = result.Uid,
      Email = result.Email,
      Name = result.Name,
      Birthday = result.Birthday,
      Age = result.Age,
      Gender = result.Gender,
      DeletedAt = result.DeletedAt,
      CreatedAt = result.CreatedAt,
      UpdatedAt = result.UpdatedAt
    };
  }
}