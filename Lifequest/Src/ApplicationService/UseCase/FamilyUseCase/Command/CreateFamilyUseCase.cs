using Lifequest.Src.Domain.IRepository;
using Lifequest.Src.Domain.Models.Families;
using AutoMapper;
using System.Transactions;
namespace Lifequest.Src.ApplicationService.UseCase.FamilyUseCase.Command;

public class CreateFamilyUseCase
{
  private readonly IMapper _mapper;
  private readonly IFamilyRepository _familyRepository;

  public CreateFamilyUseCase(IFamilyRepository familyRepository, IMapper mapper)
  {
    _familyRepository = familyRepository;
    _mapper = mapper;
  }

  public async Task Invoke (CreateFamilyCommand cm)
  {
    // トランザクションを貼る
    using (var transactionScope = new TransactionScope())
    {
    // 1. 家族とそのメンバーを作成
    var family = Family.Create(cm.Name);
    // 家族保存
    var familyId = await _familyRepository.Create(family);

    // 2. 家族メンバー作成
    var familyMenber = cm.FamilyMembers.Select(member => 
    {
      return FamilyMember.Create(member.UserId,familyId, member.Position, member.IsOwner);
    }).ToList();
    // 家族にメンバーを追加
    await _familyRepository.AddFamilyMember(familyMenber);
    
    // 3. トランザクション終了
    transactionScope.Complete();
    }
  }
}