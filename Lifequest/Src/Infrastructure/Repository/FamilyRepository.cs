using Lifequest.Src.Domain.Models.Families;
using Lifequest.Src.Infrastructure.Db;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Lifequest.Src.Domain.IRepository;
using Lifequest.Src.Infrastructure.Db.Tables;
namespace Lifequest.Src.Infrastructure.Repository;

public class FamilyRepository : IFamilyRepository
{
  private readonly LifequestDbContext _dbContext;
  private readonly IMapper _mapper;

  public FamilyRepository(LifequestDbContext dbContext, IMapper mapper)
  {
    _dbContext = dbContext;
    _mapper = mapper;
  }

  /// <summary>
  /// 家族取得メソッド
  /// </summary>
  /// <param name="id"></param>
  /// <returns></returns>
  public async Task<Family?> Get(int id)
  {
    var query = from families in _dbContext.FamilyTable where families.Id == (uint)id select families;
    var familyData = await query.FirstOrDefaultAsync();
    var family = familyData != null ? Family.FromRepository(familyData.Id, familyData.Name, familyData.DeletedAt, familyData.CreatedAt, familyData.UpdatedAt) : null;
    return family;
  }

  /// <summary>
  /// 家族作成メソッド
  /// </summary>
  /// <param name="family"></param>
  /// <returns>
  /// 作成した家族IDを返す。
  /// </returns>
  public async Task<uint> Create(Family family)
  {
    using (var transaction = await _dbContext.Database.BeginTransactionAsync())
    {
        // family登録
        var familyData = _mapper.Map<FamilyTable>(family);
        await _dbContext.FamilyTable.AddAsync(familyData);
        var affectedRow = await _dbContext.SaveChangesAsync();
        if(affectedRow <= 0)
        {
          throw new Exception("family data can not be saved");
        }
        var familyId = await GetNewFamilyId();
        return familyId;
    }
  }

  /// <summary>
  /// 新規家族メンバー追加メソッド
  /// </summary>
  /// <param name="member"></param>
  /// <returns></returns>
  /// <exception cref="Exception"></exception>
  public async Task AddFamilyMember(List<FamilyMember> members)
  {
    var famuliMemberDataList = members.Select(member => _mapper.Map<FamilyMembersTable>(member)).ToList();
    await _dbContext.FamilyMembersTable.AddRangeAsync(famuliMemberDataList);
    var result = await _dbContext.SaveChangesAsync();
    if (result <= 0)
    {
      throw new Exception("family member can not be added");
    }
  }

  /// <summary>
  /// 最新の家族IDを取得するメソッド
  /// </summary>
  /// <returns></returns>
  private async Task<uint> GetNewFamilyId()
  {
    var familyId = await _dbContext.FamilyTable.Select(e => e.Id).OrderByDescending(Id => Id).FirstOrDefaultAsync();
    return familyId;
  }
}