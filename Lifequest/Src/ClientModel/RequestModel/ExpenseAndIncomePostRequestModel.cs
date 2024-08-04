using System.Text.Json.Serialization;
namespace Lifequest.Src.ClientModel.RequestModel;

public class ExpenseAndIncomePostRequestModel
{
  /// <summary>
  /// 家族ID
  /// </summary>
  [JsonPropertyName("family_id")]
  public ulong FamilyId{get; set;}
  /// <summary>
  /// 家族メンバーID
  /// </summary>
  [JsonPropertyName("family_member_id")]
  public ulong FamilymemberId{get; set;}
  /// <summary>
  /// 大分類 - カテゴリー名
  /// </summary>
  [JsonPropertyName("large_category_id")]
  public ulong ExpenseAndIncomeLargeCategoryId {get; set;}

  /// <summary>
  /// 小分類 - カテゴリー名
  /// </summary>
  [JsonPropertyName("small_category_id")]
  public ulong ExpenseAndIncomeSmallCategoryId {get; set;}

  /// <summary>
  /// 値段
  /// </summary>
  [JsonPropertyName ("amount")]
  public uint Amount {get; set;}

  /// <summary>
  /// 大分類名
  /// </summary>
  [JsonPropertyName("large_category_name")]
  public string LargeCategoryName {get; set;} = "";

  /// <summary>
  /// 小分類名
  /// </summary>
  [JsonPropertyName("small_category_name")]
  public string SmallCategoryName {get; set;} = "";

  /// <summary>
  /// 支出、入金日
  /// </summary>
  [JsonPropertyName("target_date")]
  public DateOnly TargetDate {get; set;}

  [JsonPropertyName("is_expense")]
  public bool IsExpense {get; set;}
}