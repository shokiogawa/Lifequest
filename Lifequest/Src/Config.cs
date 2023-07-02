namespace Lifequest.Src;

public class Appsettings 
{
  public Redis Redis {get; set;} = default!;
  public FirebaseConfig FirebaseConfig{get; set;} = default!;
}

public class Redis 
{
  public string ConnectionStrings {get; set;} = default!;

  public string InstanceName {get; set;} = default!;
}

public class FirebaseConfig
{
  public string ApiKey {get; set;} = default!;

  public string AuthDomain {get; set;} = default!;

  public string ProjectId {get; set;} = default!;

  public string Authority {get; set;} = default!;

  public string ValidIssuer{get; set;} = default!;

  public string ValidAudience{get; set;} = default!;
}