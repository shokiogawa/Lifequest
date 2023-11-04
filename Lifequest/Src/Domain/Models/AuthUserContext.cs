namespace Lifequest.Src.Domain.Entity;

public class AuthUserContext
{
  private static readonly string UidKey = "user_id";
  private static readonly string EmailKey = "email";
  private static readonly string IsEmailValifiedKey = "email_verified";
  private IHttpContextAccessor _context;
  public AuthUserContext(IHttpContextAccessor context)
  {
    // contextがnullの場合は例外
    if(context.HttpContext == null)
    {
      throw new ArgumentException(nameof(context));
    }
    _context = context;
    Uid = _context.HttpContext.User.Claims.Where(_ => _.Type == UidKey).First().Value;
    // Email = _context.HttpContext.User.Claims.Where(_ => _.Type == EmailKey).First().Value;
    // IsEmailValified = System.Convert.ToBoolean(_context.HttpContext.User.Claims.Where(_ => _.Type == IsEmailValifiedKey).First().Value);
  }
  public string Uid {get; private set;}
  public string Email {get; private set;}
  public bool IsEmailValified {get; private set;}

}