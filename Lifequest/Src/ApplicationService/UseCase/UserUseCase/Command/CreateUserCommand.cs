namespace Lifequest.Src.ApplicationService.UseCase.UserUseCase.Command;

public class CreateUserCommand
{
    public uint Id {get; set;}
  public string Uid {get; set;}
  public string Email {get; set;}
  public string Name {get; set;}
  public DateTime Birthday {get; set;}
  public byte Age {get; set;}
  public bool Gender {get; set;}
  public DateTime DeletedAt {get; set;}
  public DateTime CreatedAt {get; set;}
  public DateTime UpdatedAt {get; set;}
}