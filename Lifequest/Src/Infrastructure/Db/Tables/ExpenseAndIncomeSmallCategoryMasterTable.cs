using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lifequest.Src.Infrastructure.Db.Tables;

[Table("expense_and_income_small_category_master")]
public class ExpenseAndIncomeSmallCategoryMasterTable{
  [Key]
  [Required]
  [Column("id")]
  public ulong Id {get; set;}

  [Required]
  [Column("expense_and_income_large_category_id")]
  public ulong ExpenseAndIncomeLargeCategoryId {get; set;}

  [Required]
  [MaxLength(32)]
  [Column("small_category_name")]
  public string SmallCategoryName {get; set;} = "";

  [Column("deleted_at")]
  public DateTime DeletedAt {get; set;}

  [Column("created_at")]
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public DateTime CreatedAt {get; set;}

  [Column("updated_at")]
  [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
  public DateTime UpdatedAt {get; set;}
}