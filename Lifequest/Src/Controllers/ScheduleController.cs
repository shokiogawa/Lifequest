using Microsoft.AspNetCore.Mvc;
using Lifequest.Src.UseCase.Query;
using Lifequest.Src.ViewModel;
using AutoMapper;
using Lifequest.Src.UseCase.Command;
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
  private readonly IScheduleQueryService _scheduleQueryService;

  public ScheduleController(IMapper mapper, CreateScheduleUseCase createScheduleUseCase, IScheduleQueryService scheduleQueryService)
  {
    _mapper = mapper;
    _createScheduleUseCase = createScheduleUseCase;
    _scheduleQueryService = scheduleQueryService;
  }

  [HttpGet]
  [Route("family")]
  public async Task<ActionResult<ScheduleResponseModel>> GetListByFamilyIdAsync([FromQuery] uint id)
  {
    var scheduleList = await _scheduleQueryService.GetListByFamilyId(id);
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
  // ユーザーが家族に属していることが条件
  [HttpPost]
  public async Task<IActionResult> CreateAsync([FromBody] ScheduleViewModel vm)
  {
    Console.WriteLine(vm.FamilyId);
    await _createScheduleUseCase.Invoke(vm);
    return Ok();
  }
}