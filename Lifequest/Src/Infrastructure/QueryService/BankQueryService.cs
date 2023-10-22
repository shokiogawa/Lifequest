using Lifequest.Src.Infrastructure.Db;
using AutoMapper;
using Lifequest.Src.ApplicationService.Query;
namespace Lifequest.Src.Infrastructure.Repository;

public class BankQueryService : IBankQueryService
{
  private readonly LifequestDbContext _dbContext;
  private readonly IMapper _mapper;

  public BankQueryService(LifequestDbContext dbContext, IMapper mapper)
  {
    _dbContext = dbContext;
    _mapper = mapper;
  }
}