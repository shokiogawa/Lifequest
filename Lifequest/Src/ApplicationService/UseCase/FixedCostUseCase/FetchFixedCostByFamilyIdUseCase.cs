using Lifequest.Src.Domain.IRepository;
using Lifequest.Src.Domain.Entity;
using Lifequest.Src.ViewModel;
using AutoMapper;
namespace Lifequest.Src.ApplicationService.UseCase.FixedCostUseCase;

public class FetchFixedCostByFamilyIdUseCase
{
  private readonly IMapper _mapper;
  private readonly IFixedCostRepository _fixedCostRepository;

  public FetchFixedCostByFamilyIdUseCase(IMapper mapper, IFixedCostRepository fixedCostRepository)
  {
    _mapper = mapper;
    _fixedCostRepository = fixedCostRepository;
  }

  public async Task<List<FixedCost>> Invoke(uint familyId)
  {
    return await _fixedCostRepository.GetByFamilyId(familyId);
  }
}