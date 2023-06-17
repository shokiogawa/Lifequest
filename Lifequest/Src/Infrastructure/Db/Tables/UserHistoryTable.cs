using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lifequest.Src.Infrastructure.Db.Tables;

[Table("user_histories")]
public class UserHistoryTable 
{
  [Key]
  [Required]
  [Column("id")]
  public int Id {get; set;}
}