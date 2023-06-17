using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lifequest.Src.Infrastructure.Db.Tables;

[Table("fixed_costs")]
public class FixedCostTable 
{
  [Key]
  [Required]
  [Column("id")]
  public uint Id {get; set;}

  [Required]
  [Column("family_id")]
  public uint FamilyId {get ;set;}

  [Required]
  [Column("name", TypeName = "VARCHAR(128)")]
  public string Name {get; set;}

  [Required]
  [Column("expense")]
  public uint Expose {get; set;}

  [Column("deleted_at")]
  public DateTime DeletedAt {get; set;}

  [Column("created_at")]
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public DateTime CreatedAt {get; set;}

  [Column("updated_at")]
  [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
  public DateTime UpdatedAt {get; set;}
}