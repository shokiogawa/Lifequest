using Lifequest.Src.Domain.IRepository;
using Lifequest.Src.Domain.Models.Schedules;
using Lifequest.Src.ViewModel;
using AutoMapper;
namespace Lifequest.Src.ApplicationService.UseCase.ScheduleUseCase.Command;

public class CreateScheduleUseCase
{
  private readonly IMapper _mapper;
  private readonly IScheduleRepository _scheduleRepository;

  public CreateScheduleUseCase(IMapper mapper, IScheduleRepository scheduleRepository)
  {
    _mapper = mapper;
    _scheduleRepository = scheduleRepository;
  }

  public async Task Invoke(CreateScheduleCommand cm)
  {
    var newSchedule = Schedule.Create(
      cm.FamilyId, 
      cm.Title, 
      cm.Content, 
      cm.StartDateTime, 
      cm.EndDateTime, 
      cm.IsAllDayFlag
    );
    await _scheduleRepository.Create(newSchedule);
  }
}