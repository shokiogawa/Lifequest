using Lifequest.Src.Domain.Entity;
using Lifequest.Src.Infrastructure.Db;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Lifequest.Src.Domain.IRepository;
using Lifequest.Src.Infrastructure.Db.Tables;
namespace Lifequest.Src.Infrastructure.Repository;

public class FixedCostRepository : IFixedCostRepository
{
  private readonly LifequestDbContext _dbContext;
  private readonly IMapper _mapper;

  public FixedCostRepository(LifequestDbContext dbContext, IMapper mapper)
  {
    _dbContext = dbContext;
    _mapper = mapper;
  }

  public async Task Create(FixedCost fixedCost)
  {
    var fixedCostData = _mapper.Map<FixedCostTable>(fixedCost);
    _dbContext.FixedCostTable.Add(fixedCostData);
    var result = await _dbContext.SaveChangesAsync();
    if (result <= 0)
    {
      throw new Exception("unable to create fixed cost");
    }
  }
}