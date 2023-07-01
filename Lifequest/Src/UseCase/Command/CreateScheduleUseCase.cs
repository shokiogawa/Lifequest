using Lifequest.Src.Domain.IRepository;
using Lifequest.Src.Domain.Entity;
using Lifequest.Src.ViewModel;
using AutoMapper;
namespace Lifequest.Src.UseCase.Command;

public class CreateScheduleUseCase
{
  private readonly IMapper _mapper;
  private readonly IScheduleRepository _scheduleRepository;

  public CreateScheduleUseCase(IMapper mapper, IScheduleRepository scheduleRepository)
  {
    _mapper = mapper;
    _scheduleRepository = scheduleRepository;
  }

  public async Task Invoke(ScheduleViewModel vm)
  {
    var newSchedule = Schedule.New(
      vm.FamilyId, 
      vm.Title, 
      vm.Content, 
      DateTime.Parse(vm.StartDateTime), 
      DateTime.Parse(vm.EndDateTime), 
      vm.IsAllDayFlag
    );
    await _scheduleRepository.Create(newSchedule);
  }
}