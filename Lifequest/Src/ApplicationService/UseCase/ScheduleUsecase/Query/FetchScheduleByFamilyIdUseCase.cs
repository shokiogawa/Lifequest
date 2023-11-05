using Lifequest.Src.Domain.IRepository;
using AutoMapper;
namespace Lifequest.Src.ApplicationService.UseCase.ScheduleUseCase.Query;

public class FetchScheduleByFamilyIdUseCase
{
  private readonly IMapper _mapper;
  private readonly IScheduleRepository _scheduleRepository;

  public FetchScheduleByFamilyIdUseCase(IMapper mapper, IScheduleRepository scheduleRepository)
  {
    _mapper = mapper;
    _scheduleRepository = scheduleRepository;
  }

  public async Task<List<FetchScheduleByFamilyIdDto>> Invoke(uint familyId)
  {
    var result = await _scheduleRepository.GetListByFamilyId(familyId);

    return result.Select(_ => new FetchScheduleByFamilyIdDto
    {
      Id = _.Id,
      FamilyId = _.FamilyId,
      Title = _.Title,
      Content = _.Content,
      StartDateTime = _.StartDateTime,
      EndDateTime = _.EndDateTime,
      IsAllDayFlag = _.IsAllDayFlag,
      CreatedUserId = _.CreatedUserId,
      DeletedAt = _.DeletedAt,
      CreatedAt = _.CreatedAt,
      UpdatedAt = _.UpdatedAt
    }).ToList();
  }
}