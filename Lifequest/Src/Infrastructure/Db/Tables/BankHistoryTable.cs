using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lifequest.Src.Infrastructure.Db.Tables;

[Table("bank_histories")]
public class BankHistoryTable 
{
  [Key]
  [Required]
  [Column("id")]
  public uint Id {get; set;}

  [Required]

  [Column("bank_id")]
  public uint BankId {get; set;}

  [Required]

  [Column("total_amount_snapshot")]

  public uint TotalAmountSnapshot {get ;set;}

  [Required]

  [Column("differences_amount")]
  public int DifferencesAmount {get; set;}

  [Required]

  [Column("status", TypeName = "VARCHAR(32)")]
  public string Status {get;set;}

  [Column("deleted_at")]
  public DateTime DeletedAt {get; set;}

  [Column("created_at")]
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public DateTime CreatedAt {get; set;}

  [Column("updated_at")]
  [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
  public DateTime UpdatedAt {get; set;}
}