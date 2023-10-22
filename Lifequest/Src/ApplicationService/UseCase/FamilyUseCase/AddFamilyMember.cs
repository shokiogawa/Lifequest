using Lifequest.Src.Domain.IRepository;
using Lifequest.Src.Domain.Entity;
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
    var familyMember = FamilyMember.New(vm.UserId, vm.Position, vm.IsOwner);
    // 所属家族を紐付け
    familyMember.AddFamilyId(vm.FamilyId);
    await _familyRepository.AddFamilyMember(familyMember);
  }
}