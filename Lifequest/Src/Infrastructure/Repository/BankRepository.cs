using Lifequest.Src.Domain.Entity;
using Lifequest.Src.Infrastructure.Db;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Lifequest.Src.Domain.IRepository;
using Lifequest.Src.Infrastructure.Db.Tables;
using Lifequest.Src;
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

  /**
  家族の銀行を取得するメソッド
  **/
  public async Task<List<Bank>>  GetFamilyBanks(uint familyId)
  {
    var query = from banks in _dbContext.BankTable where banks.FamilyId == familyId && banks.DeletedAt == Constant.DeletedAt select banks;
    var bankDataList = await query.ToListAsync();
    var bank = bankDataList.Select( _ => Bank.FromRepository(_.Id, _.FamilyId, _.FamilymemberId, _.Name, _.Code, _.BranchNumber, _.BranchName, _.AccountNumber, _.TotalAmount, _.DeletedAt, _.CreatedAt, _.UpdatedAt)).ToList();
    return bank;
  }

  /**
  銀行を登録するメソッド
  **/
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

  /**
  銀行情報を更新(料金以外)
  **/
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

  /**
  貯金量を更新する(銀行履歴テーブルも同時に更新)
  **/
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

  /**
  idを元に銀行情報を取得する。
  **/
  public async Task<Bank?> GetByIdAsync(uint bankId)
  {
    var query = from banks in _dbContext.BankTable where banks.Id == bankId select banks;
    var bank = await query.FirstOrDefaultAsync();
    return bank != null ?  Bank.FromRepository(bank.Id, bank.FamilyId, bank.FamilymemberId, bank.Name, bank.Code, bank.BranchNumber, bank.BranchName, bank.AccountNumber, bank.TotalAmount, bank.DeletedAt, bank.CreatedAt, bank.UpdatedAt) : null;
  }

}