using Lifequest.Src.Domain.IRepository;
using AutoMapper;
namespace Lifequest.Src.ApplicationService.UseCase.FixedCostUseCase.Query;

public class FetchFixedCostByFamilyIdUseCase
{
  private readonly IMapper _mapper;
  private readonly IFixedCostRepository _fixedCostRepository;

  public FetchFixedCostByFamilyIdUseCase(IMapper mapper, IFixedCostRepository fixedCostRepository)
  {
    _mapper = mapper;
    _fixedCostRepository = fixedCostRepository;
  }

  public async Task<List<FetchFixedCostByFamilyIdDto>> Invoke(uint familyId)
  {
    var result = await _fixedCostRepository.GetByFamilyId(familyId);
    return result.Select(_ => new FetchFixedCostByFamilyIdDto
    {
      Id = _.Id,
      FamilyId = _.FamilyId,
      Name = _.Name,
      Expose = _.Expose,
      CreatedAt = _.CreatedAt,
      UpdatedAt = _.UpdatedAt,
      DeletedAt = _.DeletedAt
    }).ToList();
  }
}