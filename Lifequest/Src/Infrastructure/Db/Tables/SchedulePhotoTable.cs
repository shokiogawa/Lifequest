using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lifequest.Src.Infrastructure.Db.Tables;

[Table("schedule_photos")]
public class SchedulePhotoTable 
{
  [Key]
  [Required]
  [Column("id")]
  public int Id {get; set;}
}