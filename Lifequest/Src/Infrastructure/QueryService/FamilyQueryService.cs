using Lifequest.Src.Infrastructure.Db;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Lifequest.Src.ApplicationService.IQueryService;
using Lifequest.Src.ApplicationService.UseCase.FamilyUseCase.Query;
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
    public async Task<List<FetchFamilyListUseCaseDto>> GetList(string uuid)
  {
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
      familyMember.Position,
      familyMember.IsOwner,
      FamilyMemberInfo = familyMembers,
      UserInfo = users
    };


    var result = await query.ToListAsync();
    // TODO: メモリを食うので要注意
    var familyList = result.GroupBy(_ => _.FamilyId).Select(_ => new FetchFamilyListUseCaseDto
    {
      FamilyId = _.First().FamilyId,
      FamilyName = _.First().Familyname,
      Position = _.First().Position,
      IsOwner = _.First().IsOwner,
      FamilyMambers = _.Select(member => new FamilyMemberDto
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