using System.Text.Json.Serialization;
using Lifequest.Src.ClientModel.ResponseModel;
namespace Lifequest.Src.ViewModel.ResponseModel;

public class ScheduleListResponseModel
{
  [JsonPropertyName("schedules")]
  public List<ScheduleResponseModel> ScheduleList {get; set;} = default!;
}