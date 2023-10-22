using Lifequest.Src.Domain.IRepository;
using Lifequest.Src.Domain.Entity;
using Lifequest.Src.ViewModel;
using AutoMapper;
namespace Lifequest.Src.ApplicationService.UseCase.UserUseCase;

public class CreateUserUseCase
{
  private readonly IUserRepository _userRepository;
  private readonly IMapper _mapper;

  public CreateUserUseCase(IUserRepository userRepository, IMapper mapper)
  {
    _userRepository = userRepository;
    _mapper = mapper;
  }

  public async Task Invoke (UserViewModel vm)
  {
    var user = User.Create(vm.Uid, vm.Email, vm.Name, DateTime.Parse(vm.Birthday), vm.Age, vm.Gender);
    await _userRepository.Create(user);
  }
}