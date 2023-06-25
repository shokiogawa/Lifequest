namespace Lifequest.Src;

public class Appsettings 
{
  public Redis Redis {get; set;}
  public FirebaseConfig FirebaseConfig{get; set;}
}

public class Redis 
{
  public string ConnectionStrings {get; set;}

  public string InstanceName {get; set;}
}

public class FirebaseConfig
{
  public string ApiKey {get; set;}

  public string AuthDomain {get; set;}

  public string ProjectId {get; set;}

  public string Authority {get; set;}

  public string ValidIssuer{get; set;}

  public string ValidAudience{get; set;}
}