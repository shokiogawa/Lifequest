using Lifequest.Src.Domain.Models.Families;
namespace Lifequest.Src.Domain.IRepository;

public interface IFamilyRepository
{
  /// <summary>
  /// 家族データ取得API
  /// </summary>
  /// <param name="id"></param>
  /// <returns></returns>
  Task<Family?> Get(int id);

  /// <summary>
  /// 家族作成API
  /// </summary>
  /// <param name="family"></param>
  /// <returns></returns>
  Task<uint> Create(Family family);

  /// <summary>
  /// 家族追加API
  /// </summary>
  /// <param name="member"></param>
  /// <returns></returns>

  Task AddFamilyMember(List<FamilyMember> member);
}