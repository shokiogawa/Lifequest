using System.Text.Json.Serialization;
namespace Lifequest.Src.ViewModel;

public class BankViewModel
{
  [JsonPropertyName("id")]
  public uint Id {get; set;}
  
  [JsonPropertyName("family_id")]
  public uint FamilyId {get;  set;}

  [JsonPropertyName("family_member_id")]
  public uint FamilymemberId {get;  set;}

  [JsonPropertyName("name")]
  public string Name {get;  set;} = default!;

  [JsonPropertyName("code")]
  public string? Code {get;  set;}

  [JsonPropertyName("branch_number")]

  public UInt16? BranchNumber {get ; set;}

  [JsonPropertyName("branch_name")]
  public string? BranchName {get; set;}

  [JsonPropertyName("account_number")]
  public uint? AccountNumber {get; set;}

  [JsonPropertyName("total_amount")]
  public uint TotalAmount {get; set;}

  [JsonPropertyName("deleted_at")]
  public DateTime DeletedAt {get; set;}

  [JsonPropertyName("created_at")]
  public DateTime CreatedAt {get; set;}

  [JsonPropertyName("updated_at")]
  public DateTime UpdatedAt {get; set;}

}