using Lifequest.Src.Infrastructure.Db;
using AutoMapper;
using Lifequest.Src.ApplicationService.IQueryService;
namespace Lifequest.Src.Infrastructure.Repository;

public class ScheduleQueryService : IScheduleQueryService
{
  private readonly LifequestDbContext _dbContext;
  private readonly IMapper _mapper;
  public ScheduleQueryService(LifequestDbContext dbContext, IMapper mapper)
  {
    _dbContext = dbContext;
    _mapper = mapper;
  }
}