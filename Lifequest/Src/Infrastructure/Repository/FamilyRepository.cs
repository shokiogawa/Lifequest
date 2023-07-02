using Lifequest.Src.Domain.Entity;
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

  /**
  family.idより家族データを取得(存在しなければ、nullが返る)
  **/
  public async Task<Family?> Get(int id)
  {
    var query = from families in _dbContext.FamilyTable where families.Id == (uint)id select families;
    var familyData = await query.FirstOrDefaultAsync();
    var family = familyData != null ? Family.FromRepository(familyData.Id, familyData.Name, familyData.DeletedAt, familyData.CreatedAt, familyData.UpdatedAt) : null;
    return family;
  }
  
  /**
  Family作成リポジトリ
  説明: FamilyMenberと同時作成になるので、同一トランザクション内で作成する。
  **/
  public async Task Create(Family family)
  {
    using (var transaction = await _dbContext.Database.BeginTransactionAsync())
    {
      try
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

        // FamilyMemberをDBの型に変換する。
        var familyMemberData = family.FamilyMembers.Select(member => 
        {
          member.AddFamilyId(familyId);
          return _mapper.Map<FamilyMembersTable>(member);
        });
        // FamilyMember登録
        await _dbContext.FamilyMembersTable.AddRangeAsync(familyMemberData);
        affectedRow = await _dbContext.SaveChangesAsync();
        if(affectedRow <= 0)
        {
          throw new Exception("userFamily data can not be saved");
        }
        await transaction.CommitAsync();
      }
      catch(Exception e)
      {
        await transaction.RollbackAsync();
        throw e;
      }

    }
  }

  /**
  家族メンバー追加メソッド
  **/
  public async Task AddFamilyMember(FamilyMember member)
  {
    var famuliMemberData = _mapper.Map<FamilyMembersTable>(member);
    await _dbContext.FamilyMembersTable.AddAsync(famuliMemberData);
    var result = await _dbContext.SaveChangesAsync();
    if (result <= 0)
    {
      throw new Exception("family member can not be added");
    }
  }

  ///
  ///概要:  最新のfamilyIdを取得する。
  ///
  private async Task<uint> GetNewFamilyId()
  {
    var familyId = await _dbContext.FamilyTable.Select(e => e.Id).OrderByDescending(Id => Id).FirstOrDefaultAsync();
    return familyId;
  }
}