using Lifequest.Src.Domain.IRepository;
using Lifequest.Src.Domain.Models.Families;
using AutoMapper;
namespace Lifequest.Src.ApplicationService.UseCase.FamilyUseCase.Command;

public class AddFamilyMemberUseCase
{
  private readonly IMapper _mapper;
  private readonly IFamilyRepository _familyRepository;

  public AddFamilyMemberUseCase(IMapper mapper, IFamilyRepository familyRepository)
  {
    _mapper = mapper;
    _familyRepository = familyRepository;
  }

  public async Task Invoke (AddFamilyMemberCommand cm)
  {
    // メンバーを作成
    var familyMemberList =  new List<FamilyMember>
    {
      FamilyMember.Create(cm.UserId,cm.FamilyId, cm.Position, cm.IsOwner),
    };
    await _familyRepository.AddFamilyMember(familyMemberList);
  }
}