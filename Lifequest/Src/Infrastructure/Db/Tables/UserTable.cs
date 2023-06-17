using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lifequest.Src.Infrastructure.Db.Tables;

[Table("users")]
public class UserTable 
{
  [Key]
  [Required]
  [Column("id")]
  public uint Id {get; set;}

  [Required]
  [Column("uuid", TypeName = "VARCHAR(255)")]
  public string Uid {get; set;}

  [Required]
  [Column("email", TypeName = "VARCHAR(255)")]
  public string Email {get; set;}

  [Required]
  [Column("name", TypeName = "VARCHAR(32)")]
  public string Name {get; set;}

  [Required]
  [Column("birthday")]
  public DateTime Birthday {get; set;}

  [Required]
  [Column("age", TypeName = "tinyint")]
  public byte Age {get; set;}

  [Required]
  [Column("gender", TypeName = "tinyint(1)")]
  public bool Gender {get; set;}

  [Column("deleted_at")]
  public DateTime DeletedAt {get; set;}

  [Column("created_at")]
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public DateTime CreatedAt {get; set;}

  [Column("updated_at")]
  [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
  public DateTime UpdatedAt {get; set;}
}