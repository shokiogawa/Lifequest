using System.Text.Json;
using System.Text.Json.Serialization;
namespace Lifequest.Src.ViewModel;

public class FamilyMemberPostRequestModel
{
  [JsonPropertyName("user_id")]
  public uint UserId {get; set;}

  [JsonPropertyName("family_id")]
  public uint FamilyId {get; set;}

  [JsonPropertyName("is_owner")]
  public bool IsOwner {get; set;}

  [JsonPropertyName("position")]
  public string Position {get; set;} = default!;
  [JsonPropertyName("deleted_at")]
  public DateTime DeletedAt {get; set;}
  [JsonPropertyName("created_at")]
  public DateTime CreatedAt {get; set;}
  [JsonPropertyName("updated_at")]
  public DateTime UpdatedAt {get; set;}
}