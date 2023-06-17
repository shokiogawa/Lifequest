namespace Lifequest.Src;
public class CustomeMiddleware
{
  private readonly RequestDelegate _next;
  private readonly ILogger<CustomeMiddleware> _logger;
  public CustomeMiddleware(RequestDelegate next, ILogger<CustomeMiddleware> logger)
  {
    _next = next;
    _logger = logger;
  }
  public async Task InvokeAsync(HttpContext context)
  {
    _logger.LogInformation("カスタムミドルウェア開始");
    _logger.LogInformation(context.Request.Path);
    _logger.LogInformation("カスタムミドルウェア終了");
    await _next(context);
  }
}

public static class CustomeMiddlewareExtensions
{
  public static IApplicationBuilder UseCustomeMiddleware(this IApplicationBuilder builder)
  {
    return builder.UseMiddleware<CustomeMiddleware>();
  }
}