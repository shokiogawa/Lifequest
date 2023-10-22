using Lifequest.Src.Domain.IRepository;
using Lifequest.Src.Domain.Entity;
using Lifequest.Src.ViewModel;
using AutoMapper;
namespace Lifequest.Src.ApplicationService.UseCase.FamilyUseCase;

public class CreateFamilyUseCase
{
  private readonly IMapper _mapper;
  private readonly IFamilyRepository _familyRepository;

  public CreateFamilyUseCase(IFamilyRepository familyRepository, IMapper mapper)
  {
    _familyRepository = familyRepository;
    _mapper = mapper;
  }

  public async Task Invoke (CreateFamilyViewModel vm)
  {
    var familyMenber = vm.FamilyMembers.Select(member => 
    {
      return FamilyMember.New(member.UserId, member.Position, member.IsOwner);
    }).ToList();

    // 家族とそのメンバーを作成
    var family = Family.Create(vm.Name, familyMenber);

    // 家族作成
    await _familyRepository.Create(family);
  }
}