using Lifequest.Src.Domain.Models.Families;

namespace Lifequest.Src.Domain.Models.ExpenseAndIncome;

/// <summary>
/// 支出モデル
/// </summary>
public class ExpenseAndIncome
{
  public ulong Id {get; private set;}
  /// <summary>
  /// 家族ID
  /// </summary>
  public ulong FamilyId{get; private set;}
  /// <summary>
  /// 家族メンバーID
  /// </summary>
  public ulong FamilymemberId{get; private set;}
  /// <summary>
  /// 大分類 - カテゴリー名
  /// </summary>
  public ulong ExpenseAndIncomeLargeCategoryId {get; private set;}

  /// <summary>
  /// 小分類 - カテゴリー名
  /// </summary>
  public ulong ExpenseAndIncomeSmallCategoryId {get; private set;}

  /// <summary>
  /// 値段
  /// </summary>
  public uint Amount {get; private set;}

  /// <summary>
  /// 大分類名
  /// </summary>
  public string LargeCategoryName {get; set;} = "";

  /// <summary>
  /// 小分類名
  /// </summary>
  public string SmallCategoryName {get; set;} = "";

  /// <summary>
  /// 支出、入金日
  /// </summary>
  public DateOnly TargetDate {get; set;}

  /// <summary>
  /// 支出か、収入か
  /// </summary>
  public bool isExpense {get; set;}

  public DateTime DeletedAt {get; set;}
  public DateTime CreatedAt {get; set;}

  public DateTime UpdatedAt {get; set;}

  /// <summary>
  /// コンストラクタ
  /// </summary>
  /// <param name="familyid"></param>
  /// <param name="familyMemberId"></param>
  /// <param name="expenseAndIncomeLargeCategoryId"></param>
  /// <param name="expenseAndIncomeSmallCategoryId"></param>
  /// <param name="amount"></param>
  /// <param name="largeCategoryName"></param>
  /// <param name="smallCategoryName"></param>
  /// <param name="targetDate"></param>
  /// <returns></returns>
  public static ExpenseAndIncome Create(
    ulong familyid,
    ulong familyMemberId,
    ulong expenseAndIncomeLargeCategoryId,
    ulong expenseAndIncomeSmallCategoryId,
    uint amount,
    string largeCategoryName,
    string smallCategoryName,
    DateOnly targetDate,
    bool isExpense
  )
  {
    if(familyid == default)
    {
      throw new ArgumentException(nameof(familyid));
    }
    if(familyMemberId == default)
    {
      throw new ArgumentException(nameof(familyMemberId));
    }
    if(amount < 0)
    {
      throw new ArgumentNullException(nameof(amount));
    }
    if(string.IsNullOrEmpty(largeCategoryName))
    {
      throw new ArgumentNullException(nameof(largeCategoryName));
    }
    if(string.IsNullOrEmpty(smallCategoryName))
    {
      throw new ArgumentNullException(nameof(smallCategoryName));
    }
    return new ExpenseAndIncome
    {
      FamilyId = familyid,
      FamilymemberId = familyMemberId,
      ExpenseAndIncomeLargeCategoryId = expenseAndIncomeLargeCategoryId,
      ExpenseAndIncomeSmallCategoryId = expenseAndIncomeSmallCategoryId,
      Amount = amount,
      LargeCategoryName = largeCategoryName,
      SmallCategoryName = smallCategoryName,
      TargetDate = targetDate,
      isExpense = isExpense
    };
  }

  /// <summary>
  /// 再生成コンストラクタ
  /// </summary>
  /// <param name="id"></param>
  /// <param name="familyId"></param>
  /// <param name="familyMemberId"></param>
  /// <param name="expenseAndIncomeLargeCategoryId"></param>
  /// <param name="expenseAndIncomeSmallCategoryId"></param>
  /// <param name="amount"></param>
  /// <param name="largeCategoryName"></param>
  /// <param name="smallCategoryName"></param>
  /// <param name="targetDate"></param>
  /// <param name="deletedAt"></param>
  /// <param name="createdAt"></param>
  /// <param name="updatedAt"></param>
  /// <returns></returns>
  public static ExpenseAndIncome ReConstructor(
    ulong id,
    ulong familyId,
    ulong familyMemberId,
    ulong expenseAndIncomeLargeCategoryId,
    ulong expenseAndIncomeSmallCategoryId,
    uint amount,
    string largeCategoryName,
    string smallCategoryName,
    bool isExpense,
    DateOnly targetDate,
    DateTime deletedAt,
    DateTime createdAt,
    DateTime updatedAt
  )
  {
    return new ExpenseAndIncome
    {
    Id = id,
    FamilyId = familyId,
    FamilymemberId = familyMemberId,
    ExpenseAndIncomeLargeCategoryId = expenseAndIncomeLargeCategoryId,
    ExpenseAndIncomeSmallCategoryId = expenseAndIncomeSmallCategoryId,
    Amount = amount,
    LargeCategoryName = largeCategoryName,
    SmallCategoryName = smallCategoryName,
    TargetDate = targetDate,
    isExpense = isExpense,
    DeletedAt = deletedAt,
    CreatedAt = createdAt,
    UpdatedAt = updatedAt
    };
  }

  /// <summary>
  /// コンストラクタは内部でのみ使用可能
  /// </summary>
  private ExpenseAndIncome(){}

}