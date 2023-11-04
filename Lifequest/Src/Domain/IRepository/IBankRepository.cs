using Lifequest.Src.Domain.Models.Banks;
using Lifequest.Src.Domain.Models.BankHistory;
namespace Lifequest.Src.Domain.IRepository;

public interface IBankRepository
{
  /// <summary>
  /// 銀行作成API
  /// </summary>
  /// <param name="bank"></param>
  /// <returns></returns>
  Task Create(Bank bank);
  /// <summary>
  /// 更新API
  /// </summary>
  /// <param name="bank"></param>
  /// <returns></returns>
  Task UpdateInfo(Bank bank);
  /// <summary>
  /// 貯金更新API
  /// </summary>
  /// <param name="newBank"></param>
  /// <param name="nabkHistory"></param>
  /// <returns></returns>
  Task UpdateTotalAmount(Bank newBank, BankHistory nabkHistory);

  /// <summary>
  /// IDを基にデータ取得API
  /// </summary>
  /// <param name="bankId"></param>
  /// <returns></returns>
  Task<Bank?> GetByIdAsync(uint bankId);

  /// <summary>
  /// 家族IDを基にデータ取得API
  /// </summary>
  /// <param name="familyId"></param>
  /// <returns></returns>

  Task<List<Bank>> FetchListByFamilyId(uint familyId);

  /// <summary>
  /// 銀行詳細データ取得API
  /// </summary>
  /// <param name="bankId"></param>
  /// <returns></returns>

  Task<Bank?> FetchDetail(uint bankId);
}