using Lifequest.Src.Domain.Models.Users;
using Lifequest.Src.Infrastructure.Db;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Lifequest.Src.Domain.IRepository;
using Lifequest.Src.Infrastructure.Db.Tables;
namespace Lifequest.Src.Infrastructure.Repository;

public class UserRepository : IUserRepository
{
  private readonly LifequestDbContext _dbContext;
  private readonly IMapper _mapper;

  public UserRepository(LifequestDbContext dbContext, IMapper mapper)
  {
    _dbContext = dbContext;
    _mapper = mapper;
  }

  /// <summary>
  /// ユーザー作成メソッド
  /// </summary>
  /// <param name="user"></param>
  /// <returns></returns>
  /// <exception cref="Exception"></exception>
  public async Task Create(User user)
  {
    var userDb = _mapper.Map<UserTable>(user);
    _dbContext.UserTable.Add(userDb);
    var result = await _dbContext.SaveChangesAsync();
    if (result <= 0)
    {
      throw new Exception("unable to create user");
    }
  }

  /// <summary>
  /// ユーザー情報取得メソッド
  /// </summary>
  /// <param name="id"></param>
  /// <returns></returns>
    public async Task<User> Get(uint id)
  {
    var query = from users in _dbContext.UserTable where users.Id == (uint)id select users;
    var userData = await query.FirstAsync();
    var user = 
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
    ); 
    return user;
  }
}