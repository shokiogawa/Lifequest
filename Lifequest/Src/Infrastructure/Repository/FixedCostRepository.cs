using Lifequest.Src.Domain.Models.FixedCosts;
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
  /// <summary>
  /// 固定費作成メソッド
  /// </summary>
  /// <param name="fixedCost"></param>
  /// <returns></returns>
  /// <exception cref="Exception"></exception>
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

  /// <summary>
  /// 家族の固定費取得メソッド
  /// </summary>
  /// <param name="familyId"></param>
  /// <returns></returns>
  public async Task<List<FixedCost>> GetByFamilyId(uint familyId)
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