using System.Text.Json;
using System.Text.Json.Serialization;
namespace Lifequest.Src.ViewModel;

public class FamilyMemberPostRequestModel
{
  [JsonPropertyName("user_id")]
  public uint UserId {get; set;}

  [JsonPropertyName("is_owner")]
  public bool IsOwner {get; set;}

  [JsonPropertyName("position")]
  public string Position {get; set;} = default!;
}