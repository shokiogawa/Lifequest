using Lifequest.Src.Domain.IRepository;
using Lifequest.Src.Domain.Models.Families;
using Lifequest.Src.ViewModel;
using AutoMapper;
namespace Lifequest.Src.ApplicationService.UseCase.FamilyUseCase;

public class AddFamilyMember
{
  private readonly IMapper _mapper;
  private readonly IFamilyRepository _familyRepository;

  public AddFamilyMember(IMapper mapper, IFamilyRepository familyRepository)
  {
    _mapper = mapper;
    _familyRepository = familyRepository;
  }

  public async Task Invoke (FamilyMemberViewModel vm)
  {
    // メンバーを作成
    var familyMemberList =  new List<FamilyMember>
    {
      FamilyMember.Create(vm.UserId,vm.FamilyId, vm.Position, vm.IsOwner),
    };
    await _familyRepository.AddFamilyMember(familyMemberList);
  }
}