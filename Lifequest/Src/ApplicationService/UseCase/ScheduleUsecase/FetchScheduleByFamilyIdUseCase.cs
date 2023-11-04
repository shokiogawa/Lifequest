using Lifequest.Src.Domain.IRepository;
using Lifequest.Src.Domain.Models.Schedules;
using AutoMapper;
namespace Lifequest.Src.ApplicationService.UseCase.ScheduleUseCase;

public class FetchScheduleByFamilyIdUseCase
{
  private readonly IMapper _mapper;
  private readonly IScheduleRepository _scheduleRepository;

  public FetchScheduleByFamilyIdUseCase(IMapper mapper, IScheduleRepository scheduleRepository)
  {
    _mapper = mapper;
    _scheduleRepository = scheduleRepository;
  }

  public async Task<List<Schedule>> Invoke(uint familyId)
  {
    return await _scheduleRepository.GetListByFamilyId(familyId);
  }
}