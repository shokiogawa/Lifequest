using System.Text.Json;
using System.Text.Json.Serialization;
namespace Lifequest.Src.ViewModel.ResponseModel;

public class ScheduleResponseModel
{
  [JsonPropertyName("schedules")]
  public List<ScheduleViewModel> ScheduleList {get; set;}
}