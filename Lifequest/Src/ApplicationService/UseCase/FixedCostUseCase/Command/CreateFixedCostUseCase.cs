using Lifequest.Src.Domain.IRepository;
using Lifequest.Src.Domain.Models.FixedCosts;
using AutoMapper;
namespace Lifequest.Src.ApplicationService.UseCase.FixedCostUseCase.Command;

public class CreateFixedCostUseCase
{
  private readonly IMapper _mapper;
  private readonly IFixedCostRepository _fixedCostRepository;

  public CreateFixedCostUseCase(IFixedCostRepository fixedCostRepository, IMapper mapper)
  {
    _fixedCostRepository = fixedCostRepository;
    _mapper = mapper;
  }

  public async Task Invoke(CreateFixedCostCommand cm)
  {
    // Bankオブジェクト生成
    FixedCost fixedCost = FixedCost.Create(cm.FamilyId, cm.Name, cm.Expose);
    // 家族作成
    await _fixedCostRepository.Create(fixedCost);
  }
}