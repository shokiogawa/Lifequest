using System.Text.Json;
using System.Text.Json.Serialization;
namespace Lifequest.Src.ViewModel;

public class ScheduleViewModel
{
   [JsonPropertyName("id")]
  public uint Id {get; set;}
  [JsonPropertyName("family_id")]
  public uint FamilyId {get; set;}

   [JsonPropertyName("title")]
  public string Title {get; set;} = default!;

   [JsonPropertyName("content")]
  public string Content {get; set;} = default!;

  [JsonPropertyName("start_date_time")]
  public string StartDateTime {get; set;} = default!;

  [JsonPropertyName("end_date_time")]
  public string EndDateTime {get; set;} = default!;

   [JsonPropertyName("is_all_day_flag")]

  public bool IsAllDayFlag {get; set;}

   [JsonPropertyName("created_user_id")]

  public uint CreatedUserId {get; set;}

   [JsonPropertyName("deleted_at")]

  public DateTime DeletedAt {get; set;}

  [JsonPropertyName("created_at")]
  public DateTime CreatedAt {get; set;}
  [JsonPropertyName("updated_at")]
  public DateTime UpdatedAt {get; set;}
}