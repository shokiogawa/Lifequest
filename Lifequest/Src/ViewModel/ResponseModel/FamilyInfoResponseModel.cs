using Lifequest.Src.Domain.IRepository;
using Lifequest.Src.Domain.Entity;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace Lifequest.Src.ViewModel.ResponseModel;

public class FamilyInfoListResponseModel
{
  [JsonPropertyName("family_list")]
  public List<FamilyInfoResponseModel> FamilyList {get; set;} = default!;
}

public class FamilyInfoResponseModel
{

  [JsonPropertyName("family_id")]
  public uint FamilyId {get; set;}

  [JsonPropertyName("family_name")]
  public string FamilyName {get ;set;} = default!;

  [JsonPropertyName("position")]
  public string Position {get; set;} = default!;

  [JsonPropertyName("is_owner")]
  public bool IsOwner {get; set;}

  [JsonPropertyName("family_members")]
  public List<FamilyMemberResponseModel> FamilyMambers {get; set;} = default!;
}

public class FamilyMemberResponseModel
{
  [JsonPropertyName("user_id")]
  public uint UserId {get;set;}

  [JsonPropertyName("family_member_id")]
  public uint FamilymemberId {get; set;}

  [JsonPropertyName("name")]
  public string Name {get; set;} = default!;

  [JsonPropertyName("position")]
  public string Position {get; set;} = default!;

  [JsonPropertyName("is_owner")]
  public bool IsOwner {get; set;}

}