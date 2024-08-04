using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lifequest.Src.Infrastructure.Db.Tables;

[Table("expense_and_income_large_category_master")]
public class ExpenseAndIncomeLargeCategoryMasterTable{
  [Key]
  [Required]
  [Column("id")]
  public ulong Id {get; set;}

  [Required]
  [MaxLength(32)]
  [Column("large_category_name")]
  public string LargeCategoryName {get; set;} = "";

  [Column("deleted_at")]
  public DateTime DeletedAt {get; set;}

  [Column("created_at")]
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public DateTime CreatedAt {get; set;}

  [Column("updated_at")]
  [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
  public DateTime UpdatedAt {get; set;}
}