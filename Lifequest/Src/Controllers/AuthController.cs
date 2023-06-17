using Microsoft.AspNetCore.Mvc;
using Firebase.Auth;
using Firebase.Auth.Providers;
namespace Lifequest.Src.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
  private readonly ILogger<AuthController> _logger;
  private readonly FirebaseAuthClient _client;
  public AuthController(ILogger<AuthController> logger, FirebaseAuthClient client)
  {
    _logger = logger;
    _client = client;
  }

  [HttpGet]
  // アカウントのあるユーザーのIDトークンを取得する。
  public async Task<string> GetIdToken(string email, string password)
  {
    try
    {
      _logger.LogInformation("トークン取得開始");
      var userCredential = await _client.SignInWithEmailAndPasswordAsync(email, password);
      var user = userCredential.User;
      var token = await user.GetIdTokenAsync();
      _logger.LogInformation("トークン取得終了");
      return token;
    }
    catch(Exception e)
    {
      throw e;
    }
  }
}