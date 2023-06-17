using AutoMapper;
using Lifequest.Src.Infrastructure.Db.Tables;
using Lifequest.Src.Domain.Entity;
using Lifequest.Src.ViewModel;

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

      // アプリ → DB
      cfg.CreateMap<User, UserTable>();
      cfg.CreateMap<Family, FamilyTable>();
      cfg.CreateMap<FamilyMember, FamilyMembersTable>();
      cfg.CreateMap<Bank, BankTable>();
      cfg.CreateMap<BankHistory, BankHistoryTable>();
    });
    return config.CreateMapper();
  }
}

