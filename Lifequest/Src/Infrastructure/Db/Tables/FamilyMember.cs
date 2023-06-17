using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lifequest.Src.Infrastructure.Db.Tables;

[Table("family_members")]
public class FamilyMembersTable 
{
  [Key]
  [Required]
  [Column("id")]
  public uint Id {get; set;}

  [Required]
  [Column("user_id")]
  public uint UserId {get; set;}

  [Required]
  [Column("family_id")]
  public uint FamilyId {get; set;}

  [Required]
  [Column("is_owner", TypeName = "tinyint(1)")]
  public bool IsOwner {get; set;}

  [Required]
  [Column("position", TypeName = "VARCHAR(32)")]
  public string Position {get; set;}

    [Column("deleted_at")]
  public DateTime DeletedAt {get; set;}

  [Column("created_at")]
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public DateTime CreatedAt {get; set;}

  [Column("updated_at")]
  [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
  public DateTime UpdatedAt {get; set;}
}