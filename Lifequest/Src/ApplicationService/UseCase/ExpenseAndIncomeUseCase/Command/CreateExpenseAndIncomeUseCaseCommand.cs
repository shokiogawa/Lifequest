namespace Lifequest.Src.ApplicationService.UseCase.ExpenseAndIncomeUseCase.Command;

public class CreateExpenseAndIncomeUseCaseCommand
{
  /// <summary>
  /// 家族ID
  /// </summary>
  public ulong FamilyId{get; set;}
  /// <summary>
  /// 家族メンバーID
  /// </summary>
  public ulong FamilymemberId{get; set;}
  /// <summary>
  /// 大分類 - カテゴリー名
  /// </summary>
  public ulong ExpenseAndIncomeLargeCategoryId {get; set;}

  /// <summary>
  /// 小分類 - カテゴリー名
  /// </summary>
  public ulong ExpenseAndIncomeSmallCategoryId {get; set;}

  /// <summary>
  /// 値段
  /// </summary>
  public uint Amount {get; set;}

  /// <summary>
  /// 大分類名
  /// </summary>
  public string LargeCategoryName {get; set;} = "";

  /// <summary>
  /// 小分類名
  /// </summary>
  public string SmallCategoryName {get; set;} = "";

  /// <summary>
  /// 対象日
  /// </summary>
  public DateOnly TargetDate {get; set;}

  /// <summary>
  /// 出費
  /// </summary>
  public bool IsExpense {get; set;}
}