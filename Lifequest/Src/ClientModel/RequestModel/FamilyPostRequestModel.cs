using System.Text.Json.Serialization;
using Lifequest.Src.ViewModel;
namespace Lifequest.Src.ClientModel.RequestModel;

public class FamilyPostRequestModel
{
  [JsonPropertyName("name")]
  public string Name {get; set;} = default!;

  [JsonPropertyName("family_members")]
  public List<FamilyMemberPostRequestModel> FamilyMembers {get; set;} = new List<FamilyMemberPostRequestModel>();
}