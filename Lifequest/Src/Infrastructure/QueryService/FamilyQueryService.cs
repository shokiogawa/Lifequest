using Lifequest.Src.Domain.Entity;
using Lifequest.Src.Infrastructure.Db;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Lifequest.Src.Domain.IRepository;
using Lifequest.Src.Infrastructure.Db.Tables;
using Lifequest.Src;
using Lifequest.Src.UseCase.Query;
using Lifequest.Src.UseCase.ReadModel;
namespace Lifequest.Src.Infrastructure.Repository;

public class FamilyQueryService : IFamilyQueryService
{
  private readonly LifequestDbContext _dbContext;
  private readonly IMapper _mapper;

  public FamilyQueryService(LifequestDbContext dbContext, IMapper mapper)
  {
    _dbContext = dbContext;
    _mapper = mapper;
  }
    public async Task<List<FamilyInfoReadModel>> GetList(string uuid)
  {
    // var query = 
    // from familyMemberOwn in _dbContext.FamilyMembersTable
    //   join family in _dbContext.FamilyTable 
    //    on new {Id = familyMemberOwn.FamilyId, DeletedAt = Constant.DeletedAt}
    //    equals new {family.Id, family.DeletedAt}
    //   join familyMembers in _dbContext.FamilyMembersTable
    //    on new {FamilyId = family.Id, DeletedAt = Constant.DeletedAt} equals new {familyMembers.FamilyId, familyMembers.DeletedAt}
    //   join users in _dbContext.UserTable on new {Id = familyMembers.UserId, DeletedAt = Constant.DeletedAt} equals new {users.Id,users.DeletedAt}
    // where familyMemberOwn.UserId == 1 && 
    //       familyMemberOwn.DeletedAt == Constant.DeletedAt
    // select new
    // {
    //   FamilyId = family.Id,
    //   Familyname = family.Name,
    //   Position = familyMemberOwn.Position,
    //   IsOwner = familyMemberOwn.IsOwner,
    //   FamilyMemberInfo = familyMembers,
    //   UserInfo = users
    // };

    var query = 
    from loginUser in _dbContext.UserTable
      join familyMember in _dbContext.FamilyMembersTable
       on new {UserId = loginUser.Id, DeletedAt = Constant.DeletedAt} 
       equals new {familyMember.UserId, familyMember.DeletedAt}
      join family in _dbContext.FamilyTable
       on new {Id = familyMember.FamilyId, DeletedAt = Constant.DeletedAt} 
       equals new {family.Id, family.DeletedAt}
      join familyMembers in _dbContext.FamilyMembersTable
       on new {FamilyId = family.Id, DeletedAt = Constant.DeletedAt} 
       equals new {familyMembers.FamilyId, familyMembers.DeletedAt}
      join users in _dbContext.UserTable 
       on new {Id = familyMembers.UserId, DeletedAt = Constant.DeletedAt} 
       equals new {users.Id, users.DeletedAt}
    where loginUser.Uid == uuid && loginUser.DeletedAt == Constant.DeletedAt
    select new 
    {
      FamilyId = family.Id,
      Familyname = family.Name,
      Position = familyMember.Position,
      IsOwner = familyMember.IsOwner,
      FamilyMemberInfo = familyMembers,
      UserInfo = users
    };


    var result = await query.ToListAsync();
    var familyList = result.GroupBy(_ => _.FamilyId).Select(_ => new FamilyInfoReadModel 
    {
      FamilyId = _.First().FamilyId,
      FamilyName = _.First().Familyname,
      Position = _.First().Position,
      IsOwner = _.First().IsOwner,
      FamilyMambers = _.Select(member => new FamilyMemberReadModel
      {
        UserId = member.UserInfo.Id,
        FamilymemberId = member.FamilyMemberInfo.Id,
        Name = member.UserInfo.Name,
        Position = member.FamilyMemberInfo.Position,
        IsOwner = member.FamilyMemberInfo.IsOwner
      }).ToList()
    }).ToList();
    return familyList;
  }
}