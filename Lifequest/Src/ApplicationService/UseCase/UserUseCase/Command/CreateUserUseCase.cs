using Lifequest.Src.Domain.IRepository;
using Lifequest.Src.Domain.Models.Users;
using AutoMapper;
namespace Lifequest.Src.ApplicationService.UseCase.UserUseCase.Command;

public class CreateUserUseCase
{
  private readonly IUserRepository _userRepository;
  private readonly IMapper _mapper;

  public CreateUserUseCase(IUserRepository userRepository, IMapper mapper)
  {
    _userRepository = userRepository;
    _mapper = mapper;
  }

  public async Task Invoke (CreateUserCommand cm)
  {
    var user = User.Create(cm.Uid, cm.Email, cm.Name, cm.Birthday, cm.Age, cm.Gender);
    await _userRepository.Create(user);
  }
}