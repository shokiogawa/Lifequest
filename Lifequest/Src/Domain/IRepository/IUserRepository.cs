using Lifequest.Src.Domain.Entity;
using Lifequest.Src.Infrastructure.Db;
namespace Lifequest.Src.Domain.IRepository;

public interface IUserRepository
{
  /// <summary>
  /// ユーザー作成メソッド
  /// </summary>
  /// <param name="user"></param>
  /// <returns></returns>
  Task Create(User user);

  /// <summary>
  /// ユーザー情報取得メソッド
  /// </summary>
  /// <param name="id"></param>
  /// <returns></returns>
  Task<User> Get(uint id);
}