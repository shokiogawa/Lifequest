using Lifequest.Src.Domain.Entity;
using Lifequest.Src.Infrastructure.Db;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Lifequest.Src.Domain.IRepository;
using Lifequest.Src.Infrastructure.Db.Tables;
using Lifequest.Src;
using Lifequest.Src.UseCase.Query;
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

  public async Task<User?> Get(int id)
  {
    var query = from users in _dbContext.UserTable where users.Id == (uint)id select users;
    var userData = await query.FirstOrDefaultAsync();
    var user = 
    userData != null ? 
    User.fromRepository(
      userData.Id, 
      userData.Uid, 
      userData.Email, 
      userData.Name, 
      userData.Birthday, 
      userData.Age, 
      userData.Gender, 
      userData.DeletedAt, 
      userData.CreatedAt, 
      userData.UpdatedAt
    ) : null; 
    return user;
  }
}