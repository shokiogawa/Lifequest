using Lifequest.Src.Domain.Entity;
using Lifequest.Src.Infrastructure.Db;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Lifequest.Src.Domain.IRepository;
using Lifequest.Src.Infrastructure.Db.Tables;
using Lifequest.Src;
using Lifequest.Src.UseCase.Query;
namespace Lifequest.Src.Infrastructure.Repository;

public class BankQueryService : IBankQueryService
{
  private readonly LifequestDbContext _dbContext;
  private readonly IMapper _mapper;

  public BankQueryService(LifequestDbContext dbContext, IMapper mapper)
  {
    _dbContext = dbContext;
    _mapper = mapper;
  }

  /**
  家族に紐づく銀行取得メソッド
  **/
  public async Task<List<Bank>> GetListByFamilyId(uint familyId)
  {
    try
    {
      var query = from banks in _dbContext.BankTable where banks.FamilyId == familyId && banks.DeletedAt == Constant.DeletedAt select banks;
      var bankDataList = await query.ToListAsync();
      var bankList = bankDataList.Select(bank => 
      Bank.FromRepository(
        bank.Id, 
        bank.FamilyId, 
        bank.FamilymemberId, 
        bank.Name, 
        bank.Code, 
        bank.BranchNumber, 
        bank.BranchName, 
        bank.AccountNumber, 
        bank.TotalAmount, 
        bank.DeletedAt, 
        bank.CreatedAt, 
        bank.UpdatedAt
      )).ToList();
      return bankList;
    }
    catch(Exception ex)
    {
      throw ex;
    }
  }

  /**
  銀行の詳細を取得するメソッド
  **/
  public async Task<Bank?> GetDetail(uint bankId)
  {
    var query = from banks in _dbContext.BankTable where banks.Id == bankId && banks.DeletedAt == Constant.DeletedAt select banks;
    var bankData = await query.FirstOrDefaultAsync();
    var bank = bankData != null ? Bank.FromRepository(bankData.Id, bankData.FamilyId, bankData.FamilymemberId, bankData.Name, bankData.Code, bankData.BranchNumber, bankData.BranchName, bankData.AccountNumber, bankData.TotalAmount, bankData.DeletedAt, bankData.CreatedAt, bankData.UpdatedAt) : null;
    return bank;
  }

  /**
  
  **/
  // public async Task GetBankHistories(uint bankId)
  // {
  //   try
  //   {
  //     var query = from banks in _dbContext.BankTable 
  //                 join bankHistories in _dbContext.BankHistoryTable on
  //                  new {BankId = banks.Id, DeletedAt = Constant.DeletedAt} equals
  //                  new {BankId = bankHistories.BankId, DeletedAt = bankHistories.DeletedAt}
  //                  where banks.Id == bankId
  //                 orderby bankHistories.CreatedAt descending
  //                 select bankHistories;
  //     var bankHistoriesData = await query.ToListAsync();
  //   }
  //   catch(Exception ex)
  //   {
  //     throw ex;
  //   }
  // }
}