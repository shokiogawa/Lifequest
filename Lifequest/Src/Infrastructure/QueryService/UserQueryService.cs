using Lifequest.Src.Infrastructure.Db;
using AutoMapper;
using Lifequest.Src.ApplicationService.Query;
namespace Lifequest.Src.Infrastructure.Repository;

public class UserQueryService : IUserQueryService
{
  private readonly LifequestDbContext _dbContext;
  private readonly IMapper _mapper;

  public UserQueryService(LifequestDbContext dbContext, IMapper mapper)
  {
    _dbContext = dbContext;
    _mapper = mapper;
  }
}