using System.Text.Json.Serialization;
using Lifequest.Src.ViewModel;
namespace Lifequest.Src.ClientModel.RequestModel;

public class FamilyPostRequestModel
{
  [JsonPropertyName("id")]
  public uint Id {get; set;}

  [JsonPropertyName("name")]
  public string Name {get; set;} = default!;

  [JsonPropertyName("family_members")]
  public List<FamilyMemberPostRequestModel> FamilyMembers {get; set;} = new List<FamilyMemberPostRequestModel>();

  [JsonPropertyName("deleted_at")]
  public DateTime DeletedAt {get; set;}
  [JsonPropertyName("created_at")]
  public DateTime CreatedAt {get; set;}
  [JsonPropertyName("updated_at")]
  public DateTime UpdatedAt {get; set;}
}