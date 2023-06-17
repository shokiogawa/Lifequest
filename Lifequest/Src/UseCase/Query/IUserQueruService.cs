using Lifequest.Src.Domain.IRepository;
using Lifequest.Src.Domain.Entity;
namespace Lifequest.Src.UseCase.Query;

public interface IUserQueryService
{
  Task<User?> Get(int id);
}