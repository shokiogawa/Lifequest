using AutoMapper;
using Lifequest.Src.Infrastructure.Db.Tables;
using Lifequest.Src.Domain.Models.Users;
using Lifequest.Src.Domain.Models.Banks;
using Lifequest.Src.Domain.Models.BankHistory;
using Lifequest.Src.Domain.Models.Schedules;
using Lifequest.Src.Domain.Models.Families;
using Lifequest.Src.Domain.Models.FixedCosts;
using Lifequest.Src.ViewModel;
using Lifequest.Src.ViewModel.ResponseModel;
using Lifequest.Src.ApplicationService.UseCase.FamilyUseCase;
namespace Lifequest.Src.Lib;

public interface ICustomeMapper : IMapper{}

public class AutoMapperConfig :  Profile
{
  public static IMapper RegisterAutoMapper()
  {
    var config = new MapperConfiguration(cfg => 
    {

      // アプリ内 → ブラウザ
      cfg.CreateMap<User, UserViewModel>();
      cfg.CreateMap<Bank, BankViewModel>();
      cfg.CreateMap<FixedCost, FixedCostViewModel>();
      cfg.CreateMap<Schedule, ScheduleViewModel>();

      // アプリ → DB
      cfg.CreateMap<User, UserTable>();
      cfg.CreateMap<Family, FamilyTable>();
      cfg.CreateMap<FamilyMember, FamilyMembersTable>();
      cfg.CreateMap<Bank, BankTable>();
      cfg.CreateMap<BankHistory, BankHistoryTable>();
      cfg.CreateMap<FixedCost, FixedCostTable>();
      cfg.CreateMap<Schedule, ScheduleTable>();

      // Dto → レスポンスモデル
      cfg.CreateMap<FamilyMemberDto, FamilyMemberResponseModel>();
      cfg.CreateMap<FetchFamilyListUseCaseDto, FamilyInfoResponseModel>();
    });
    return config.CreateMapper();
  }
}

