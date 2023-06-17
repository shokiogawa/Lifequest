using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Lifequest.Src;
using Lifequest.Src.Infrastructure.Db;
using Firebase.Auth;
using Firebase.Auth.Providers;
using Lifequest.Src.Lib;
using AutoMapper;
using Lifequest.Src.Infrastructure.Repository;
using Lifequest.Src.Domain.IRepository;
using Lifequest.Src.UseCase.Query;
using Lifequest.Src.UseCase.Command;

var builder = WebApplication.CreateBuilder(args);

// // redis設定追加
// builder.Services.AddDistributedRedisCache(options => {
//     options.Configuration = "127.0.0.1:6379";
//     options.InstanceName = "lifequest:";
// });
// // セッション設定追加
// builder.Services.AddSession(option => {
//     // セッションタイムアウト3時間
//     option.IdleTimeout = TimeSpan.FromSeconds(10800);
//     option.Cookie.Name = "merubo.session";
//     option.Cookie.IsEssential = true;
// });

var mapperConfig = AutoMapperConfig.RegisterAutoMapper();
// mapper
builder.Services.AddSingleton<IMapper>(mapperConfig);

// DBcontext
builder.Services.AddDbContext<LifequestDbContext>();

// repository
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IBankRepository, BankRepository>();
builder.Services.AddScoped<IFamilyRepository, FamilyRepository>();

// query service
builder.Services.AddScoped<IUserQueryService, UserQueryService>();
builder.Services.AddScoped<IBankQueryService, BankQueryService>();

// usecase

builder.Services.AddScoped<CreateUserUseCase>();
builder.Services.AddScoped<CreateFamilyUseCase>();
builder.Services.AddScoped<CreateBankUseCase>();
builder.Services.AddScoped<UpdateBankTotalAmountUseCase>();


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

// app.UseCustomeMiddleware();
// app.UseSession();

app.MapControllers();

app.Run();
