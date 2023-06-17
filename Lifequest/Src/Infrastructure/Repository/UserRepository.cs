using Lifequest.Src.Domain.Entity;
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

  // public string Test(string name, int id)
  // {
  //   if(name == "test1")
  //   {
  //     return "test1だよ";
  //   }
  //   if(name == "test2")
  //   {
  //     return "test2だよ";
  //   }
  //   return "やあ";
  // }

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
}