using Lifequest.Src.Domain.Models.Banks;
using Lifequest.Src.Domain.Models.BankHistory;
using Lifequest.Src.Domain.Models.ExpenseAndIncome;
namespace Lifequest.Src.Domain.IRepository;

public interface IExpenseAndIncomeRepository
{
  /// <summary>
  /// periodの前後の期間のデータを取得
  /// </summary>
  /// <returns></returns>
  Task<List<ExpenseAndIncome>> FetchListBetweentargetPeriod(ulong familyId, ulong familymemberId, uint period);

  /// <summary>
  /// 今月の支出、収入を取得する。
  /// </summary>
  /// <param name="familyId"></param>
  /// <param name="familymemberId"></param>
  /// <returns></returns>
  Task<List<ExpenseAndIncome>> FetchListForCurrentMonth(ulong familyId, ulong familymemberId);

  /// <summary>
  /// 支出・収入を作成
  /// </summary>
  /// <param name="expenseAndIncome"></param>
  /// <returns></returns>
  Task Create(ExpenseAndIncome expenseAndIncome);
}