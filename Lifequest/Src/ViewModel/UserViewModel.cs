using System.Text.Json;
using System.Text.Json.Serialization;
namespace Lifequest.Src.ViewModel;

public class UserViewModel
{
  [JsonPropertyName("id")]
  public uint Id {get; set;}
  [JsonPropertyName("uid")]
  public string Uid {get; set;}
  [JsonPropertyName("email")]
  public string Email {get; set;}
  [JsonPropertyName("name")]
  public string Name {get; set;}
  [JsonPropertyName("birthday")]
  public DateTime Birthday {get; set;}
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