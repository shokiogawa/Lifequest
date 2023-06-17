using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lifequest.Src.Infrastructure.Db.Tables;

[Table("banks")]
public class BankTable 
{
  [Key]
  [Required]
  [Column("id", TypeName = "int")]
  public uint Id {get; set;}

  [Column("family_id")]
  public uint FamilyId {get; set;}

  [Column("family_member_id")]
  public uint FamilymemberId {get; set;}

  [Required]

  [Column("name")]
  public string Name {get; set;}

  [Column("code")]
  public string? Code {get; set;}

  [Column("branch_number")]
  public UInt16? BranchNumber {get ;set;}

  [Column("branch_name", TypeName = "VARCHAR(16)")]

  public string? BranchName {get;set;}

  [Column("account_number")]
  public uint? AccountNumber {get; set;}

  [Required]

  [Column("total_amount")]
  public uint TotalAmount {get; set;}

  [Column("deleted_at")]
  public DateTime DeletedAt {get; set;}

  [Column("created_at")]
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public DateTime CreatedAt {get; set;}

  [Column("updated_at")]
  [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
  public DateTime UpdatedAt {get; set;}
}