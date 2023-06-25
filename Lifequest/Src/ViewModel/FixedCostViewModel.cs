using System.Text.Json;
using System.Text.Json.Serialization;
namespace Lifequest.Src.ViewModel;

public class FixedCostViewModel
{
  [JsonPropertyName("id")]
  public uint Id {get; set;}

  [JsonPropertyName("family_id")]
  public uint FamilyId {get; set;}

  [JsonPropertyName("name")]
  public string Name {get; set;}

  [JsonPropertyName("expose")]
  public uint Expose {get; set;}

  [JsonPropertyName("deleted_at")]
  public DateTime DeletedAt {get; set;}
  [JsonPropertyName("created_at")]
  public DateTime CreatedAt {get; set;}
  [JsonPropertyName("updated_at")]
  public DateTime UpdatedAt {get; set;}
}