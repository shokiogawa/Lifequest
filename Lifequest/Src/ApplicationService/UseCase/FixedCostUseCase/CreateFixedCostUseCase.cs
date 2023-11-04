using Lifequest.Src.Domain.IRepository;
using Lifequest.Src.Domain.Models.FixedCosts;
using Lifequest.Src.ViewModel;
using AutoMapper;
namespace Lifequest.Src.ApplicationService.UseCase.FixedCostUseCase;

public class CreateFixedCostUseCase
{
  private readonly IMapper _mapper;
  private readonly IFixedCostRepository _fixedCostRepository;

  public CreateFixedCostUseCase(IFixedCostRepository fixedCostRepository, IMapper mapper)
  {
    _fixedCostRepository = fixedCostRepository;
    _mapper = mapper;
  }

  public async Task Invoke(FixedCostViewModel vm)
  {
    // Bankオブジェクト生成
    FixedCost fixedCost = FixedCost.Create(vm.FamilyId, vm.Name, vm.Expose);
    // 家族作成
    await _fixedCostRepository.Create(fixedCost);
  }
}