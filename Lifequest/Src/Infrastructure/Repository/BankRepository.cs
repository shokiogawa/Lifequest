using Lifequest.Src.Domain.Models.Banks;
using Lifequest.Src.Infrastructure.Db;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Lifequest.Src.Domain.IRepository;
using Lifequest.Src.Infrastructure.Db.Tables;
using Lifequest.Src.Domain.Models.BankHistory;
namespace Lifequest.Src.Infrastructure.Repository;

public class BankRepository : IBankRepository
{
  private readonly LifequestDbContext _dbContext;
  private readonly IMapper _mapper;

  public BankRepository(LifequestDbContext dbContext, IMapper mapper)
  {
    _dbContext = dbContext;
    _mapper = mapper;
  }

  /// <summary>
  /// 家族が所有している銀行を取得
  /// </summary>
  /// <param name="familyId"></param>
  /// <returns></returns>
  public async Task<List<Bank>>  GetFamilyBanks(uint familyId)
  {
    var query = from banks in _dbContext.BankTable where banks.FamilyId == familyId && banks.DeletedAt == Constant.DeletedAt select banks;
    var bankDataList = await query.ToListAsync();
    var bank = bankDataList.Select( _ => Bank.FromRepository(_.Id, _.FamilyId, _.FamilymemberId, _.Name, _.Code, _.BranchNumber ?? default, _.BranchName, _.AccountNumber ?? default, _.TotalAmount, _.DeletedAt, _.CreatedAt, _.UpdatedAt)).ToList();
    return bank;
  }

  /// <summary>
  /// 家族に紐づく銀行を作成する
  /// </summary>
  /// <param name="bank"></param>
  /// <returns></returns>
  public async Task Create(Bank bank)
  {
    try
    {
      var bankData = _mapper.Map<BankTable>(bank);
      await _dbContext.BankTable.AddAsync(bankData);
      var affectedRow = await _dbContext.SaveChangesAsync();
      if(affectedRow <= 0)
      {
        throw new Exception("bank data can not be saved");
        }
      }
    catch(Exception e)
    {
      throw e;
    }
  }

  /// <summary>
  /// 銀行情報を更新する
  /// </summary>
  /// <param name="newBank"></param>
  /// <returns></returns>
  public async Task UpdateInfo(Bank newBank)
  {
    try
    {
      var targetBank = await (from banks in _dbContext.BankTable where banks.Id == newBank.Id select banks).FirstOrDefaultAsync();
      if(targetBank == null)
      {
        throw new Exception("対象データが存在しません。");
      }
      // 対象データ更新
      targetBank.Name = newBank.Name;
      targetBank.Code = newBank.Code;
      targetBank.BranchName = newBank.BranchName;
      targetBank.BranchNumber = newBank.BranchNumber;
      targetBank.AccountNumber = newBank.AccountNumber;      
      var affectedRoew = await _dbContext.SaveChangesAsync();
      if(affectedRoew <= 0)
      {
        throw new Exception("bank can not updated");
      }
    }
    catch(Exception e)
    {
      throw e;
    }
  }

  /// <summary>
  /// 貯金額を更新する
  /// </summary>
  /// <param name="newBank"></param>
  /// <param name="bankHistory"></param>
  /// <returns></returns>
  public async Task UpdateTotalAmount(Bank newBank, BankHistory bankHistory)
  {
    using(var transaction = await _dbContext.Database.BeginTransactionAsync())
    {
      try
      {
        var targetBank = await (from banks in _dbContext.BankTable where banks.Id == newBank.Id select banks).FirstOrDefaultAsync();
        if(targetBank == null)
        {
          throw new Exception("対象データが存在しません。");
        }
        targetBank.TotalAmount = newBank.TotalAmount;

        var bankHistoryData = _mapper.Map<BankHistoryTable>(bankHistory);
        await _dbContext.BankHistoryTable.AddAsync(bankHistoryData);
        await _dbContext.SaveChangesAsync();

        await transaction.CommitAsync();
      }
      catch(Exception e)
      {
        await transaction.RollbackAsync();
        throw e;
      } 
    }
  }

  /// <summary>
  /// 銀行IDをもとに銀行情報を取得する
  /// </summary>
  /// <param name="bankId"></param>
  /// <returns></returns>
  public async Task<Bank?> GetByIdAsync(uint bankId)
  {
    var query = from banks in _dbContext.BankTable where banks.Id == bankId select banks;
    var bank = await query.FirstOrDefaultAsync();
    return bank != null ?  Bank.FromRepository(bank.Id, bank.FamilyId, bank.FamilymemberId, bank.Name, bank.Code, bank.BranchNumber ?? default, bank.BranchName, bank.AccountNumber ?? default, bank.TotalAmount, bank.DeletedAt, bank.CreatedAt, bank.UpdatedAt) : null;
  }

  /// <summary>
  /// 家族に紐づく銀行情報を取得する
  /// </summary>
  /// <param name="familyId"></param>
  /// <returns></returns>
  public async Task<List<Bank>> FetchListByFamilyId(uint familyId)
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
        bank.Code ?? "", 
        bank.BranchNumber ?? default, 
        bank.BranchName ?? "", 
        bank.AccountNumber ?? default, 
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

  /// <summary>
  /// 銀行情報取得
  /// </summary>
  /// <param name="bankId"></param>
  /// <returns></returns>
  public async Task<Bank?> FetchDetail(uint bankId)
  {
    var query = from banks in _dbContext.BankTable where banks.Id == bankId && banks.DeletedAt == Constant.DeletedAt select banks;
    var bankData = await query.FirstOrDefaultAsync();
    var bank = bankData != null ? Bank.FromRepository(bankData.Id, bankData.FamilyId, bankData.FamilymemberId, bankData.Name, bankData.Code, bankData.BranchNumber ?? default, bankData.BranchName, bankData.AccountNumber ?? default, bankData.TotalAmount, bankData.DeletedAt, bankData.CreatedAt, bankData.UpdatedAt) : null;
    return bank;
  }

}