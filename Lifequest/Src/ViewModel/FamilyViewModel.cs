using System.Text.Json;
using System.Text.Json.Serialization;
namespace Lifequest.Src.ViewModel;

public class CreateFamilyViewModel
{
  [JsonPropertyName("id")]
  public uint Id {get; set;}

  [JsonPropertyName("name")]
  public string Name {get; set;}

  [JsonPropertyName("family_members")]
  public List<FamilyMemberViewModel> FamilyMembers {get; set;} = new List<FamilyMemberViewModel>();

  [JsonPropertyName("deleted_at")]
  public DateTime DeletedAt {get; set;}
  [JsonPropertyName("created_at")]
  public DateTime CreatedAt {get; set;}
  [JsonPropertyName("updated_at")]
  public DateTime UpdatedAt {get; set;}
}