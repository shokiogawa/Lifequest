using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lifequest.Src.Infrastructure.Db.Tables;

[Table("security_account_amountes")]
public class SecurityAccountAmmountTable 
{
  [Key]
  [Required]
  [Column("id")]
  public uint Id {get; set;}

  [Required]

  [Column("bank_id")]
  public uint SecurityAccountId {get; set;}

  [Required]

  [Column("total_amount")]

  public uint TotalAmount {get ;set;}

  [Required]

  [Column("differences_amount")]
  public int DifferencesAmount {get; set;}

  [Required]
  [Column("differences_rate")]
  public double DifferencesRate{get; set;}

  [Required]
  [Column("date")]
  public DateTime Date {get; set;}

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