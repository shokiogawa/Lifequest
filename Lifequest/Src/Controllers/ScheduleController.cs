using Microsoft.AspNetCore.Mvc;
using Lifequest.Src.ViewModel;
using AutoMapper;
using Lifequest.Src.ApplicationService.UseCase.ScheduleUseCase;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Lifequest.Src.Domain.Entity;
using Lifequest.Src.ViewModel.ResponseModel;

namespace Lifequest.Src.Controllers;

// [Authorize]
[ApiController]
[Route("api/schedule")]

public class ScheduleController : ControllerBase
{
  private readonly IMapper _mapper;

  private readonly CreateScheduleUseCase _createScheduleUseCase;
  private readonly FetchScheduleByFamilyIdUseCase _fetchScheduleByFamilyIdUseCase;

  public ScheduleController(IMapper mapper, CreateScheduleUseCase createScheduleUseCase, FetchScheduleByFamilyIdUseCase fetchScheduleByFamilyIdUseCase)
  {
    _mapper = mapper;
    _createScheduleUseCase = createScheduleUseCase;
    _fetchScheduleByFamilyIdUseCase = fetchScheduleByFamilyIdUseCase;
  }

  /// <summary>
  /// 家族のスケジュールを取得するメソッド
  /// </summary>
  /// <param name="id"></param>
  /// <returns></returns>
  [HttpGet]
  [Route("family")]
  public async Task<ActionResult<ScheduleResponseModel>> GetListByFamilyIdAsync([FromQuery] uint id)
  {
    var scheduleList = await _fetchScheduleByFamilyIdUseCase.Invoke(id);
    var scheduleViewModelList = scheduleList.Select(schedule => 
    {
      return new ScheduleViewModel
      {
        Id = schedule.Id,
        FamilyId = schedule.FamilyId,
        Title = schedule.Title,
        Content = schedule.Content,
        StartDateTime = schedule.StartDateTime.ToString("yyyy-MM-dd HH:mm:ss"),
        EndDateTime = schedule.EndDateTime.ToString("yyyy-MM-dd HH:mm:ss"),
        IsAllDayFlag = schedule.IsAllDayFlag,
        CreatedUserId = schedule.CreatedUserId,
        DeletedAt = schedule.DeletedAt,
        UpdatedAt = schedule.UpdatedAt,
        CreatedAt = schedule.UpdatedAt
      };
    }).ToList();
    return new ScheduleResponseModel
    {
      ScheduleList = scheduleViewModelList
    };
  }
  
  /// <summary>
  /// スケジュールを作成するメソッド
  /// </summary>
  /// <param name="vm"></param>
  /// <returns></returns>
  [HttpPost]
  public async Task<IActionResult> CreateAsync([FromBody] ScheduleViewModel vm)
  {
    Console.WriteLine(vm.FamilyId);
    await _createScheduleUseCase.Invoke(vm);
    return Ok();
  }
}