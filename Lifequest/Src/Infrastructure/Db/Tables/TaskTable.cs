using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace Lifequest.Src.Infrastructure.Db.Tables;

[Table("tasks")]
public class TaskTable 
{
  [Key]
  [Required]
  [Column("id")]
  public uint Id {get; set;}

  [Required]
  [Column("family_member_id")]
  public uint FamilyMemberId {get; set;}

  [Required]
  [Column("title", TypeName = "VARCHAR(128)")]
  public string Title {get; set;}


  [Required]
  [Column("category", TypeName = "VARCHAR(64)")]
  public string Category {get; set;}

  [Required]
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  [Column("is_completed", TypeName = "tinyint(1)")]
  public bool IsCompleted {get; set;}

  [Column("deleted_at")]
  public DateTime DeletedAt {get; set;}

  [Column("created_at")]
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public DateTime CreatedAt {get; set;}

  [Column("updated_at")]
  [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
  public DateTime UpdatedAt {get; set;}
}