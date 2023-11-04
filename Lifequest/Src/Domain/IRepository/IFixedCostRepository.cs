using Lifequest.Src.Domain.Models.FixedCosts;
namespace Lifequest.Src.Domain.IRepository;

public interface IFixedCostRepository
{
  /// <summary>
  /// 固定費作成メソッド
  /// </summary>
  /// <param name="fixedCost"></param>
  /// <returns></returns>
  Task Create(FixedCost fixedCost);

  /// <summary>
  /// 家族の固定費取得メソッド
  /// </summary>
  /// <param name="familyId"></param>
  /// <returns></returns>
  Task<List<FixedCost>> GetByFamilyId(uint familyId);
}