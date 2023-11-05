using System.Text.Json.Serialization;
namespace Lifequest.Src.ViewModel;

public class UserPostRequestModel
{
  [JsonPropertyName("id")]
  public uint Id {get; set;}
  [JsonPropertyName("uid")]
  public string Uid {get; set;} = default!;
  [JsonPropertyName("email")]
  public string Email {get; set;} = default!;
  [JsonPropertyName("name")]
  public string Name {get; set;} = default!;
  [JsonPropertyName("birthday")]
  public string Birthday {get; set;} = default!;
  [JsonPropertyName("age")]
  public byte Age {get; set;}
  [JsonPropertyName("gender")]
  public bool Gender {get; set;}
  [JsonPropertyName("deleted_at")]
  public DateTime DeletedAt {get; set;}
  [JsonPropertyName("created_at")]
  public DateTime CreatedAt {get; set;}
  [JsonPropertyName("updated_at")]
  public DateTime UpdatedAt {get; set;}
}