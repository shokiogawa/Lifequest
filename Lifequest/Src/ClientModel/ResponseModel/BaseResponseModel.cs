using System.Text.Json.Serialization;
namespace Lifequest.Src.ViewModel.ResponseModel;

public class BaseResponseModel<T>
{

  [JsonPropertyName("status")]
  public string Status {get; set;} = "";

  [JsonPropertyName("data")]
  public T? Data {get; set;}

  [JsonPropertyName("message")]
  public string Message {get; set;} = "";
}

