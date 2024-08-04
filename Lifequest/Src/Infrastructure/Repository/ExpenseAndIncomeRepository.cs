using Lifequest.Src.Infrastructure.Db;
using Microsoft.EntityFrameworkCore;
using Lifequest.Src.Infrastructure.Db.Tables;
using Lifequest.Src.Domain.Models.ExpenseAndIncome;
using Lifequest.Src.Domain.IRepository;
namespace Lifequest.Src.Infrastructure.Repository;

public class ExpenseAndIncomeRepository : IExpenseAndIncomeRepository
{
  private readonly LifequestDbContext _dbContext;
  private readonly ILogger<ExpenseAndIncome> _logger;

  public ExpenseAndIncomeRepository(
    LifequestDbContext dbContext,
    ILogger<ExpenseAndIncome> logger)
  {
    _dbContext = dbContext;
    _logger = logger;
  }

  /// <summary>
  /// periodの前後の期間のデータを取得
  /// </summary>
  /// <returns></returns>
  public async Task<List<ExpenseAndIncome>> FetchListBetweentargetPeriod(ulong familyId, ulong familymemberId, uint period)
  {
    var today = DateTime.Today;
    var currentYear = today.Year;
    var currentMonth = today.Month;
    var startMonth = new DateOnly(currentYear, currentMonth ,1).AddYears(-(int)period);
    var endMonth = new DateOnly(currentYear, currentMonth, 1).AddYears((int)period).AddMonths(1).AddDays(-1);

    var query = from exposeAndIncome in _dbContext.ExpenseAndIncomeTable 
                where exposeAndIncome.FamilyId == familyId && 
                      exposeAndIncome.FamilyMemberId == familymemberId && 
                      exposeAndIncome.DeletedAt == Constant.DeletedAt &&
                      exposeAndIncome.Targetdate >= startMonth && exposeAndIncome.Targetdate <= endMonth
                      orderby exposeAndIncome.Targetdate ascending
                select exposeAndIncome;
    
    var result = await query.ToListAsync();
    var exposeAndIncomeList = result.Select((_)=>{
      return ExpenseAndIncome.ReConstructor(
        _.Id,
        _.FamilyId,
        _.FamilyMemberId,
        _.ExpenseAndIncomeLargeCategoryId,
        _.ExpenseAndIncomeSmallCategoryId,
        _.Amount,
        _.LargeCategoryName,
        _.SmallCategoryName,
        _.isExpense,
        _.Targetdate,
        _.DeletedAt,
        _.CreatedAt,
        _.UpdatedAt
        );
    }).ToList();
    return exposeAndIncomeList;
  }

  /// <summary>
  /// 今月の支出、収入を取得する。
  /// </summary>
  /// <param name="familyId"></param>
  /// <param name="familymemberId"></param>
  /// <returns></returns>
  public async Task<List<ExpenseAndIncome>> FetchListForCurrentMonth(ulong familyId, ulong familymemberId)
  {
    var currentDate = DateTime.Now;
    var startDate = new DateOnly(currentDate.Year, currentDate.Month, 1);
    var endDate = new DateOnly(currentDate.Year, currentDate.Month,1).AddMonths(1).AddDays(-1);
    var query = from expenseAndIncome in _dbContext.ExpenseAndIncomeTable
                where expenseAndIncome.FamilyId == familyId && 
                      expenseAndIncome.FamilyMemberId == familymemberId && 
                      expenseAndIncome.DeletedAt == Constant.DeletedAt &&
                      expenseAndIncome.Targetdate <= endDate && 
                      expenseAndIncome.Targetdate >= startDate
                select expenseAndIncome;
    var result = await query.ToListAsync();
    var expenseAndIncomeList = result.Select((_)=>{
      return ExpenseAndIncome.ReConstructor(
        _.Id,
        _.FamilyId,
        _.FamilyMemberId,
        _.ExpenseAndIncomeLargeCategoryId,
        _.ExpenseAndIncomeSmallCategoryId,
        _.Amount,
        _.LargeCategoryName,
        _.SmallCategoryName,
        _.isExpense,
        _.Targetdate,
        _.DeletedAt,
        _.CreatedAt,
        _.UpdatedAt
      );
    }).ToList();
    return expenseAndIncomeList;
  }

  /// <summary>
  /// 支出・収入を作成
  /// </summary>
  /// <param name="expenseAndIncome"></param>
  /// <returns></returns>
  public async Task Create(ExpenseAndIncome expenseAndIncome)
  {
    try
    {
      var data = new ExpenseAndIncomeTable
      {
        FamilyId = expenseAndIncome.FamilyId,
        FamilyMemberId = expenseAndIncome.FamilymemberId,
        ExpenseAndIncomeLargeCategoryId = expenseAndIncome.ExpenseAndIncomeLargeCategoryId,
        ExpenseAndIncomeSmallCategoryId = expenseAndIncome.ExpenseAndIncomeSmallCategoryId,
        LargeCategoryName = expenseAndIncome.LargeCategoryName,
        SmallCategoryName = expenseAndIncome.SmallCategoryName,
        isExpense = expenseAndIncome.isExpense,
        Amount = expenseAndIncome.Amount,
        Targetdate = expenseAndIncome.TargetDate
      };
      var result = await _dbContext.ExpenseAndIncomeTable.AddAsync(data);
      var affectedRow = await _dbContext.SaveChangesAsync();
      if(affectedRow <= 0)
      {
        throw new Exception("ExpenseAndIncomeデータが作成できませんでした。");
      }
    }catch(Exception e)
    {
    _logger.LogError(e, "支出作成処理でエラーが発生しました。パラメーターをご確認ください。 {FamilyId}, {FamilymemberId}", expenseAndIncome.FamilyId, expenseAndIncome.FamilymemberId);
      throw;
    };
  }
}