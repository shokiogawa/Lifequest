using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Lifequest.Src.Infrastructure.Db;
using Lifequest.Src.Lib;
using AutoMapper;
using Lifequest.Src.Infrastructure.Repository;
using Lifequest.Src.Domain.IRepository;
using Lifequest.Src.UseCase.Query;
using Lifequest.Src.UseCase.Command;
using Lifequest.Src;
using Microsoft.EntityFrameworkCore;
using Firebase.Auth;
using Firebase.Auth.Providers;
using Lifequest.Src.Domain.Entity;

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder()
// 変数設定
.AddJsonFile($"appsettings.json")
// docker-compose変数設定
.AddEnvironmentVariables()
.Build();

// 環境変数
var settings = configuration.Get<Appsettings>();
var connectionString = configuration.GetConnectionString("Mysql");
MySqlServerVersion serverVersion = new (new Version(5, 7, 0));
Console.WriteLine(settings.Redis.ConnectionStrings);
Console.WriteLine(settings.Redis.InstanceName);

// redis設定追加
builder.Services.AddDistributedRedisCache(options => {
    options.Configuration = settings.Redis.ConnectionStrings;
    options.InstanceName = settings.Redis.InstanceName;
});
// セッション設定追加
builder.Services.AddSession(option => {
    // セッションタイムアウト3時間
    option.IdleTimeout = TimeSpan.FromSeconds(10800);
    option.Cookie.Name = "lifequest.session";
    option.Cookie.IsEssential = true;
    option.Cookie.HttpOnly = true;
});

// Firebase AdminのAPIを使用するためのメソッド
builder.Services.AddSingleton(FirebaseApp.Create(new AppOptions{
    Credential = GoogleCredential.FromFile("lifequest-firebase-key.json"),
}));

// Firebase AuthClientを追加(トークン取得用)
builder.Services.AddSingleton<FirebaseAuthClient>(
    new FirebaseAuthClient(
        new FirebaseAuthConfig
        {
            ApiKey = settings.FirebaseConfig.ApiKey,
            AuthDomain = settings.FirebaseConfig.AuthDomain,
            Providers = new FirebaseAuthProvider[]
            {
                new EmailProvider()
            }
        }
    )
);
// JWTトークン認証設定
builder.Services
.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options => 
{
    options.Authority = settings.FirebaseConfig.Authority;
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true, // JWTトークンの有効期限を見て、期限切れの場合は認証失敗にする
        ValidateIssuerSigningKey = true,
        ValidIssuer = settings.FirebaseConfig.ValidIssuer, //
        ValidAudience = settings.FirebaseConfig.ValidAudience, //firebase-app-id
        // IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your-secret-key")) // JWT署名の検証に使用する鍵を指定します
    };
    options.Events = new JwtBearerEvents
    {
        // トークン認証失敗時
        OnAuthenticationFailed = context => 
        {
            Console.WriteLine("認証失敗");
            return Task.CompletedTask;
        },
        // トークン認証に成功時
        OnTokenValidated = context => 
        {
            Console.WriteLine("認証成功");
            return Task.CompletedTask;
        },
        
    };
});

var mapperConfig = AutoMapperConfig.RegisterAutoMapper();

builder.Services.AddHttpContextAccessor();
// mapper
builder.Services.AddSingleton<IMapper>(mapperConfig);

// DBcontext
builder.Services.AddDbContext<LifequestDbContext>(options => 
{
    options.UseMySql(connectionString, serverVersion);
});

// アクセスユーザーの情報を取得
builder.Services.AddScoped<AuthUserContext>();

// repository
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IBankRepository, BankRepository>();
builder.Services.AddScoped<IFamilyRepository, FamilyRepository>();
builder.Services.AddScoped<IFixedCostRepository, FixedCostRepository>();
builder.Services.AddScoped<IScheduleRepository, ScheduleRepository>();

// query service
builder.Services.AddScoped<IUserQueryService, UserQueryService>();
builder.Services.AddScoped<IBankQueryService, BankQueryService>();
builder.Services.AddScoped<IFixedCostQueryService, FixedCostQueryService>();
builder.Services.AddScoped<IScheduleQueryService, ScheduleQueryService>();

// usecase

builder.Services.AddScoped<CreateUserUseCase>();
builder.Services.AddScoped<CreateFamilyUseCase>();
builder.Services.AddScoped<CreateBankUseCase>();
builder.Services.AddScoped<CreateFixedCostUseCase>();
builder.Services.AddScoped<UpdateBankTotalAmountUseCase>();
builder.Services.AddScoped<CreateScheduleUseCase>();


// コントローラー
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseCustomeMiddleware();
app.UseSession();

app.MapControllers();

app.Run();
