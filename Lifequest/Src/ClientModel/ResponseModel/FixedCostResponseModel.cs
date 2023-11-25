using System.Text.Json;
using System.Text.Json.Serialization;
namespace Lifequest.Src.ClientModel.ResponseModel;

public class FixedCostListResponseModel
{
  [JsonPropertyName("fixed_costs")]
  public List<FixedCostResponseModel> FixedCostList {get; set;} = new List<FixedCostResponseModel>();
}

public class FixedCostResponseModel
{
  [JsonPropertyName("id")]
  public uint Id {get; set;}

  [JsonPropertyName("family_id")]
  public uint FamilyId {get; set;}

  [JsonPropertyName("name")]
  public string Name {get; set;} = default!;

  [JsonPropertyName("expose")]
  public uint Expose {get; set;}

  [JsonPropertyName("deleted_at")]
  public DateTime DeletedAt {get; set;}
  [JsonPropertyName("created_at")]
  public DateTime CreatedAt {get; set;}
  [JsonPropertyName("updated_at")]
  public DateTime UpdatedAt {get; set;}
}