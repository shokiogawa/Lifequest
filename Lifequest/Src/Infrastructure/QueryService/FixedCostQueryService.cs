using Lifequest.Src.Domain.Entity;
using Lifequest.Src.Infrastructure.Db;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Lifequest.Src.UseCase.Query;
namespace Lifequest.Src.Infrastructure.Repository;

public class FixedCostQueryService : IFixedCostQueryService
{
  private readonly LifequestDbContext _dbContext;
  private readonly IMapper _mapper;

  public FixedCostQueryService(LifequestDbContext dbContext, IMapper mapper)
  {
    _dbContext = dbContext;
    _mapper = mapper;
  }

  public async Task<List<FixedCost>> GetByFamilyId(int familyId)
  {
    var query = from fixedCosts in _dbContext.FixedCostTable 
                where fixedCosts.FamilyId == familyId && 
                      fixedCosts.DeletedAt == Constant.DeletedAt 
                select fixedCosts;

    var fixedCostDataList = await query.ToListAsync();
    var fixedCostList = fixedCostDataList.Select(
      data => FixedCost.FromRepository(
        data.Id, 
        data.FamilyId,
        data.Name, 
        data.Expose, 
        data.DeletedAt, 
        data.CreatedAt, 
        data.UpdatedAt
      )).ToList();
    return fixedCostList;
  }
}