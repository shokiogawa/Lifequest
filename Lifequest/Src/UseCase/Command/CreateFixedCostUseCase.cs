using Lifequest.Src.Domain.IRepository;
using Lifequest.Src.Domain.Entity;
using Lifequest.Src.ViewModel;
using AutoMapper;
namespace Lifequest.Src.UseCase.Command;

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
    FixedCost fixedCost = FixedCost.New(vm.FamilyId, vm.Name, vm.Expose);
    // 家族作成
    await _fixedCostRepository.Create(fixedCost);
  }
}