using Lifequest.Src.Domain.IRepository;
using Lifequest.Src.Domain.Entity;
using Lifequest.Src.ViewModel;
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

  public async Task<User> Invoke(uint userId)
  {
    return await _userRepository.Get(userId);
  }
}