using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lifequest.Src.Infrastructure.Db.Tables;

[Table("schedules")]
public class ScheduleTable 
{
  [Key]
  [Required]
  [Column("id")]
  public uint Id {get; set;}

  [Required]
  [Column("family_id")]
  public uint FamilyId {get ;set;}

  [Required]
  [Column("title")]
  public string Title {get;set;}

  [Column("content")]
  public string Content {get; set;}

  [Required]

  [Column("start_date_time")]
  public DateTime StartDateTime {get;set;}

  [Required]

  [Column("end_date_time")]
  public DateTime EndDateTime {get;set;}

  [Column("is_all_day_flag",TypeName = "tinyint(1)")]
  public bool IsAllDayFlag {get ;set;}

  [Column("created_user_id")]
  public uint CreatedUserId {get ;set;}

  [Column("deleted_at")]
  public DateTime DeletedAt {get; set;}

  [Column("created_at")]
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public DateTime CreatedAt {get; set;}

  [Column("updated_at")]
  [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
  public DateTime UpdatedAt {get; set;}
}