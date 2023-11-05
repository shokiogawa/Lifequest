using Lifequest.Src.Infrastructure.Repository;
using Lifequest.Src.Domain.IRepository;
using Lifequest.Src.ApplicationService.IQueryService;
using Lifequest.Src.ApplicationService.UseCase.BankUseCase.Command;
using Lifequest.Src.ApplicationService.UseCase.FamilyUseCase.Command;
using Lifequest.Src.ApplicationService.UseCase.FixedCostUseCase.Command;
using Lifequest.Src.ApplicationService.UseCase.ScheduleUseCase.Command;
using Lifequest.Src.ApplicationService.UseCase.UserUseCase.Command;
using Lifequest.Src.ApplicationService.UseCase.BankUseCase.Query;
using Lifequest.Src.ApplicationService.UseCase.FamilyUseCase.Query;
using Lifequest.Src.ApplicationService.UseCase.ScheduleUseCase.Query;
using Lifequest.Src.ApplicationService.UseCase.UserUseCase.Query;
using Lifequest.Src.ApplicationService.UseCase.FixedCostUseCase.Query;
using Lifequest.Src.Domain.Entity;
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
    _logger.LogInformation(context.Request.Path);
    await _next(context);
  }
}

public static class CustomeMiddlewareExtensions
{
  public static IApplicationBuilder UseCustomeMiddleware(this IApplicationBuilder builder)
  {
    return builder.UseMiddleware<CustomeMiddleware>();
  }

  // 依存関係解消
  public static void AddInitialized(this IServiceCollection services)
  {
    // アクセスユーザーの情報を取得
    services.AddScoped<AuthUserContext>();
    // repository
    services.AddScoped<IUserRepository, UserRepository>();
    services.AddScoped<IBankRepository, BankRepository>();
    services.AddScoped<IFamilyRepository, FamilyRepository>();
    services.AddScoped<IFixedCostRepository, FixedCostRepository>();
    services.AddScoped<IScheduleRepository, ScheduleRepository>();
    // query service
    services.AddScoped<IUserQueryService, UserQueryService>();
    services.AddScoped<IBankQueryService, BankQueryService>();
    services.AddScoped<IFixedCostQueryService, FixedCostQueryService>();
    services.AddScoped<IScheduleQueryService, ScheduleQueryService>();
    services.AddScoped<IFamilyQueryService, FamilyQueryService>();
    // usecase
    services.AddScoped<CreateUserUseCase>();
    services.AddScoped<CreateFamilyUseCase>();
    services.AddScoped<CreateBankUseCase>();
    services.AddScoped<CreateFixedCostUseCase>();
    services.AddScoped<UpdateBankTotalAmountUseCase>();
    services.AddScoped<CreateScheduleUseCase>();
    services.AddScoped<AddFamilyMemberUseCase>();
    services.AddScoped<FetchUserDetailUseCase>();
    services.AddScoped<FetchBankListByFamilyIdUseCase>();
    services.AddScoped<FetchFamilyListUseCase>();
    services.AddScoped<FetchFixedCostByFamilyIdUseCase>();
    services.AddScoped<FetchScheduleByFamilyIdUseCase>();
    }
    }