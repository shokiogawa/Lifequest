using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lifequest.Src.Infrastructure.Db.Tables;

[Table("expense_and_incomes")]
public class ExpenseAndIncomeTable{
  [Key]
  [Required]
  [Column("id")]
  public ulong Id {get; set;}

  [Required]
  [Column("family_id")]
  public ulong FamilyId {get; set;}

  [Required]
  [Column("family_member_id")]
  public ulong FamilyMemberId {get; set;}

  [Required]
  [Column("expense_and_income_large_category_id")]
  public ulong ExpenseAndIncomeLargeCategoryId {get; set;}

  [Required]
  [Column("expense_and_income_small_category_id")]
  public ulong ExpenseAndIncomeSmallCategoryId {get; set;}

  [Required]
  [Column("amount")]
  public uint Amount {get; set;}

  [Required]
  [Column("large_category_name", TypeName ="VARCHAR(32)")]
  public string LargeCategoryName {get; set;} = "";

  [Required]
  [Column("small_category_name", TypeName ="VARCHAR(32)")]
  public string SmallCategoryName {get; set;} = "";

  [Required]
  [Column("target_date")]
  public DateOnly Targetdate {get; set;}

  [Column("memo", TypeName ="VARCHAR(255)")]
  public string? Memo {get; set;}

  [Required]
  [Column("is_expense")]
  public bool isExpense {get; set;}

  [Column("deleted_at")]
  public DateTime DeletedAt {get; set;}

  [Column("created_at")]
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public DateTime CreatedAt {get; set;}

  [Column("updated_at")]
  [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
  public DateTime UpdatedAt {get; set;}
}